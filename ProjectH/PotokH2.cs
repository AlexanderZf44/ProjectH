using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace ProjectH
{
    class PotokH2
    {

        public SQLiteConnectionStringBuilder connStrDB;
        //public Mutex mutex;
        PrjForm prjForm;
        ThreadStart ZpskH2;
        public Thread H2ptk;

        public PotokH2(PrjForm vxForm)
        {

            connStrDB = new SQLiteConnectionStringBuilder();
            connStrDB.DataSource = System.IO.Directory.GetCurrentDirectory() + "\\" + "cllCtrN.sqlit";

            prjForm = new PrjForm();
            prjForm = vxForm;

            ZpskH2 = new ThreadStart(StrCreatedInZm);
            H2ptk = new Thread(ZpskH2);
            H2ptk.Name = "Sled H2";
            H2ptk.Start();
        }

        public void StrCreatedInZm()
        {

            //mutex.WaitOne();

            if(VivJson(""))
            {
                prjForm.toolStripStatusLabel1.Text = "Создание БД если нет!";
                Application.DoEvents();
            }

           // mutex.ReleaseMutex();

        }


        public bool VivJson(string classes)
        {


            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {

                FileStream fso10 = File.Open(Application.StartupPath + "\\" + "lg5007n2.txt", FileMode.Create, FileAccess.Write);
                System.IO.StreamWriter swo10 = new System.IO.StreamWriter(fso10, System.Text.Encoding.GetEncoding(1251));

                string strSql = "SELECT NAME, KEY ";
                strSql += "FROM ALLINFO ";
                strSql += "WHERE MANCLASS = '" + classes  + "' ";
                strSql += "AND (NAME = 'Caption' ";
                strSql += "OR NAME = 'PNPDeviceID' ";
                strSql += "OR NAME = 'Status') ";

                SQLiteDataAdapter DAdapter = new SQLiteDataAdapter(strSql, conn);
                DataTable dTable = new DataTable();
                DAdapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {

                }


                swo10.WriteLine("Старт!");

                swo10.Close();
                fso10.Close();

                conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка БД", ex.ToString());
                return false;
            }


        }


    }
}
