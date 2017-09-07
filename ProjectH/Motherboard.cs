using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;


namespace ProjectH
{
    public class Motherboard
    {
        //Компания производитель
        public List<string> Manufacturer;
        //Модель материнской платы
        public List<string> Product;
        //Описание платы
        public List<string> Description;
        //Статус платы
        public List<string> Status;
    }

    public class MotherboardInfo
    {
        public SQLiteConnectionStringBuilder connStrDB;
        string NameBD;
        string TekPathBD;
        public Motherboard motherboard;

        public MotherboardInfo()
        {
            connStrDB = new SQLiteConnectionStringBuilder();
            TekPathBD = System.IO.Directory.GetCurrentDirectory();
            NameBD = "cllCtrN.sqlit";
            connStrDB.DataSource = TekPathBD + "\\" + NameBD;
            motherboard = new Motherboard();
        }

        public void AppropriateInfo()
        {

            motherboard.Description = new List<string>();
            motherboard.Manufacturer = new List<string>();
            motherboard.Product = new List<string>();
            motherboard.Status = new List<string>();

            //Console.WriteLine("\nОсновная информация о материнской плате ЭВС:");

            string strSql;
            DataTable dTable;

            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {

                strSql = "SELECT NAME, KEY ";
                strSql += "FROM ALLINFO ";
                strSql += "WHERE MANCLASS = 'Win32_BaseBoard' ";
                strSql += "AND (NAME = 'Manufacturer' ";
                strSql += "OR NAME = 'Product' ";
                strSql += "OR NAME = 'Description' ";
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
                            case "Manufacturer":
                                motherboard.Manufacturer.Add("Компания производитель платы: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Product":
                                motherboard.Product.Add("Модель материнской платы: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Description":
                                motherboard.Description.Add("Описание материнской платы: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Status":
                                motherboard.Status.Add("Статус материнской платы: " + Convert.ToString(rowGm["KEY"].ToString()));
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
            finally
            {
                conn.Close();
            }

        }
    }
}
