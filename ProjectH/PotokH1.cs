using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Threading;
using System.Management;
using System.Windows.Forms;
using System.IO;

namespace ProjectH
{
    public class PotokH1
    {

        public SQLiteConnectionStringBuilder connStrDB;
        //PrjForm prjForm;
        Mutex mutex;
        object locker;

        ThreadStart ZpskH1;
        public Thread H1ptk;

        //public PotokH1(PrjForm vxForm)
        public PotokH1()
        {

            locker = new object();

            connStrDB = new SQLiteConnectionStringBuilder();
            //connStrDB.DataSource = System.IO.Directory.GetCurrentDirectory() + "\\" + "cllCtrN.sqlit;" + "Journal Mode=Off;";
            connStrDB.DataSource = System.IO.Directory.GetCurrentDirectory() + "\\" + "cllCtrN.sqlit";

            //prjForm = new PrjForm();
            //prjForm = vxForm;

            mutex = new Mutex();

            ZpskH1 = new ThreadStart(StrCreatedInZm);
            H1ptk = new Thread(ZpskH1);
            H1ptk.Name = "Sled H1";
            H1ptk.Start();
            
        }

        //Подключение пространства имен


        public void StrCreatedInZm()
        {

            lock (locker)
            {

                //mutex.WaitOne();

                //Thread.Sleep(10);
                //prjForm.toolStripStatusLabel2.Text = "Новый поток запущен! Блокировка!";
                //Application.DoEvents();

                if (CreateTableBD())
                {
                //    prjForm.toolStripStatusLabel1.Text = "Создание БД если нет!";
                //    Application.DoEvents();
                }
                else
                {
                //    prjForm.toolStripStatusLabel1.Text = "Ошибка создания БД!";
                //    Application.DoEvents();
                }
                //Thread.Sleep(10);

                if (DelTableBD())
                {
                //    prjForm.toolStripStatusLabel1.Text = "Создание БД если нет!";
                //    Application.DoEvents();
                }
                else
                {
                //    prjForm.toolStripStatusLabel1.Text = "Ошибка создания БД!";
                //    Application.DoEvents();
                }
                //Thread.Sleep(10);

                //prjForm.toolStripStatusLabel1.Text = "Собираем информацию о процессоре, пожалуйста, подождите...";
                //Application.DoEvents();
                InsertInfoToBD("Win32_Processor", connStrDB);
                //prjForm.toolStripStatusLabel1.Text = "Готово!";
                //Application.DoEvents();
                //Thread.Sleep(10);

                //prjForm.toolStripStatusLabel1.Text = "Собираем информацию о носителях, пожалуйста, подождите...";
                //Application.DoEvents();
                InsertInfoToBD("Win32_LogicalDisk", connStrDB);
                //prjForm.toolStripStatusLabel1.Text = "Готово!";
                //Application.DoEvents();

                //prjForm.toolStripStatusLabel1.Text = "Собираем информацию о клавиатуре, пожалуйста, подождите...";
                //Application.DoEvents();
                InsertInfoToBD("Win32_Keyboard", connStrDB);
                //prjForm.toolStripStatusLabel1.Text = "Готово!";
                //Application.DoEvents();

                //prjForm.toolStripStatusLabel1.Text = "Собираем информацию о материнской плате, пожалуйста, подождите...";
                //Application.DoEvents();
                InsertInfoToBD("Win32_BaseBoard", connStrDB);
                //prjForm.toolStripStatusLabel1.Text = "Готово!";
                //Application.DoEvents();

                //prjForm.toolStripStatusLabel1.Text = "Собираем информацию о BIOS, пожалуйста, подождите...";
                //Application.DoEvents();
                InsertInfoToBD("Win32_BIOS", connStrDB);
                //prjForm.toolStripStatusLabel1.Text = "Готово!";
                //Application.DoEvents();

                //prjForm.toolStripStatusLabel1.Text = "Собираем информацию о разъемах платы, пожалуйста, подождите...";
                //Application.DoEvents();
                InsertInfoToBD("Win32_PortConnector", connStrDB);
                //prjForm.toolStripStatusLabel1.Text = "Готово!";
                //Application.DoEvents();

                //prjForm.toolStripStatusLabel1.Text = "Собираем информацию о разъемах USB, пожалуйста, подождите...";
                //Application.DoEvents();
                InsertInfoToBD("Win32_USBHub", connStrDB);
                //prjForm.toolStripStatusLabel1.Text = "Готово!";
                //Application.DoEvents();

                //prjForm.toolStripStatusLabel1.Text = "Собираем информацию о мониторе, пожалуйста, подождите...";
                //Application.DoEvents();
                InsertInfoToBD("Win32_DesktopMonitor", connStrDB);
                //prjForm.toolStripStatusLabel1.Text = "Готово!";
                //Application.DoEvents();

                //prjForm.toolStripStatusLabel1.Text = "Собираем информацию о видео контроллере, пожалуйста, подождите...";
                //Application.DoEvents();
                InsertInfoToBD("Win32_VideoController", connStrDB);
                //prjForm.toolStripStatusLabel1.Text = "Готово!";
                //Application.DoEvents();

                //prjForm.toolStripStatusLabel1.Text = "Собираем информацию о интернет адаптере, пожалуйста, подождите...";
                //Application.DoEvents();
                InsertInfoToBD("Win32_NetworkAdapter", connStrDB);
                //prjForm.toolStripStatusLabel1.Text = "Готово!";
                //Application.DoEvents();

                //prjForm.toolStripStatusLabel1.Text = "Собираем информацию о операционной системе, пожалуйста, подождите...";
                //Application.DoEvents();
                InsertInfoToBD("Win32_OperatingSystem", connStrDB);
                //prjForm.toolStripStatusLabel1.Text = "Готово!";
                //Application.DoEvents();

                //prjForm.toolStripStatusLabel1.Text = "Собираем информацию о пользователях, пожалуйста, подождите...";
                //Application.DoEvents();
                InsertInfoToBD("Win32_UserAccount", connStrDB);
                //prjForm.toolStripStatusLabel1.Text = "Вся информация собрана и отформатирована для анализа";
                //Application.DoEvents();

            }

            Thread.Sleep(10);
            //prjForm.toolStripStatusLabel2.Text = "Поток освобожден.";
            //Application.DoEvents();

            //mutex.ReleaseMutex();
        }


