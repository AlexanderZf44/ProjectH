using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ProjectH
{
    public class USBHub
    {
        //Подпись подключенного девайса
        public List<string> Caption;
        //ID подключенного девайса
        public List<string> DeviceID;
        //Статус девайса
        public List<string> Status;
    }

    public class USBHubInfo
    {
        public SQLiteConnectionStringBuilder connStrDB;
        string NameBD;
        string TekPathBD;
        public USBHub usbHub;

        public USBHubInfo()
        {
            connStrDB = new SQLiteConnectionStringBuilder();
            TekPathBD = System.IO.Directory.GetCurrentDirectory();
            NameBD = "cllCtrN.sqlit";
            connStrDB.DataSource = TekPathBD + "\\" + NameBD;
            usbHub = new USBHub();
        }

        public void AppropriateInfo()
        {
            
            usbHub.Caption = new List<string>();
            usbHub.DeviceID = new List<string>();
            usbHub.Status = new List<string>();

            //Console.WriteLine("\nОсновная информация о разьемах USB ЭВС:");

            string strSql;
            DataTable dTable;

            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {

                strSql = "SELECT NAME, KEY ";
                strSql += "FROM ALLINFO ";
                strSql += "WHERE MANCLASS = 'Win32_USBHub' ";
                strSql += "AND (NAME = 'Caption' ";
                strSql += "OR NAME = 'DeviceID' ";
                strSql += "OR NAME = 'Status') ";

                SQLiteDataAdapter DAdapter = new SQLiteDataAdapter(strSql, conn);
                dTable = new DataTable();
                DAdapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    foreach (DataRow rowGm in dTable.Rows)
                    {
                        switch (Convert.ToString(rowGm["NAME"].ToString()))
                        {
                            case "Caption":
                                usbHub.Caption.Add("Подпись подключенного девайса: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "DeviceID":
                                usbHub.DeviceID.Add("ID подключенного девайса: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Status":
                                usbHub.Status.Add("Статус девайса: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            default:
                                break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }
            
        }
    }
}
