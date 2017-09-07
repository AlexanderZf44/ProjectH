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
    public class Processor
    {
        //серия процессора
        public List<string> Caption;
        //имя процессора
        public List<string> Name;
        //ID процессора
        public List<string> ID;
        //сокет
        public List<string> Socket;
        //разрядность 
        public List<string> BitCapacity;
        //количество ядер
        public List<string> Cores;
        //количество логических ядер
        public List<string> LogicalCore;
        //статус 
        public List<string> Status;
    }

    public class ProcessorInfo
    {
        public SQLiteConnectionStringBuilder connStrDB;
        string NameBD;
        string TekPathBD;
        public Processor processor;
        public ProcessorInfo()
        {
            connStrDB = new SQLiteConnectionStringBuilder();
            TekPathBD = System.IO.Directory.GetCurrentDirectory();
            NameBD = "cllCtrN.sqlit";
            connStrDB.DataSource = TekPathBD + "\\" + NameBD;
            processor = new Processor();
        }

        public void AppropriateInfo()
        {

            processor.BitCapacity = new List<string>();
            processor.Caption = new List<string>();
            processor.Cores = new List<string>();
            processor.ID = new List<string>();
            processor.LogicalCore = new List<string>();
            processor.Name = new List<string>();
            processor.Socket = new List<string>();
            processor.Status = new List<string>();

            //Console.WriteLine("\nОсновная информация о процессоре ЭВС:");

            string strSql;
            DataTable dTable;

            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {

                strSql = "SELECT NAME, KEY ";
                strSql += "FROM ALLINFO ";
                strSql += "WHERE MANCLASS = 'Win32_Processor' ";
                strSql += "AND (NAME = 'Caption' ";
                strSql += "OR NAME = 'Name' ";
                strSql += "OR NAME = 'ProcessorId' ";
                strSql += "OR NAME = 'SocketDesignation' ";
                strSql += "OR NAME = 'AddressWidth' ";
                strSql += "OR NAME = 'NumberOfCores' ";
                strSql += "OR NAME = 'NumberOfLogicalProcessors' ";
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
                                processor.Caption.Add("Серия процессора: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Name":
                                processor.Name.Add("Имя процессора: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "ProcessorId":
                                processor.ID.Add("ID процессора: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "SocketDesignation":
                                processor.Socket.Add("Сокет процессора: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "AddressWidth":
                                processor.BitCapacity.Add("Разрядность процессора: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "NumberOfCores":
                                processor.Cores.Add("Количество ядер процессора: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "NumberOfLogicalProcessors":
                                processor.LogicalCore.Add("Количество логических ядер процессора: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Status":
                                processor.Status.Add("Статус процессора: " + Convert.ToString(rowGm["KEY"].ToString()));
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
