using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace ProjectH
{
    public class PrjForm : Form
    {

        public PotokH1 PTKH1;

        public PrjForm()
        {
            InitializeComponent();
        }


        private MenuStrip menuStrip1;
        private ToolStripMenuItem проВерсияToolStripMenuItem;
        private ToolStripMenuItem обновитьToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        public StatusStrip statusStrip1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BIOSButt;
        private Button MotherboardButt;
        private Button BoardConnButt;
        private Button ProcessorButt;
        private Button USBHubButt;
        private Button VideoContrButt;
        private Button LogicalDiskButt;
        private Button OperatingSysButt;
        private Button UserAccButt;
        private Button MonitorButt;
        private TextBox textBox1;
        public ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        public ToolStripStatusLabel toolStripStatusLabel2;
        private TableLayoutPanel tableLayoutPanel1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проВерсияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BIOSButt = new System.Windows.Forms.Button();
            this.MotherboardButt = new System.Windows.Forms.Button();
            this.BoardConnButt = new System.Windows.Forms.Button();
            this.ProcessorButt = new System.Windows.Forms.Button();
            this.USBHubButt = new System.Windows.Forms.Button();
            this.VideoContrButt = new System.Windows.Forms.Button();
            this.LogicalDiskButt = new System.Windows.Forms.Button();
            this.OperatingSysButt = new System.Windows.Forms.Button();
            this.UserAccButt = new System.Windows.Forms.Button();
            this.MonitorButt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem,
            this.проВерсияToolStripMenuItem,
            this.обновитьToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(745, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // проВерсияToolStripMenuItem
            // 
            this.проВерсияToolStripMenuItem.Name = "проВерсияToolStripMenuItem";
            this.проВерсияToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.проВерсияToolStripMenuItem.Text = "Про версия";
            this.проВерсияToolStripMenuItem.Click += new System.EventHandler(this.проВерсияToolStripMenuItem_Click);
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.обновитьToolStripMenuItem.Text = "Обновить";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(745, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = "...";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.26175F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.73826F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 441);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.BIOSButt, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.MotherboardButt, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.BoardConnButt, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.ProcessorButt, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.USBHubButt, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.VideoContrButt, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.LogicalDiskButt, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.OperatingSysButt, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.UserAccButt, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.MonitorButt, 0, 9);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(212, 435);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // BIOSButt
            // 
            this.BIOSButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BIOSButt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BIOSButt.Location = new System.Drawing.Point(3, 3);
            this.BIOSButt.Name = "BIOSButt";
            this.BIOSButt.Size = new System.Drawing.Size(206, 37);
            this.BIOSButt.TabIndex = 0;
            this.BIOSButt.Text = "BIOS";
            this.BIOSButt.UseVisualStyleBackColor = true;
            this.BIOSButt.Click += new System.EventHandler(this.BIOSButt_Click);
            // 
            // MotherboardButt
            // 
            this.MotherboardButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MotherboardButt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MotherboardButt.Location = new System.Drawing.Point(3, 46);
            this.MotherboardButt.Name = "MotherboardButt";
            this.MotherboardButt.Size = new System.Drawing.Size(206, 37);
            this.MotherboardButt.TabIndex = 1;
            this.MotherboardButt.Text = "Материнская плата";
            this.MotherboardButt.UseVisualStyleBackColor = true;
            this.MotherboardButt.Click += new System.EventHandler(this.MotherboardButt_Click);
            // 
            // BoardConnButt
            // 
            this.BoardConnButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoardConnButt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BoardConnButt.Location = new System.Drawing.Point(3, 89);
            this.BoardConnButt.Name = "BoardConnButt";
            this.BoardConnButt.Size = new System.Drawing.Size(206, 37);
            this.BoardConnButt.TabIndex = 2;
            this.BoardConnButt.Text = "Порты платы";
            this.BoardConnButt.UseVisualStyleBackColor = true;
            this.BoardConnButt.Click += new System.EventHandler(this.button3_Click);
            // 
            // ProcessorButt
            // 
            this.ProcessorButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessorButt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ProcessorButt.Location = new System.Drawing.Point(3, 132);
            this.ProcessorButt.Name = "ProcessorButt";
            this.ProcessorButt.Size = new System.Drawing.Size(206, 37);
            this.ProcessorButt.TabIndex = 3;
            this.ProcessorButt.Text = "Процессор";
            this.ProcessorButt.UseVisualStyleBackColor = true;
            this.ProcessorButt.Click += new System.EventHandler(this.ProcessorButt_Click);
            // 
            // USBHubButt
            // 
            this.USBHubButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.USBHubButt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.USBHubButt.Location = new System.Drawing.Point(3, 175);
            this.USBHubButt.Name = "USBHubButt";
            this.USBHubButt.Size = new System.Drawing.Size(206, 37);
            this.USBHubButt.TabIndex = 4;
            this.USBHubButt.Text = "Разъемы USB";
            this.USBHubButt.UseVisualStyleBackColor = true;
            this.USBHubButt.Click += new System.EventHandler(this.USBHubButt_Click);
            // 
            // VideoContrButt
            // 
            this.VideoContrButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoContrButt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.VideoContrButt.Location = new System.Drawing.Point(3, 218);
            this.VideoContrButt.Name = "VideoContrButt";
            this.VideoContrButt.Size = new System.Drawing.Size(206, 37);
            this.VideoContrButt.TabIndex = 5;
            this.VideoContrButt.Text = "Видео контроллер";
            this.VideoContrButt.UseVisualStyleBackColor = true;
            this.VideoContrButt.Click += new System.EventHandler(this.VideoContrButt_Click);
            // 
            // LogicalDiskButt
            // 
            this.LogicalDiskButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogicalDiskButt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogicalDiskButt.Location = new System.Drawing.Point(3, 261);
            this.LogicalDiskButt.Name = "LogicalDiskButt";
            this.LogicalDiskButt.Size = new System.Drawing.Size(206, 37);
            this.LogicalDiskButt.TabIndex = 6;
            this.LogicalDiskButt.Text = "Накопители";
            this.LogicalDiskButt.UseVisualStyleBackColor = true;
            this.LogicalDiskButt.Click += new System.EventHandler(this.LogicalDiskButt_Click);
            // 
            // OperatingSysButt
            // 
            this.OperatingSysButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperatingSysButt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OperatingSysButt.Location = new System.Drawing.Point(3, 304);
            this.OperatingSysButt.Name = "OperatingSysButt";
            this.OperatingSysButt.Size = new System.Drawing.Size(206, 37);
            this.OperatingSysButt.TabIndex = 7;
            this.OperatingSysButt.Text = "Операционная система";
            this.OperatingSysButt.UseVisualStyleBackColor = true;
            this.OperatingSysButt.Click += new System.EventHandler(this.OperatingSysButt_Click);
            // 
            // UserAccButt
            // 
            this.UserAccButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserAccButt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UserAccButt.Location = new System.Drawing.Point(3, 347);
            this.UserAccButt.Name = "UserAccButt";
            this.UserAccButt.Size = new System.Drawing.Size(206, 37);
            this.UserAccButt.TabIndex = 8;
            this.UserAccButt.Text = "Пользователи";
            this.UserAccButt.UseVisualStyleBackColor = true;
            this.UserAccButt.Click += new System.EventHandler(this.UserAccButt_Click);
            // 
            // MonitorButt
            // 
            this.MonitorButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitorButt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MonitorButt.Location = new System.Drawing.Point(3, 390);
            this.MonitorButt.Name = "MonitorButt";
            this.MonitorButt.Size = new System.Drawing.Size(206, 42);
            this.MonitorButt.TabIndex = 9;
            this.MonitorButt.Text = "Монитор";
            this.MonitorButt.UseVisualStyleBackColor = true;
            this.MonitorButt.Click += new System.EventHandler(this.MonitorButt_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(221, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(521, 435);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // PrjForm
            // 
            this.ClientSize = new System.Drawing.Size(745, 487);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PrjForm";
            this.Text = "ProjectH";
            this.Load += new System.EventHandler(this.PrjForm_Load);
            this.Shown += new System.EventHandler(this.PrjForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void проВерсияToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("\"Про версия\" предназначена для продвинутых пользователей, " +
                "в ней содержится полная информация по ЭВС." +
                "\r\nПоказать всю базу данных?", "", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                dlgPsmBd dlgBdViev = new dlgPsmBd();
                dlgBdViev.Show();
            }

        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Запускаем поток обновления БД
            toolStripStatusLabel1.Text = "Обновление БД. Ждите...";
            Application.DoEvents();
               PTKH1 = new PotokH1();
            toolStripStatusLabel1.Text = "База данных обновлена ";
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
            Application.DoEvents();
            Thread.Sleep(10);

            MessageBox.Show("Процесс сборки и форматирования данных для анализа запущен!");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Программа \"ProjectH\" предназначена для сбора и анализа " +
                "критической информации по средствам опроса интерфейсов ЭВС. " +
                "Для обновления информации по ЭВС нажмите \"Обновить\". " +
                "\"Про версия\" предназначена для продвинутых пользователей, " +
                "в ней содержится полная информация по ЭВС. " +
                "", "", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strBoardConn;
            BoardConnectorInfo boardConnectorInfo = new BoardConnectorInfo();
            boardConnectorInfo.AppropriateInfo();

            strBoardConn = "";
            for (int i = 0; i < boardConnectorInfo.boardConnector.InternalDesignator.Count; i++)
            {
                strBoardConn += boardConnectorInfo.boardConnector.InternalDesignator.ElementAt(i) + "\r\n";
                strBoardConn += boardConnectorInfo.boardConnector.Tag.ElementAt(i) + "\r\n";
            }
            textBox1.Text = strBoardConn;

        }

        private void BIOSButt_Click(object sender, EventArgs e)
        {
            string strBios;
            BIOSInfo biosInfo = new BIOSInfo();
            biosInfo.AppropriateInfo();

            strBios = "";
            for (int i = 0; i < biosInfo.bios.Caption.Count; i++)
            {
                strBios += biosInfo.bios.Caption.ElementAt(i) + "\r\n";
                strBios += biosInfo.bios.Manufacturer.ElementAt(i) + "\r\n";
                strBios += biosInfo.bios.Status.ElementAt(i) + "\r\n";
            }
            textBox1.Text = strBios;
        }

        private void MotherboardButt_Click(object sender, EventArgs e)
        {
            string strMotherboard;
            MotherboardInfo motherboardInfo = new MotherboardInfo();
            motherboardInfo.AppropriateInfo();

            strMotherboard = "";
            for (int i = 0; i < motherboardInfo.motherboard.Description.Count; i++)
            {
                strMotherboard += motherboardInfo.motherboard.Manufacturer.ElementAt(i) + "\r\n";
                strMotherboard += motherboardInfo.motherboard.Product.ElementAt(i) + "\r\n";
                strMotherboard += motherboardInfo.motherboard.Description.ElementAt(i) + "\r\n";
                strMotherboard += motherboardInfo.motherboard.Status.ElementAt(i) + "\r\n";
            }
            textBox1.Text = strMotherboard;

        }

        private void ProcessorButt_Click(object sender, EventArgs e)
        {
            string strProcessor;
            ProcessorInfo processorInfo = new ProcessorInfo();
            processorInfo.AppropriateInfo();

            strProcessor = "";
            for (int i = 0; i < processorInfo.processor.Caption.Count; i++)
            {
                strProcessor += processorInfo.processor.Caption.ElementAt(i) + "\r\n";
                strProcessor += processorInfo.processor.Name.ElementAt(i) + "\r\n";
                strProcessor += processorInfo.processor.ID.ElementAt(i) + "\r\n";
                strProcessor += processorInfo.processor.Socket.ElementAt(i) + "\r\n";
                strProcessor += processorInfo.processor.BitCapacity.ElementAt(i) + "\r\n";
                strProcessor += processorInfo.processor.Cores.ElementAt(i) + "\r\n";
                strProcessor += processorInfo.processor.LogicalCore.ElementAt(i) + "\r\n";
                strProcessor += processorInfo.processor.Status.ElementAt(i) + "\r\n";
            }
            textBox1.Text = strProcessor;

        }

        private void USBHubButt_Click(object sender, EventArgs e)
        {
            string strUSBHub;
            USBHubInfo usbInfo = new USBHubInfo();
            usbInfo.AppropriateInfo();

            strUSBHub = "";
            for (int i = 0; i < usbInfo.usbHub.Caption.Count; i++)
            {
                strUSBHub += usbInfo.usbHub.Caption.ElementAt(i) + "\r\n";
                strUSBHub += usbInfo.usbHub.DeviceID.ElementAt(i) + "\r\n";
                strUSBHub += usbInfo.usbHub.Status.ElementAt(i) + "\r\n";
            }
            textBox1.Text = strUSBHub;

        }

        private void VideoContrButt_Click(object sender, EventArgs e)
        {
            string strVideoContr;
            VideoControllerInfo videoControllerInfo = new VideoControllerInfo();
            videoControllerInfo.AppropriateInfo();

            strVideoContr = "";
            for (int i = 0; i < videoControllerInfo.videoController.AdapterDACType.Count; i++)
            {
                strVideoContr += videoControllerInfo.videoController.AdapterDACType.ElementAt(i) + "\r\n";
                strVideoContr += videoControllerInfo.videoController.Name.ElementAt(i) + "\r\n";
                strVideoContr += videoControllerInfo.videoController.HorizontalResolution.ElementAt(i) + "\r\n";
                strVideoContr += videoControllerInfo.videoController.VerticalResolution.ElementAt(i) + "\r\n";
                strVideoContr += videoControllerInfo.videoController.RefreshRate.ElementAt(i) + "\r\n";
                strVideoContr += videoControllerInfo.videoController.DriverVersion.ElementAt(i) + "\r\n";
                strVideoContr += videoControllerInfo.videoController.InstalledDrivers.ElementAt(i) + "\r\n";
                strVideoContr += videoControllerInfo.videoController.Status.ElementAt(i) + "\r\n";
            }
            textBox1.Text = strVideoContr;

        }

        private void LogicalDiskButt_Click(object sender, EventArgs e)
        {
            string strLogicalDisk;
            LogicalDiskInfo logicalDiskInfo = new LogicalDiskInfo();
            logicalDiskInfo.AppropriateInfo();

            strLogicalDisk = "";
            for (int i = 0; i < logicalDiskInfo.logicalDisk.Name.Count; i++)
            {
                strLogicalDisk += logicalDiskInfo.logicalDisk.Name.ElementAt(i) + "\r\n";
                strLogicalDisk += logicalDiskInfo.logicalDisk.Description.ElementAt(i) + "\r\n";
                strLogicalDisk += logicalDiskInfo.logicalDisk.FileSystem.ElementAt(i) + "\r\n";
                strLogicalDisk += logicalDiskInfo.logicalDisk.FreeSpace.ElementAt(i) + "\r\n";
                strLogicalDisk += logicalDiskInfo.logicalDisk.FullSpace.ElementAt(i) + "\r\n";
            }
            textBox1.Text = strLogicalDisk;

        }

        private void OperatingSysButt_Click(object sender, EventArgs e)
        {
            string strOperatingSys;
            OperatingSystemInfo operatingSystemInfo = new OperatingSystemInfo();
            operatingSystemInfo.AppropriateInfo();

            strOperatingSys = "";
            for (int i = 0; i < operatingSystemInfo.operatingSystem.Caption.Count; i++)
            {
                strOperatingSys += operatingSystemInfo.operatingSystem.Caption.ElementAt(i) + "\r\n";
                strOperatingSys += operatingSystemInfo.operatingSystem.NumberOfProcesses.ElementAt(i) + "\r\n";
                strOperatingSys += operatingSystemInfo.operatingSystem.NumberOfUsers.ElementAt(i) + "\r\n";
                strOperatingSys += operatingSystemInfo.operatingSystem.OSArchitecture.ElementAt(i) + "\r\n";
                strOperatingSys += operatingSystemInfo.operatingSystem.User.ElementAt(i) + "\r\n";
                strOperatingSys += operatingSystemInfo.operatingSystem.Directory.ElementAt(i) + "\r\n";
                strOperatingSys += operatingSystemInfo.operatingSystem.Version.ElementAt(i) + "\r\n";
            }
            textBox1.Text = strOperatingSys;

        }

        private void UserAccButt_Click(object sender, EventArgs e)
        {
            string strUserAcc;
            UserAccountInfo userAccountInfo = new UserAccountInfo();
            userAccountInfo.AppropriateInfo();

            strUserAcc = "";
            for (int i = 0; i < userAccountInfo.userAccount.Description.Count; i++)
            {
                strUserAcc += userAccountInfo.userAccount.Description.ElementAt(i) + "\r\n";
                strUserAcc += userAccountInfo.userAccount.Name.ElementAt(i) + "\r\n";
                strUserAcc += userAccountInfo.userAccount.Status.ElementAt(i) + "\r\n";
            }
            textBox1.Text = strUserAcc;

        }

        private void MonitorButt_Click(object sender, EventArgs e)
        {
            string strMonitor;
            MonitorInfo monitorInfo = new MonitorInfo();
            monitorInfo.AppropriateInfo();

            strMonitor = "";
            for (int i = 0; i < monitorInfo.monitor.Caption.Count; i++)
            {
                strMonitor += monitorInfo.monitor.Caption.ElementAt(i) + "\r\n";
                strMonitor += monitorInfo.monitor.DeviceID.ElementAt(i) + "\r\n";
                strMonitor += monitorInfo.monitor.Status.ElementAt(i) + "\r\n";
            }
            textBox1.Text = strMonitor;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Закрытие потока при выходе.
            if (PTKH1 != null)
            {
                if (PTKH1.H1ptk.IsAlive)
                {
                    Thread.Sleep(50);
                    PTKH1.H1ptk.Interrupt();
                    PTKH1.H1ptk.Join();
                }
            }

            Application.Exit();
        }

        private void PrjForm_Shown(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //запус потока обновления по таймеру.
            toolStripStatusLabel1.Text = "...";
            Application.DoEvents();

            toolStripStatusLabel1.Text = "Обновление БД. Ждите...";
            Application.DoEvents();
                PTKH1 = new PotokH1();
            toolStripStatusLabel1.Text = "База данных обновлена ";
            toolStripStatusLabel2.Text =  DateTime.Now.ToString();
            Application.DoEvents();

        }

        private void PrjForm_Load(object sender, EventArgs e)
        {

            string strPrjH = "Добро пожаловать в \"ProjectH\"!" +
                "\r\nМы собирали и отформатировали необходимые данные по ЭВС." +
                "\r\nДля продолжения выберите один из пунктов слева, чтобы получить о нем информацию." +
                "\r\nОбновление базы данных происходит автоматически, если хотите обновить информацию принудительно, нажмите \"Обновить\".";

            textBox1.Text = strPrjH;

            //запус потока обновления по таймеру.
            toolStripStatusLabel1.Text = "...";
            Application.DoEvents();

            toolStripStatusLabel1.Text = "Обновление БД. Ждите...";
            Application.DoEvents();
            //запус потока обновления по таймеру.
            PTKH1 = new PotokH1();
            toolStripStatusLabel1.Text = "Вся информация собрана и отформатирована для анализа.";
            Application.DoEvents();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Формирование данных для экспорта json


        }
    }
}
