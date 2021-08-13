using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using log4net.Config;
using System.IO;

namespace openCV
{
    public class Sqlite
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Form1));
        private SQLiteConnection conn = null;
        public Sqlite()
        {
            SQLiteConnection.CreateFile(Application.StartupPath+@"\image.sqlite");
            conn = new SQLiteConnection("Data Source="+ Application.StartupPath + @"\image.sqlite" + ";Version=3;");

            XmlConfigurator.Configure(new FileInfo(Application.StartupPath + @"\log4net.xml"));
        }

        public int ExecuteNonQuery(string sql)
        {
            int result = 0;
            try
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                result = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                log.Error("ExecuteReader " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public DataTable ExecuteReader(string sql)
        {
            DataTable dt = null;
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(rdr);
                rdr.Close();
            }
            catch (Exception ex)
            {
                log.Error("ExecuteReader " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
    }
}
