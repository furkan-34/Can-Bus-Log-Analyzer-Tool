namespace analyzer
{
    partial class filter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(filter));
            this.parChList = new System.Windows.Forms.CheckedListBox();
            this.btnParRef = new System.Windows.Forms.Button();
            this.btnNewPar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chTime = new System.Windows.Forms.CheckBox();
            this.chRaw = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtZamBit = new System.Windows.Forms.TextBox();
            this.txtZamBas = new System.Windows.Forms.TextBox();
            this.txtSatBit = new System.Windows.Forms.TextBox();
            this.txtSatBas = new System.Windows.Forms.TextBox();
            this.btnAxisC = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.zoomScrool = new System.Windows.Forms.HScrollBar();
            this.txtNewPro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveGra = new System.Windows.Forms.Button();
            this.btnFixPar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCiz = new System.Windows.Forms.Button();
            this.btnProDel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNewPro = new System.Windows.Forms.Button();
            this.btnParDel = new System.Windows.Forms.Button();
            this.cbProfil = new System.Windows.Forms.ComboBox();
            this.btnIntPlus = new System.Windows.Forms.Button();
            this.btnZoomKapa = new System.Windows.Forms.Button();
            this.btnFileSec = new System.Windows.Forms.Button();
            this.btnZoomAktif = new System.Windows.Forms.Button();
            this.resultDG = new System.Windows.Forms.DataGridView();
            this.grafikTool = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSeciliPar = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafikTool)).BeginInit();
            this.SuspendLayout();
            // 
            // parChList
            // 
            this.parChList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.parChList.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.parChList.FormattingEnabled = true;
            this.parChList.Location = new System.Drawing.Point(12, 176);
            this.parChList.Name = "parChList";
            this.parChList.Size = new System.Drawing.Size(156, 436);
            this.parChList.TabIndex = 24;
            this.parChList.Click += new System.EventHandler(this.ParChList_Click);
            this.parChList.SelectedIndexChanged += new System.EventHandler(this.ParChList_SelectedIndexChanged);
            this.parChList.DoubleClick += new System.EventHandler(this.ParChList_DoubleClick);
            // 
            // btnParRef
            // 
            this.btnParRef.Location = new System.Drawing.Point(8, 41);
            this.btnParRef.Name = "btnParRef";
            this.btnParRef.Size = new System.Drawing.Size(56, 23);
            this.btnParRef.TabIndex = 29;
            this.btnParRef.Text = "Yenile";
            this.btnParRef.UseVisualStyleBackColor = true;
            this.btnParRef.Click += new System.EventHandler(this.BtnParRef_Click);
            // 
            // btnNewPar
            // 
            this.btnNewPar.Location = new System.Drawing.Point(70, 41);
            this.btnNewPar.Name = "btnNewPar";
            this.btnNewPar.Size = new System.Drawing.Size(93, 23);
            this.btnNewPar.TabIndex = 30;
            this.btnNewPar.Text = "Parametre Ekle";
            this.btnNewPar.UseVisualStyleBackColor = true;
            this.btnNewPar.Click += new System.EventHandler(this.BtnNewPar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(10, 8);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(158, 23);
            this.progBar.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.chTime);
            this.panel1.Controls.Add(this.chRaw);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtZamBit);
            this.panel1.Controls.Add(this.txtZamBas);
            this.panel1.Controls.Add(this.txtSatBit);
            this.panel1.Controls.Add(this.txtSatBas);
            this.panel1.Controls.Add(this.btnAxisC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 620);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1193, 43);
            this.panel1.TabIndex = 35;
            // 
            // chTime
            // 
            this.chTime.AutoSize = true;
            this.chTime.Location = new System.Drawing.Point(682, 16);
            this.chTime.Name = "chTime";
            this.chTime.Size = new System.Drawing.Size(15, 14);
            this.chTime.TabIndex = 46;
            this.chTime.UseVisualStyleBackColor = true;
            this.chTime.Click += new System.EventHandler(this.ChTime_Click);
            // 
            // chRaw
            // 
            this.chRaw.AutoSize = true;
            this.chRaw.Location = new System.Drawing.Point(262, 14);
            this.chRaw.Name = "chRaw";
            this.chRaw.Size = new System.Drawing.Size(15, 14);
            this.chRaw.TabIndex = 39;
            this.chRaw.UseVisualStyleBackColor = true;
            this.chRaw.Click += new System.EventHandler(this.ChRaw_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(698, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 14);
            this.label3.TabIndex = 44;
            this.label3.Text = "Zaman Başlangıç-Bitiş (sn) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(284, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 14);
            this.label2.TabIndex = 39;
            this.label2.Text = "Satır Başlangıç-Bitiş:";
            // 
            // txtZamBit
            // 
            this.txtZamBit.Location = new System.Drawing.Point(982, 13);
            this.txtZamBit.Name = "txtZamBit";
            this.txtZamBit.Size = new System.Drawing.Size(75, 20);
            this.txtZamBit.TabIndex = 43;
            this.txtZamBit.Text = "0";
            this.txtZamBit.TextChanged += new System.EventHandler(this.TxtZamBit_TextChanged);
            this.txtZamBit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtZamBit_KeyPress);
            // 
            // txtZamBas
            // 
            this.txtZamBas.Location = new System.Drawing.Point(894, 13);
            this.txtZamBas.Name = "txtZamBas";
            this.txtZamBas.Size = new System.Drawing.Size(82, 20);
            this.txtZamBas.TabIndex = 42;
            this.txtZamBas.Text = "0";
            this.txtZamBas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtZamBas_KeyPress);
            // 
            // txtSatBit
            // 
            this.txtSatBit.Location = new System.Drawing.Point(534, 13);
            this.txtSatBit.Name = "txtSatBit";
            this.txtSatBit.Size = new System.Drawing.Size(92, 20);
            this.txtSatBit.TabIndex = 41;
            this.txtSatBit.Text = "0";
            this.txtSatBit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSatBit_KeyPress);
            // 
            // txtSatBas
            // 
            this.txtSatBas.Location = new System.Drawing.Point(437, 12);
            this.txtSatBas.Name = "txtSatBas";
            this.txtSatBas.Size = new System.Drawing.Size(91, 20);
            this.txtSatBas.TabIndex = 39;
            this.txtSatBas.Text = "0";
            this.txtSatBas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSatBas_KeyPress);
            // 
            // btnAxisC
            // 
            this.btnAxisC.BackColor = System.Drawing.SystemColors.Control;
            this.btnAxisC.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAxisC.ForeColor = System.Drawing.Color.Red;
            this.btnAxisC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAxisC.Location = new System.Drawing.Point(10, 7);
            this.btnAxisC.Name = "btnAxisC";
            this.btnAxisC.Size = new System.Drawing.Size(231, 30);
            this.btnAxisC.TabIndex = 40;
            this.btnAxisC.Text = "Eksen Değiştir";
            this.btnAxisC.UseVisualStyleBackColor = false;
            this.btnAxisC.Click += new System.EventHandler(this.BtnAxisC_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.zoomScrool);
            this.panel2.Controls.Add(this.txtNewPro);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnSaveGra);
            this.panel2.Controls.Add(this.btnFixPar);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.btnCiz);
            this.panel2.Controls.Add(this.btnProDel);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnNewPro);
            this.panel2.Controls.Add(this.btnParDel);
            this.panel2.Controls.Add(this.cbProfil);
            this.panel2.Controls.Add(this.btnIntPlus);
            this.panel2.Controls.Add(this.progBar);
            this.panel2.Controls.Add(this.btnZoomKapa);
            this.panel2.Controls.Add(this.btnFileSec);
            this.panel2.Controls.Add(this.btnZoomAktif);
            this.panel2.Controls.Add(this.btnParRef);
            this.panel2.Controls.Add(this.btnNewPar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1193, 100);
            this.panel2.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(665, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 49;
            // 
            // zoomScrool
            // 
            this.zoomScrool.LargeChange = 1;
            this.zoomScrool.Location = new System.Drawing.Point(417, 67);
            this.zoomScrool.Name = "zoomScrool";
            this.zoomScrool.Size = new System.Drawing.Size(239, 20);
            this.zoomScrool.TabIndex = 48;
            this.zoomScrool.ValueChanged += new System.EventHandler(this.ZoomScrool_ValueChanged);
            // 
            // txtNewPro
            // 
            this.txtNewPro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPro.Location = new System.Drawing.Point(742, 10);
            this.txtNewPro.Name = "txtNewPro";
            this.txtNewPro.Size = new System.Drawing.Size(122, 20);
            this.txtNewPro.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(419, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Profil:";
            // 
            // btnSaveGra
            // 
            this.btnSaveGra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveGra.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSaveGra.ForeColor = System.Drawing.Color.Red;
            this.btnSaveGra.Image = global::analyzer.Properties.Resources.VSProject_imagefile;
            this.btnSaveGra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveGra.Location = new System.Drawing.Point(1004, 41);
            this.btnSaveGra.Name = "btnSaveGra";
            this.btnSaveGra.Size = new System.Drawing.Size(131, 23);
            this.btnSaveGra.TabIndex = 47;
            this.btnSaveGra.Text = "Grafik Kayıt";
            this.btnSaveGra.UseVisualStyleBackColor = true;
            this.btnSaveGra.Click += new System.EventHandler(this.BtnSaveGra_Click);
            // 
            // btnFixPar
            // 
            this.btnFixPar.Location = new System.Drawing.Point(278, 41);
            this.btnFixPar.Name = "btnFixPar";
            this.btnFixPar.Size = new System.Drawing.Size(108, 23);
            this.btnFixPar.TabIndex = 46;
            this.btnFixPar.Text = "Parametre Düzelt";
            this.btnFixPar.UseVisualStyleBackColor = true;
            this.btnFixPar.Click += new System.EventHandler(this.BtnFixPar_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Image = global::analyzer.Properties.Resources.save_16xMD;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(1004, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 30);
            this.button3.TabIndex = 39;
            this.button3.Text = "Kaydet";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // btnCiz
            // 
            this.btnCiz.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCiz.ForeColor = System.Drawing.Color.Red;
            this.btnCiz.Image = global::analyzer.Properties.Resources.PencilTool_206;
            this.btnCiz.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCiz.Location = new System.Drawing.Point(324, 8);
            this.btnCiz.Name = "btnCiz";
            this.btnCiz.Size = new System.Drawing.Size(89, 23);
            this.btnCiz.TabIndex = 31;
            this.btnCiz.Text = "Çiz";
            this.btnCiz.UseVisualStyleBackColor = true;
            this.btnCiz.Click += new System.EventHandler(this.BtnCiz_Click);
            // 
            // btnProDel
            // 
            this.btnProDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProDel.BackColor = System.Drawing.SystemColors.Control;
            this.btnProDel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProDel.ForeColor = System.Drawing.Color.Red;
            this.btnProDel.Image = global::analyzer.Properties.Resources.delete_12x12;
            this.btnProDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProDel.Location = new System.Drawing.Point(625, 5);
            this.btnProDel.Name = "btnProDel";
            this.btnProDel.Size = new System.Drawing.Size(111, 30);
            this.btnProDel.TabIndex = 38;
            this.btnProDel.Text = "Profili Sil";
            this.btnProDel.UseVisualStyleBackColor = false;
            this.btnProDel.Click += new System.EventHandler(this.BtnProDel_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(846, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 44;
            this.button1.Text = "Sıklık Azalt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnNewPro
            // 
            this.btnNewPro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewPro.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewPro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNewPro.ForeColor = System.Drawing.Color.Red;
            this.btnNewPro.Image = global::analyzer.Properties.Resources._112_Plus_Blue_16x16_72;
            this.btnNewPro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewPro.Location = new System.Drawing.Point(873, 5);
            this.btnNewPro.Name = "btnNewPro";
            this.btnNewPro.Size = new System.Drawing.Size(125, 30);
            this.btnNewPro.TabIndex = 37;
            this.btnNewPro.Text = "Yeni Profil";
            this.btnNewPro.UseVisualStyleBackColor = false;
            this.btnNewPro.Click += new System.EventHandler(this.BtnNewPro_Click);
            // 
            // btnParDel
            // 
            this.btnParDel.Location = new System.Drawing.Point(172, 41);
            this.btnParDel.Name = "btnParDel";
            this.btnParDel.Size = new System.Drawing.Size(100, 23);
            this.btnParDel.TabIndex = 43;
            this.btnParDel.Text = "Parametre Sil";
            this.btnParDel.UseVisualStyleBackColor = true;
            this.btnParDel.Click += new System.EventHandler(this.BtnParDel_Click);
            // 
            // cbProfil
            // 
            this.cbProfil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfil.FormattingEnabled = true;
            this.cbProfil.Location = new System.Drawing.Point(478, 10);
            this.cbProfil.Name = "cbProfil";
            this.cbProfil.Size = new System.Drawing.Size(141, 21);
            this.cbProfil.TabIndex = 37;
            this.cbProfil.SelectedIndexChanged += new System.EventHandler(this.CbProfil_SelectedIndexChanged);
            // 
            // btnIntPlus
            // 
            this.btnIntPlus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIntPlus.ForeColor = System.Drawing.Color.Red;
            this.btnIntPlus.Location = new System.Drawing.Point(696, 41);
            this.btnIntPlus.Name = "btnIntPlus";
            this.btnIntPlus.Size = new System.Drawing.Size(131, 23);
            this.btnIntPlus.TabIndex = 42;
            this.btnIntPlus.Text = "Sıklık Arttır";
            this.btnIntPlus.UseVisualStyleBackColor = true;
            this.btnIntPlus.Click += new System.EventHandler(this.BtnIntPlus_Click);
            // 
            // btnZoomKapa
            // 
            this.btnZoomKapa.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnZoomKapa.ForeColor = System.Drawing.Color.Red;
            this.btnZoomKapa.Image = global::analyzer.Properties.Resources.ZoomOut_12927;
            this.btnZoomKapa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZoomKapa.Location = new System.Drawing.Point(542, 41);
            this.btnZoomKapa.Name = "btnZoomKapa";
            this.btnZoomKapa.Size = new System.Drawing.Size(119, 23);
            this.btnZoomKapa.TabIndex = 41;
            this.btnZoomKapa.Text = "Zoom Kapat";
            this.btnZoomKapa.UseVisualStyleBackColor = true;
            this.btnZoomKapa.Click += new System.EventHandler(this.BtnZoomKapa_Click);
            // 
            // btnFileSec
            // 
            this.btnFileSec.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFileSec.ForeColor = System.Drawing.Color.Red;
            this.btnFileSec.Image = global::analyzer.Properties.Resources.folder_Open_16xLG;
            this.btnFileSec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFileSec.Location = new System.Drawing.Point(190, 7);
            this.btnFileSec.Name = "btnFileSec";
            this.btnFileSec.Size = new System.Drawing.Size(128, 23);
            this.btnFileSec.TabIndex = 32;
            this.btnFileSec.Text = "Dosya Seç";
            this.btnFileSec.UseVisualStyleBackColor = true;
            this.btnFileSec.Click += new System.EventHandler(this.BtnFileSec_Click);
            // 
            // btnZoomAktif
            // 
            this.btnZoomAktif.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnZoomAktif.ForeColor = System.Drawing.Color.Red;
            this.btnZoomAktif.Image = global::analyzer.Properties.Resources.Zoom_5442;
            this.btnZoomAktif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZoomAktif.Location = new System.Drawing.Point(417, 41);
            this.btnZoomAktif.Name = "btnZoomAktif";
            this.btnZoomAktif.Size = new System.Drawing.Size(119, 23);
            this.btnZoomAktif.TabIndex = 40;
            this.btnZoomAktif.Text = "Zoom Aktif";
            this.btnZoomAktif.UseVisualStyleBackColor = true;
            this.btnZoomAktif.Click += new System.EventHandler(this.BtnZoomAktif_Click);
            // 
            // resultDG
            // 
            this.resultDG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.resultDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDG.Location = new System.Drawing.Point(1004, 106);
            this.resultDG.Name = "resultDG";
            this.resultDG.Size = new System.Drawing.Size(177, 508);
            this.resultDG.TabIndex = 37;
            // 
            // grafikTool
            // 
            this.grafikTool.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.grafikTool.ChartAreas.Add(chartArea1);
            this.grafikTool.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            legend1.Name = "Legend1";
            this.grafikTool.Legends.Add(legend1);
            this.grafikTool.Location = new System.Drawing.Point(174, 106);
            this.grafikTool.Name = "grafikTool";
            this.grafikTool.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.grafikTool.Series.Add(series1);
            this.grafikTool.Size = new System.Drawing.Size(824, 508);
            this.grafikTool.TabIndex = 0;
            this.grafikTool.Text = "chart1";
            this.grafikTool.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GrafikTool_KeyPress);
            this.grafikTool.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GrafikTool_KeyUp);
            this.grafikTool.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GrafikTool_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(7, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 44;
            this.label4.Text = "Par. Ad:";
            // 
            // lblSeciliPar
            // 
            this.lblSeciliPar.AutoSize = true;
            this.lblSeciliPar.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSeciliPar.Location = new System.Drawing.Point(57, 155);
            this.lblSeciliPar.Name = "lblSeciliPar";
            this.lblSeciliPar.Size = new System.Drawing.Size(0, 14);
            this.lblSeciliPar.TabIndex = 45;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFileName.Location = new System.Drawing.Point(12, 123);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 13);
            this.lblFileName.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(48, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 48;
            this.label6.Text = "DOSYA ADI";
            // 
            // filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 663);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblSeciliPar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grafikTool);
            this.Controls.Add(this.resultDG);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.parChList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "filter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAN-BUS LOG ANALYZE TOOL";
            this.Load += new System.EventHandler(this.Filter_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafikTool)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNewPar;
        private System.Windows.Forms.Button btnCiz;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnFileSec;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnParRef;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnProDel;
        private System.Windows.Forms.Button btnNewPro;
        private System.Windows.Forms.ComboBox cbProfil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView resultDG;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafikTool;
        private System.Windows.Forms.Button btnAxisC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtZamBit;
        private System.Windows.Forms.TextBox txtZamBas;
        private System.Windows.Forms.TextBox txtSatBit;
        private System.Windows.Forms.TextBox txtSatBas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chTime;
        private System.Windows.Forms.CheckBox chRaw;
        private System.Windows.Forms.Button btnZoomAktif;
        private System.Windows.Forms.Button btnZoomKapa;
        private System.Windows.Forms.Button btnIntPlus;
        private System.Windows.Forms.TextBox txtNewPro;
        private System.Windows.Forms.Button btnParDel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSeciliPar;
        public  System.Windows.Forms.CheckedListBox parChList;
        private System.Windows.Forms.Button btnFixPar;
        private System.Windows.Forms.Button btnSaveGra;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.HScrollBar zoomScrool;
        private System.Windows.Forms.Label label5;
    }
}

