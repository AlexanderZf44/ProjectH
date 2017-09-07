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
    public class VideoController
    {
        //Тип адаптера ЦАП
        public List<string> AdapterDACType;
        //Имя видеоконтроллера
        public List<string> Name;
        //Текущее горизонтальное разрешение
        public List<string> HorizontalResolution;
        //Текущее вертикальное разрешение
        public List<string> VerticalResolution;
        //Текущая частота обновления кадров
        public List<string> RefreshRate;
        //Версия драйвера
        public List<string> DriverVersion;
        //Пути установленных драйверов
        public List<string> InstalledDrivers;
        //Статус видеоконтроллера
        public List<string> Status;
    }

    public class VideoControllerInfo
    {
        public SQLiteConnectionStringBuilder connStrDB;
        string NameBD;
        string TekPathBD;
        public VideoController videoController;

        public VideoControllerInfo()
        {
            connStrDB = new SQLiteConnectionStringBuilder();
            TekPathBD = System.IO.Directory.GetCurrentDirectory();
            NameBD = "cllCtrN.sqlit";
            connStrDB.DataSource = TekPathBD + "\\" + NameBD;
            videoController = new VideoController();
        }

        public void AppropriateInfo()
        {
            
            videoController.AdapterDACType = new List<string>();
            videoController.DriverVersion = new List<string>();
            videoController.HorizontalResolution = new List<string>();
            videoController.InstalledDrivers = new List<string>();
            videoController.Name = new List<string>();
            videoController.RefreshRate = new List<string>();
            videoController.Status = new List<string>();
            videoController.VerticalResolution = new List<string>();

            //Console.WriteLine("\nОсновная информация о видеоконтроллере  ЭВС:");

            string strSql;
            DataTable dTable;

            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            try
            {

                strSql = "SELECT NAME, KEY ";
                strSql += "FROM ALLINFO ";
                strSql += "WHERE MANCLASS = 'Win32_VideoController' ";
                strSql += "AND (NAME = 'AdapterDACType' ";
                strSql += "OR NAME = 'Caption' ";
                strSql += "OR NAME = 'CurrentHorizontalResolution' ";
                strSql += "OR NAME = 'CurrentVerticalResolution' ";
                strSql += "OR NAME = 'CurrentRefreshRate' ";
                strSql += "OR NAME = 'DriverVersion' ";
                strSql += "OR NAME = 'InstalledDisplayDrivers' ";
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
                            case "AdapterDACType":
                                videoController.AdapterDACType.Add("Тип адаптера ЦАП видеоконтроллера: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Caption":
                                videoController.Name.Add("Имя видеоконтроллера: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "CurrentHorizontalResolution":
                                videoController.HorizontalResolution.Add("Текущее горизонтальное разрешение: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "CurrentVerticalResolution":
                                videoController.VerticalResolution.Add("Текущее вертикальное разрешение: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "CurrentRefreshRate":
                                videoController.RefreshRate.Add("Текущая частота обновления кадров: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "DriverVersion":
                                videoController.DriverVersion.Add("Версия установленного драйвера: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "InstalledDisplayDrivers":
                                videoController.InstalledDrivers.Add("Пути установленных драйверов: " + Convert.ToString(rowGm["KEY"].ToString()));
                                break;
                            case "Status":
                                videoController.Status.Add("Статус видеоконтроллера: " + Convert.ToString(rowGm["KEY"].ToString()));
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
