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
    public class BIOS
    {
        //Дата и версия BIOS
        public List<string> Caption;
        //Производитель BIOS
        public List<string> Manufacturer;
        //Статус BIOS
        public List<string> Status;

    }

    public class BIOSInfo
    {
        public SQLiteConnectionStringBuilder connStrDB;
        public BIOS bios;

        public BIOSInfo()
        {
            connStrDB = new SQLiteConnectionStringBuilder();
            connStrDB.DataSource = System.IO.Directory.GetCurrentDirectory() + "\\" + "cllCtrN.sqlit";
            bios = new BIOS();
        }

        public void AppropriateInfo()
        {
      
            bios.Caption = new List<string>();
            bios.Manufacturer = new List<string>();
            bios.Status = new List<string>();

            //Console.WriteLine("\nОсновная информация о BIOS ЭВС:");
            string strSql;

            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {

                strSql = "SELECT NAME, KEY ";
                strSql += "FROM ALLINFO ";
                strSql += "WHERE MANCLASS = 'Win32_BIOS' ";
                strSql += "AND (NAME = 'Caption' ";
                strSql += "OR NAME = 'Manufacturer' ";
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
                                bios.Caption.Add("Дата и версия BIOS: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Manufacturer":
                                bios.Manufacturer.Add("Производитель BIOS: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Status":
                                bios.Status.Add("Статус BIOS: " + Convert.ToString(rowGm["KEY"].ToString()));
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
