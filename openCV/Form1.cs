using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using log4net.Config;

namespace openCV
{
    public partial class Form1 : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Form1));
        private SearchImage searchImage = null;
        private Sqlite sqlite = null;

        public Form1()
        {
            InitializeComponent();
            XmlConfigurator.Configure(new FileInfo(Application.StartupPath+@"\log4net.xml"));
            sqlite = new Sqlite();
            this.CreateTable();
            try
            {
                int Left = 0;
                int Width = 0;
                int Height = 0;
                if (Screen.AllScreens.Length >= 2)
                {
                    foreach (Screen s in Screen.AllScreens)
                    {
                        if (s.WorkingArea.X <= this.Location.X)
                        {
                            if (s.WorkingArea.Contains(this.Location))
                            {
                                Left = s.WorkingArea.Left;
                                Width = s.WorkingArea.Width;
                                Height = s.WorkingArea.Height;
                            }
                        }
                        //rects.Add(screen.WorkingArea);
                    }
                }
                else
                {
                    Left = Screen.PrimaryScreen.Bounds.Left;
                    Width = Screen.PrimaryScreen.Bounds.Width;
                    Height = Screen.PrimaryScreen.Bounds.Height;
                }

                searchImage = new SearchImage(Left, Width, Height);
                string path = Application.StartupPath + @"\images\";
                DirectoryInfo di = new DirectoryInfo(path);
                if (di.Exists)
                {
                    FileInfo[] fileNames = di.GetFiles("*.png");
                    foreach (FileInfo fi in fileNames)
                    {
                        FindImg findImg = new FindImg();
                        findImg.filePath = path;
                        findImg.fileName = fi.Name;
                        Bitmap image = new Bitmap(path + fi.Name);
                        findImg.img = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppPArgb);

                        using (Graphics gr = Graphics.FromImage(findImg.img))
                        {
                            gr.DrawImage(image, new Rectangle(0, 0, findImg.img.Width, findImg.img.Height));
                        }
                        findImg.imgMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(findImg.img);
                        searchImage.findImageAdd(findImg, null);
                    }
                }
              

                path = Application.StartupPath + @"\images\mainImages\";
                di = new DirectoryInfo(path);
                if (di.Exists)
                {
                    FileInfo[] fileNames = di.GetFiles("*.png");
                    foreach (FileInfo fi in fileNames)
                    {
                        FindImg mainFindImg = new FindImg();
                        mainFindImg.filePath = path;
                        mainFindImg.fileName = fi.Name;
                        Bitmap image = new Bitmap(path + fi.Name);
                        mainFindImg.img = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppPArgb);

                        using (Graphics gr = Graphics.FromImage(mainFindImg.img))
                        {
                            gr.DrawImage(image, new Rectangle(0, 0, mainFindImg.img.Width, mainFindImg.img.Height));
                        }
                        
                        mainFindImg.imgMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(mainFindImg.img);

                        string subPath = Application.StartupPath + @"\images\subImage\";
                        di = new DirectoryInfo(subPath);
                        if (di.Exists)
                        {
                            FileInfo[] sunFileNames = di.GetFiles("*.png");
                            foreach (FileInfo sfi in sunFileNames)
                            {
                                if (sfi.Name.ToLower().Contains(mainFindImg.fileName.ToLower().Replace(".png", "")))
                                {
                                    FindImg subFindImg = new FindImg();
                                    subFindImg.filePath = path;
                                    subFindImg.fileName = sfi.Name;
                                    Bitmap subImage = new Bitmap(subPath + sfi.Name);
                                    subFindImg.img = new Bitmap(subImage.Width, subImage.Height, PixelFormat.Format32bppPArgb);

                                    using (Graphics gr = Graphics.FromImage(subFindImg.img))
                                    {
                                        gr.DrawImage(subImage, new Rectangle(0, 0, subFindImg.img.Width, subFindImg.img.Height));
                                    }
                                    subFindImg.imgMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(subFindImg.img);

                                    searchImage.findImageAdd(mainFindImg, subFindImg);
                                }
                            }
                        }
                        else
                        {
                            searchImage.findImageAdd(mainFindImg, null);
                        }
                    }
                }

                foreach (KeyValuePair<FindImg, FindImg> findImg in searchImage.getFindImage())
                {
                    if (findImg.Key != null)
                    {
                        listBox.Items.Add(findImg.Key.fileName);
                    }

                    if (findImg.Value != null)
                    {
                        listBox.Items.Add(findImg.Value.fileName);
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("Form1 "+ ex.Message);
            }
        }

        private void CreateTable()
        {
            string sql = "";
            DataTable dt = null;
            sql = "SELECT * FROM sqlite_master WHERE name = 'tb_image'";
            dt = sqlite.ExecuteReader(sql);
            if(dt != null && dt.Rows.Count <= 0)
            {
                sql = "CREATE TABLE \"tb_image\" (\"index\" INTEGER DEFAULT 1,	\"title\" TEXT,	\"filename\"  TEXT,	PRIMARY KEY(\"index\"))";
                int result= sqlite.ExecuteNonQuery(sql);
                dt = null;
            }
        }

        private void btnSearchTest_Click(object sender, EventArgs e)
        {
            searchImage.searchImages(null);
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(object selectItem in listBox.SelectedItems)
                {
                    if (selectItem != null)
                    {
                        foreach (KeyValuePair<FindImg, FindImg> findImg in searchImage.getFindImage())
                        {
                            if (findImg.Key != null && selectItem.Equals(findImg.Key.fileName))
                            {
                                pbMain.Image = findImg.Key.img;

                            }

                            if (findImg.Value != null && selectItem.Equals(findImg.Value.fileName))
                            {
                                pbSub.Image = findImg.Value.img;
                            }

                        }
                    }
                }
                

            }catch(Exception ex)
            {

            }
            
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (object selectItem in listBox.SelectedItems)
                {
                    if (selectItem != null)
                    {
                        listCopyBox.Items.Add(selectItem);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (object selectItem in listBox.SelectedItems)
                {
                    if (selectItem != null)
                    {
                        searchImage.searchImages((string)selectItem);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            List<object> delItems = new List<object>();
            foreach (object selectItem in listCopyBox.SelectedItems)
            {
                if (selectItem != null)
                {
                    delItems.Add(selectItem);
                }
            }

            foreach (object delItem in delItems)
            {
                listCopyBox.Items.Remove(delItem);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int indexNo = 0;
            string sql = "";
            DataTable dt = null;

            sql = "SELECT indexNo FROM tb_image ";
            dt = sqlite.ExecuteReader(sql);
            if (dt != null && dt.Rows.Count <= 0)
            {
                indexNo = 1;
            }
            else if (dt != null && dt.Rows.Count > 0)
            {
                indexNo = 2;
            }

            foreach (object selectItem in listCopyBox.SelectedItems)
            {
                if (selectItem != null)
                {
                    sql = "insert into tb_image(index, title, filename) values(" + indexNo + ",'" + tbTitle.Text + "','" + selectItem + "')";
                    int result = sqlite.ExecuteNonQuery(sql);
                    Console.WriteLine(result);
                    indexNo = indexNo + 1;
                }
            }

           
        }
    }
}
