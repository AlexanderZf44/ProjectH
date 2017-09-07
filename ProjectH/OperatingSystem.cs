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
    public class OperatingSystem
    {
        //Название операционной системы
        public List<string> Caption;
        //Кол-во процессов
        public List<string> NumberOfProcesses;
        //Кол-во пользователей
        public List<string> NumberOfUsers;
        //Разрядность системы
        public List<string> OSArchitecture;
        //Текущий пользователь
        public List<string> User;
        //Путь системы
        public List<string> Directory;
        //Версия системы
        public List<string> Version;
    }

    public class OperatingSystemInfo
    {
        public SQLiteConnectionStringBuilder connStrDB;
        string NameBD;
        string TekPathBD;
        public OperatingSystem operatingSystem;
        public OperatingSystemInfo()
        {
            connStrDB = new SQLiteConnectionStringBuilder();
            TekPathBD = System.IO.Directory.GetCurrentDirectory();
            NameBD = "cllCtrN.sqlit";
            connStrDB.DataSource = TekPathBD + "\\" + NameBD;
            operatingSystem = new OperatingSystem();
        }

        public void AppropriateInfo()
        {
            
            operatingSystem.Caption = new List<string>();
            operatingSystem.Directory = new List<string>();
            operatingSystem.NumberOfProcesses = new List<string>();
            operatingSystem.NumberOfUsers = new List<string>();
            operatingSystem.OSArchitecture = new List<string>();
            operatingSystem.User = new List<string>();
            operatingSystem.Version = new List<string>();

            //Console.WriteLine("\nОсновная информация о операционной системе ЭВС:");

            string strSql;
            DataTable dTable;

            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {

                strSql = "SELECT NAME, KEY ";
                strSql += "FROM ALLINFO ";
                strSql += "WHERE MANCLASS = 'Win32_OperatingSystem' ";
                strSql += "AND (NAME = 'Caption' ";
                strSql += "OR NAME = 'NumberOfProcesses' ";
                strSql += "OR NAME = 'NumberOfUsers' ";
                strSql += "OR NAME = 'OSArchitecture' ";
                strSql += "OR NAME = 'RegisteredUser' ";
                strSql += "OR NAME = 'SystemDirectory' ";
                strSql += "OR NAME = 'Version') ";

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
                                operatingSystem.Caption.Add("Название операционной системы: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "NumberOfProcesses":
                                operatingSystem.NumberOfProcesses.Add("Кол-во процессов: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "NumberOfUsers":
                                operatingSystem.NumberOfUsers.Add("Кол-во пользователей: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "OSArchitecture":
                                operatingSystem.OSArchitecture.Add("Разрядность системы: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "RegisteredUser":
                                operatingSystem.User.Add("Текущий пользователь: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "SystemDirectory":
                                operatingSystem.Directory.Add("Путь системы: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Version":
                                operatingSystem.Version.Add("Версия системы: " + Convert.ToString(rowGm["KEY"].ToString()));
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
