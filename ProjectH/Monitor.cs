using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace ProjectH
{
    public class Monitor
    {
        //Подпись подключенного монитора
        public List<string> Caption;
        //ID монитора
        public List<string> DeviceID;
        //Статус монитора
        public List<string> Status;
    }

    public class MonitorInfo
    {
        public SQLiteConnectionStringBuilder connStrDB;
        public Monitor monitor;

        public MonitorInfo()
        {
            connStrDB = new SQLiteConnectionStringBuilder();
            connStrDB.DataSource = System.IO.Directory.GetCurrentDirectory() + "\\" + "cllCtrN.sqlit";
            monitor = new Monitor();
        }

        public void AppropriateInfo()
        {

            monitor.Caption = new List<string>();
            monitor.DeviceID = new List<string>();
            monitor.Status = new List<string>();

            //Console.WriteLine("\nОсновная информация о мониторе ЭВС:");
            string strSql;

            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {

                strSql = "SELECT NAME, KEY ";
                strSql += "FROM ALLINFO ";
                strSql += "WHERE MANCLASS = 'Win32_DesktopMonitor' ";
                strSql += "AND (NAME = 'Caption' ";
                strSql += "OR NAME = 'PNPDeviceID' ";
                strSql += "OR NAME = 'Status') ";

                SQLiteDataAdapter DAdapter = new SQLiteDataAdapter(strSql, conn);
                DataTable dTable = new DataTable();
                DAdapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    foreach (DataRow rowGm in dTable.Rows)
                    {
                        switch (Convert.ToString(rowGm["NAME"].ToString()))
                        {
                            case "Caption":
                                monitor.Caption.Add("Подпись подключенного монитора: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "PNPDeviceID":
                                monitor.DeviceID.Add("ID монитора: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Status":
                                monitor.Status.Add("Статус монитора: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            default:
                                break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Err: " + ex.ToString());
            }
        }
    }
}
