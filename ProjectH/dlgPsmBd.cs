using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectH
{
    public partial class dlgPsmBd : Form
    {

        public SQLiteConnectionStringBuilder connStrDB;

        public dlgPsmBd()
        {
            InitializeComponent();
            connStrDB = new SQLiteConnectionStringBuilder();
            connStrDB.DataSource = System.IO.Directory.GetCurrentDirectory() + "\\" + "cllCtrN.sqlit";
        }

        public bool ObnovView()
        {
            SQLiteConnection conn = new SQLiteConnection(connStrDB.ToString());
            conn.Close();
            try
            {

                string strSql = "SELECT * ";
                strSql += "FROM ALLINFO ";

                SQLiteDataAdapter DAdapter = new SQLiteDataAdapter(strSql, conn);
                DataTable dTable = new DataTable();
                DAdapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dTable;
                    int AllZap = dataGridView1.Rows.Count;
                    toolStripStatusLabel1.Text = "Всего записей: " + AllZap;

                }
                else
                {
                    MessageBox.Show("Err: Таблица пустая");
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Err: " + ex.ToString());
                return false;
            }

        }
    
        private void dlgPsmBd_Load(object sender, EventArgs e)
        {

            if(ObnovView())
            {
                //
            }


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (ObnovView())
            {
                //
            }
        }
    }
}
