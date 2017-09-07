using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace ProjectH
{
    public class WorkWithBD
    {
        public SQLiteConnectionStringBuilder connStrDB;
        string NameBD;
        string TekPathBD;
        public PrjForm prjForm;

        public WorkWithBD()
        {
            connStrDB = new SQLiteConnectionStringBuilder();
            TekPathBD = System.IO.Directory.GetCurrentDirectory();
            NameBD = "cllCtrN.sqlit";
            connStrDB.DataSource = TekPathBD + "\\" + NameBD;
            prjForm = new PrjForm();
        }

        public void InitialBD()
        {
            if (!File.Exists(TekPathBD + "\\" + NameBD))
            {
                SQLiteConnection.CreateFile(TekPathBD + "\\" + NameBD);
            }

            CreateTableBD();
        }

        public void CreateTableBD()
        {
            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {
                if (conn.State == ConnectionState.Closed) { conn.Open(); }

                SQLiteCommand cmdCDB = conn.CreateCommand();
                cmdCDB.Connection = conn;

                //создаем таблицу
                string strSQL = "DROP TABLE IF EXISTS ALLINFO;";
                strSQL += "CREATE TABLE ALLINFO(IDGINFO INTEGER PRIMARY KEY, MANCLASS VARCHAR, NAME VARCHAR, KEY VARCHAR)";
                cmdCDB.CommandText = strSQL;
                cmdCDB.ExecuteNonQuery();

                cmdCDB.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка создания таблицы {0}", ex.ToString());
            }

            prjForm.toolStripStatusLabel1.Text = "Собираем информацию о процессоре, пожалуйста, подождите...";
            Application.DoEvents();
            InsertInfoToBD("Win32_Processor", connStrDB);
            prjForm.toolStripStatusLabel1.Text = "Готово!";
            Application.DoEvents();

            prjForm.toolStripStatusLabel1.Text = "Собираем информацию о носителях, пожалуйста, подождите...";
            Application.DoEvents();
            InsertInfoToBD("Win32_LogicalDisk", connStrDB);
            prjForm.toolStripStatusLabel1.Text = "Готово!";
            Application.DoEvents();

            prjForm.toolStripStatusLabel1.Text = "Собираем информацию о клавиатуре, пожалуйста, подождите...";
            Application.DoEvents();
            InsertInfoToBD("Win32_Keyboard", connStrDB);
            prjForm.toolStripStatusLabel1.Text = "Готово!";
            Application.DoEvents();

            prjForm.toolStripStatusLabel1.Text = "Собираем информацию о материнской плате, пожалуйста, подождите...";
            Application.DoEvents();
            InsertInfoToBD("Win32_BaseBoard", connStrDB);
            prjForm.toolStripStatusLabel1.Text = "Готово!";
            Application.DoEvents();

            prjForm.toolStripStatusLabel1.Text = "Собираем информацию о BIOS, пожалуйста, подождите...";
            Application.DoEvents();
            InsertInfoToBD("Win32_BIOS", connStrDB);
            prjForm.toolStripStatusLabel1.Text = "Готово!";
            Application.DoEvents();

            prjForm.toolStripStatusLabel1.Text = "Собираем информацию о разъемах платы, пожалуйста, подождите...";
            Application.DoEvents();
            InsertInfoToBD("Win32_PortConnector", connStrDB);
            prjForm.toolStripStatusLabel1.Text = "Готово!";
            Application.DoEvents();

            prjForm.toolStripStatusLabel1.Text = "Собираем информацию о разъемах USB, пожалуйста, подождите...";
            Application.DoEvents();
            InsertInfoToBD("Win32_USBHub", connStrDB);
            prjForm.toolStripStatusLabel1.Text = "Готово!";
            Application.DoEvents();

            prjForm.toolStripStatusLabel1.Text = "Собираем информацию о мониторе, пожалуйста, подождите...";
            Application.DoEvents();
            InsertInfoToBD("Win32_DesktopMonitor", connStrDB);
            prjForm.toolStripStatusLabel1.Text = "Готово!";
            Application.DoEvents();

            prjForm.toolStripStatusLabel1.Text = "Собираем информацию о видео контроллере, пожалуйста, подождите...";
            Application.DoEvents();
            InsertInfoToBD("Win32_VideoController", connStrDB);
            prjForm.toolStripStatusLabel1.Text = "Готово!";
            Application.DoEvents();

            prjForm.toolStripStatusLabel1.Text = "Собираем информацию о интернет адаптере, пожалуйста, подождите...";
            Application.DoEvents();
            InsertInfoToBD("Win32_NetworkAdapter", connStrDB);
            prjForm.toolStripStatusLabel1.Text = "Готово!";
            Application.DoEvents();

            prjForm.toolStripStatusLabel1.Text = "Собираем информацию о операционной системе, пожалуйста, подождите...";
            Application.DoEvents();
            InsertInfoToBD("Win32_OperatingSystem", connStrDB);
            prjForm.toolStripStatusLabel1.Text = "Готово!";
            Application.DoEvents();

            prjForm.toolStripStatusLabel1.Text = "Собираем информацию о пользователях, пожалуйста, подождите...";
            Application.DoEvents();
            InsertInfoToBD("Win32_UserAccount", connStrDB);
            prjForm.toolStripStatusLabel1.Text = "Вся информация собрана и отформатирована для анализа";
            Application.DoEvents();

            prjForm.toolStripStatusLabel2.Text = "Готово.";
            Application.DoEvents();


        }

        public void InsertInfoToBD(string classes, SQLiteConnectionStringBuilder connStrDB)
        {
            ManagementClass currentProbeClass = new ManagementClass();
            currentProbeClass.Path = new ManagementPath(classes);

            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {
                if (conn.State == ConnectionState.Closed) { conn.Open(); }

                string strSql = "INSERT INTO ALLINFO ";
                strSql += " (MANCLASS, NAME, KEY) ";
                strSql += "VALUES (@MANCLASS, @NAME, @KEY);";

                SQLiteCommand InzCmd = conn.CreateCommand();

                InzCmd.CommandText = "PRAGMA journal_mode = OFF";
                InzCmd.ExecuteNonQuery();

                InzCmd.CommandText = strSql;

                InzCmd.Parameters.Add("@MANCLASS", DbType.String, 100, "MANCLASS");
                InzCmd.Parameters.Add("@NAME", DbType.String, 100, "NAME");
                InzCmd.Parameters.Add("@KEY", DbType.String, 300, "KEY");


                foreach (var obj in currentProbeClass.GetInstances())
                {
                    foreach (PropertyData property in currentProbeClass.Properties)
                    {

                        InzCmd.Parameters["@MANCLASS"].Value = classes;
                        InzCmd.Parameters["@NAME"].Value = property.Name;
                        InzCmd.Parameters["@KEY"].Value = obj.Properties[property.Name].Value;

                        try
                        {
                            InzCmd.ExecuteNonQuery();
                        }
                        catch (Exception exInz)
                        {
                            Console.WriteLine("Ошибка внесения информации в таблицу", exInz.ToString());
                        }
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка БД", ex.ToString());
            }
        }

    }
}