        public bool InsertInfoToBD(string classes, SQLiteConnectionStringBuilder connStrDB)
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

                InzCmd.CommandText = "PRAGMA synchronous = 0;PRAGMA journal_mode = OFF;";
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
                            MessageBox.Show("Err: " + exInz.ToString());
                        }
                    }
                }

                //InzCmd.CommandText = "COMMIT";
                //InzCmd.ExecuteNonQuery();

                InzCmd.CommandText = "PRAGMA synchronous = FULL;PRAGMA journal_mode = DELETE;";
                InzCmd.ExecuteNonQuery();

                InzCmd.Dispose();
                conn.Close();

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Err: " + ex.ToString());
                return false;
            }
            finally
            {
                conn.Close();
            }
        }


        public bool DelTableBD()
        {
            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {
                if (conn.State == ConnectionState.Closed) { conn.Open(); }

                SQLiteCommand cmdCDB = conn.CreateCommand();
                cmdCDB.Connection = conn;

                cmdCDB.CommandText = "PRAGMA synchronous = 0;PRAGMA journal_mode = OFF;";
                cmdCDB.ExecuteNonQuery();

                //создаем таблицу
                string strSQL = "DELETE FROM ALLINFO ";

                cmdCDB.CommandText = strSQL;
                cmdCDB.ExecuteNonQuery();

                cmdCDB.CommandText = "PRAGMA synchronous = FULL;PRAGMA journal_mode = DELETE;";
                cmdCDB.ExecuteNonQuery();

                cmdCDB.Dispose();
                conn.Close();

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Err: " + ex.ToString());
                return false;
            }
            finally
            {
                conn.Close();
            }


        }


        public bool CreateTableBD()
        {
            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            conn.Close();
            try
            {

                if (!File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\" + "cllCtrN.sqlit"))
                {
                    SQLiteConnection.CreateFile(System.IO.Directory.GetCurrentDirectory() + "\\" + "cllCtrN.sqlit");
                }

                if (conn.State == ConnectionState.Closed) { conn.Open(); }

                SQLiteCommand cmdCDB = conn.CreateCommand();
                cmdCDB.Connection = conn;

                cmdCDB.CommandText = "PRAGMA synchronous = 0;PRAGMA journal_mode = OFF;";
                cmdCDB.ExecuteNonQuery();

                string strSQL = "CREATE TABLE IF NOT EXISTS ALLINFO(IDGINFO INTEGER PRIMARY KEY, MANCLASS VARCHAR, NAME VARCHAR, KEY VARCHAR)";

                cmdCDB.CommandText = strSQL;
                cmdCDB.ExecuteNonQuery();

                cmdCDB.CommandText = "PRAGMA synchronous = FULL;PRAGMA journal_mode = DELETE;";
                cmdCDB.ExecuteNonQuery();

                cmdCDB.Dispose();
                conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Err: " + ex.ToString());
                return false;
            }
            finally
            {
                conn.Close();
            }

        }


    }
}
