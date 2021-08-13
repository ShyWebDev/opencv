using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using OpenCvSharp;
using System.Windows.Forms;
using System.IO;

namespace openCV
{
    public class SearchImage
    {
        private int left;
        private int width;
        private int height;
        private Dictionary<FindImg, FindImg> findImgs;

        private MouseEvent mouseEvent = null;
        public SearchImage(int _left, int _width, int _height)
        {
            this.left = _left;
            this.width = _width;
            this.height = _height;
            this.mouseEvent = new MouseEvent();
            //this.findImgs = new Dictionary<FindImg, FindImg>();
        }

        public void findImageAdd(FindImg main, FindImg sub)
        {
            try
            {
                if (this.findImgs == null)
                {
                    this.findImgs = new Dictionary<FindImg, FindImg>();
                }
                this.findImgs.Add(main, sub);
            }catch(Exception ex)
            {

            }
        }

        public Dictionary<FindImg, FindImg> getFindImage()
        {
            return findImgs;
        }

        public void searchImages(string fileName)
        {
            try
            {
                Bitmap background = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                Graphics gr = Graphics.FromImage(background);
                gr.CopyFromScreen(left, 0, 0, 0, background.Size);

                Mat screen = OpenCvSharp.Extensions.BitmapConverter.ToMat(background);

                foreach (KeyValuePair<FindImg, FindImg> findImg in findImgs)
                {
                    if(fileName != null)
                    {
                        if( !fileName.Equals(findImg.Key.fileName))
                        {
                            continue;
                        }
                    }

                    Mat res = screen.MatchTemplate(findImg.Key.imgMat, TemplateMatchModes.CCoeffNormed);
                    double min, max = 0;
                    OpenCvSharp.Point minLoc, maxLoc;

                    Cv2.MinMaxLoc(res, out min, out max, out minLoc, out maxLoc);
                    int x, y = 0;
                    x = maxLoc.X + (findImg.Key.imgMat.Width / 2);
                    y = maxLoc.Y + (findImg.Key.imgMat.Height / 2);
                    if (max >= 0.8)
                    {
                        mouseEvent.mouse_move(left + x, y);
                        mouseEvent.mouse_click();
                        if (findImg.Value != null)
                        {
                            if (fileName != null)
                            {
                                if (!fileName.Equals(findImg.Value.fileName))
                                {
                                    continue;
                                }
                            }

                            min = max = 0;
                            res = screen.MatchTemplate(findImg.Value.imgMat, TemplateMatchModes.CCoeffNormed);
                            Cv2.MinMaxLoc(res, out min, out max, out minLoc, out maxLoc);
                            res.Release();
                            x = maxLoc.X + (findImg.Value.imgMat.Width / 2);
                            y = maxLoc.Y + (findImg.Value.imgMat.Height / 2);
                        }


                        mouseEvent.mouse_move(left + x, y);
                        mouseEvent.mouse_click();
                        string path = Application.StartupPath + @"\backImage\";

                        // 이미지 저장경로 확인 및 생성
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);

                        //png 저장
                        path = path + "back" + DateTime.Now.ToString("yyyy-MM-ddHHmmss") + ".png";
                        background.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                    }

                    res.Release();
                }
                screen.Release();

                background.Dispose();
                gr.Dispose();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
