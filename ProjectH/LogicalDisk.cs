using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ProjectH
{
    public class LogicalDisk
    {
        //Имя диска
        public List<string> Name;
        //Описание диска
        public List<string> Description;
        //Файловая система
        public List<string> FileSystem;
        //Свободное пространство
        public List<string> FreeSpace;
        //Размер диска
        public List<string> FullSpace;
    }

    public class LogicalDiskInfo
    {
        public SQLiteConnectionStringBuilder connStrDB;
        string NameBD;
        string TekPathBD;
        public LogicalDisk logicalDisk;

        public LogicalDiskInfo()
        {
            connStrDB = new SQLiteConnectionStringBuilder();
            TekPathBD = System.IO.Directory.GetCurrentDirectory();
            NameBD = "cllCtrN.sqlit";
            connStrDB.DataSource = TekPathBD + "\\" + NameBD;
            logicalDisk = new LogicalDisk();
        }           

        public void AppropriateInfo()
        {
            
            logicalDisk.Description = new List<string>();
            logicalDisk.FileSystem = new List<string>();
            logicalDisk.FreeSpace = new List<string>();
            logicalDisk.FullSpace = new List<string>();
            logicalDisk.Name = new List<string>();

            //Console.WriteLine("\nИнформация о подключенных накопителях:");

            string strSql;
            DataTable dTable;

            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {

                strSql = "SELECT NAME, KEY ";
                strSql += "FROM ALLINFO ";
                strSql += "WHERE MANCLASS = 'Win32_LogicalDisk' ";
                strSql += "AND (NAME = 'Caption' ";
                strSql += "OR NAME = 'Description' ";
                strSql += "OR NAME = 'FileSystem' ";
                strSql += "OR NAME = 'FreeSpace' ";
                strSql += "OR NAME = 'Size') ";

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
                                logicalDisk.Name.Add("Имя накопителя: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Description":
                                logicalDisk.Description.Add("Описание накопителя: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "FileSystem":
                                if (Convert.ToString(rowGm["KEY"].ToString()) != "")
                                {
                                    logicalDisk.FileSystem.Add("Файловая система накопителя: " + Convert.ToString(rowGm["KEY"].ToString()));
                                }
                                else
                                {
                                    logicalDisk.FileSystem.Add("Файловая система накопителя: Накопитель не имеет файловой системы");
                                }
                                break;
                            case "FreeSpace":
                                if (Convert.ToString(rowGm["KEY"].ToString()) != "")
                                {
                                    logicalDisk.FreeSpace.Add("Свободное пространство накопителя: " + Convert.ToString(rowGm["KEY"].ToString()) + " бит");
                                }
                                else
                                {
                                    logicalDisk.FreeSpace.Add("Свободное пространство накопителя: Диск не вставлен");
                                }
                                break;
                            case "Size":
                                if (Convert.ToString(rowGm["KEY"].ToString()) != "")
                                {
                                    logicalDisk.FullSpace.Add("Размер накопителя: " + Convert.ToString(rowGm["KEY"].ToString()) + " бит");
                                }
                                else
                                {
                                    logicalDisk.FullSpace.Add("Размер накопителя: Диск не вставлен");
                                }
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
