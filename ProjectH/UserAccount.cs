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
    public class UserAccount
    {
        //Описание учетных записей
        public List<string> Description;
        //Имя учетной записи
        public List<string> Name;
        //Статус
        public List<string> Status;
    }

    public class UserAccountInfo
    {
        public SQLiteConnectionStringBuilder connStrDB;
        string NameBD;
        string TekPathBD;
        public UserAccount userAccount;

        public UserAccountInfo()
        {
            connStrDB = new SQLiteConnectionStringBuilder();
            TekPathBD = System.IO.Directory.GetCurrentDirectory();
            NameBD = "cllCtrN.sqlit";
            connStrDB.DataSource = TekPathBD + "\\" + NameBD;
            userAccount = new UserAccount();
        }

        public void AppropriateInfo()
        {
            
            userAccount.Description = new List<string>();
            userAccount.Name = new List<string>();
            userAccount.Status = new List<string>();

            //Console.WriteLine("\nОсновная информация о учетных записях ЭВС:");

            string strSql;
            DataTable dTable;

            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {

                strSql = "SELECT NAME, KEY ";
                strSql += "FROM ALLINFO ";
                strSql += "WHERE MANCLASS = 'Win32_UserAccount' ";
                strSql += "AND (NAME = 'Description' ";
                strSql += "OR NAME = 'Name' ";
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
                            case "Description":
                                userAccount.Description.Add("Описание учетных записей: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Name":
                                userAccount.Name.Add("Имя учетной записи: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Status":
                                userAccount.Status.Add("Статус: " + Convert.ToString(rowGm["KEY"].ToString()));
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
