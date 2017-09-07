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
    public class BoardConnector
    {
        //Внутренний указатель
        public List<string> InternalDesignator;
        //Тэг
        public List<string> Tag;
    }

    public class BoardConnectorInfo
    {

        public SQLiteConnectionStringBuilder connStrDB;
        string NameBD;
        string TekPathBD;
        public BoardConnector boardConnector;

        public BoardConnectorInfo()
        {
            connStrDB = new SQLiteConnectionStringBuilder();
            TekPathBD = System.IO.Directory.GetCurrentDirectory();
            NameBD = "cllCtrN.sqlit";
            connStrDB.DataSource = TekPathBD + "\\" + NameBD;
            boardConnector = new BoardConnector();
        }

        public void AppropriateInfo()
        {
            
            boardConnector.InternalDesignator = new List<string>();
            boardConnector.Tag = new List<string>();

            //Console.WriteLine("\nОсновная информация о разьемах материнской платы ЭВС:");

            string strSql;
            DataTable dTable;

            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {

                strSql = "SELECT NAME, KEY ";
                strSql += "FROM ALLINFO ";
                strSql += "WHERE MANCLASS = 'Win32_PortConnector' ";
                strSql += "AND (NAME = 'InternalReferenceDesignator' ";
                strSql += "OR NAME = 'Tag') ";

                SQLiteDataAdapter DAdapter = new SQLiteDataAdapter(strSql, conn);
                dTable = new DataTable();
                DAdapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    foreach (DataRow rowGm in dTable.Rows)
                    {
                        switch (Convert.ToString(rowGm["NAME"].ToString()))
                        {
                            case "InternalReferenceDesignator":
                                boardConnector.InternalDesignator.Add("Внутренний указатель разъема: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Tag":
                                boardConnector.Tag.Add("Тэг разъема платы: " + Convert.ToString(rowGm["KEY"].ToString()));
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
