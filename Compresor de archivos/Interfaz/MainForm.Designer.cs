namespace Compresor_de_archivos.Interfaz
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpInputFiles = new GroupBox();
            btnClearFiles = new Button();
            btnAddFiles = new Button();
            listInputFiles = new ListBox();
            grpConfig = new GroupBox();
            rbDecompress = new RadioButton();
            rbCompress = new RadioButton();
            cmbAlgorithm = new ComboBox();
            label1 = new Label();
            grpOutput = new GroupBox();
            btnBrowseOutput = new Button();
            txtOutputFolder = new TextBox();
            grpExecute = new GroupBox();
            btnExit = new Button();
            btnRun = new Button();
            grpStats = new GroupBox();
            txtLog = new RichTextBox();
            progressBar = new ProgressBar();
            lblRatio = new Label();
            lblMemory = new Label();
            lblTime = new Label();
            grpInputFiles.SuspendLayout();
            grpConfig.SuspendLayout();
            grpOutput.SuspendLayout();
            grpExecute.SuspendLayout();
            grpStats.SuspendLayout();
            SuspendLayout();
            // 
            // grpInputFiles
            // 
            grpInputFiles.Controls.Add(btnClearFiles);
            grpInputFiles.Controls.Add(btnAddFiles);
            grpInputFiles.Controls.Add(listInputFiles);
            grpInputFiles.Location = new Point(20, 20);
            grpInputFiles.Name = "grpInputFiles";
            grpInputFiles.Size = new Size(400, 250);
            grpInputFiles.TabIndex = 0;
            grpInputFiles.TabStop = false;
            grpInputFiles.Text = "Arrastre el archivo aquí";
            // 
            // btnClearFiles
            // 
            btnClearFiles.Location = new Point(200, 190);
            btnClearFiles.Name = "btnClearFiles";
            btnClearFiles.Size = new Size(150, 30);
            btnClearFiles.TabIndex = 2;
            btnClearFiles.Text = " Limpiar Data";
            btnClearFiles.UseVisualStyleBackColor = true;
            // 
            // btnAddFiles
            // 
            btnAddFiles.Location = new Point(20, 190);
            btnAddFiles.Name = "btnAddFiles";
            btnAddFiles.Size = new Size(150, 30);
            btnAddFiles.TabIndex = 1;
            btnAddFiles.Text = "Subir Archivo";
            btnAddFiles.UseVisualStyleBackColor = true;
            // 
            // listInputFiles
            // 
            listInputFiles.FormattingEnabled = true;
            listInputFiles.ItemHeight = 15;
            listInputFiles.Location = new Point(20, 30);
            listInputFiles.Name = "listInputFiles";
            listInputFiles.Size = new Size(360, 139);
            listInputFiles.TabIndex = 0;
            // 
            // grpConfig
            // 
            grpConfig.Controls.Add(rbDecompress);
            grpConfig.Controls.Add(rbCompress);
            grpConfig.Controls.Add(cmbAlgorithm);
            grpConfig.Controls.Add(label1);
            grpConfig.Location = new Point(20, 276);
            grpConfig.Name = "grpConfig";
            grpConfig.Size = new Size(400, 150);
            grpConfig.TabIndex = 1;
            grpConfig.TabStop = false;
            grpConfig.Text = "Cofiguracion";
            // 
            // rbDecompress
            // 
            rbDecompress.AutoSize = true;
            rbDecompress.Location = new Point(208, 69);
            rbDecompress.Name = "rbDecompress";
            rbDecompress.Size = new Size(89, 19);
            rbDecompress.TabIndex = 3;
            rbDecompress.Text = "Descoprimir";
            rbDecompress.UseVisualStyleBackColor = true;
            // 
            // rbCompress
            // 
            rbCompress.AutoSize = true;
            rbCompress.Checked = true;
            rbCompress.Location = new Point(20, 70);
            rbCompress.Name = "rbCompress";
            rbCompress.Size = new Size(83, 19);
            rbCompress.TabIndex = 2;
            rbCompress.TabStop = true;
            rbCompress.Text = "Comprimir";
            rbCompress.UseVisualStyleBackColor = true;
            // 
            // cmbAlgorithm
            // 
            cmbAlgorithm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlgorithm.FormattingEnabled = true;
            cmbAlgorithm.Location = new Point(120, 28);
            cmbAlgorithm.Name = "cmbAlgorithm";
            cmbAlgorithm.Size = new Size(200, 23);
            cmbAlgorithm.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 24);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Algoritmo";
            // 
            // grpOutput
            // 
            grpOutput.Controls.Add(btnBrowseOutput);
            grpOutput.Controls.Add(txtOutputFolder);
            grpOutput.Location = new Point(20, 450);
            grpOutput.Name = "grpOutput";
            grpOutput.Size = new Size(400, 100);
            grpOutput.TabIndex = 2;
            grpOutput.TabStop = false;
            grpOutput.Text = "Carpeta de salida";
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.Location = new Point(290, 30);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new Size(75, 23);
            btnBrowseOutput.TabIndex = 1;
            btnBrowseOutput.Text = "Cambiar";
            btnBrowseOutput.UseVisualStyleBackColor = true;
            // 
            // txtOutputFolder
            // 
            txtOutputFolder.Location = new Point(20, 30);
            txtOutputFolder.Name = "txtOutputFolder";
            txtOutputFolder.ReadOnly = true;
            txtOutputFolder.Size = new Size(260, 23);
            txtOutputFolder.TabIndex = 0;
            // 
            // grpExecute
            // 
            grpExecute.Controls.Add(btnExit);
            grpExecute.Controls.Add(btnRun);
            grpExecute.Location = new Point(442, 20);
            grpExecute.Name = "grpExecute";
            grpExecute.Size = new Size(430, 120);
            grpExecute.TabIndex = 3;
            grpExecute.TabStop = false;
            grpExecute.Text = "Ejecucion";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(200, 30);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(150, 40);
            btnExit.TabIndex = 1;
            btnExit.Text = "salir";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(30, 30);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(150, 40);
            btnRun.TabIndex = 0;
            btnRun.Text = "Ejecutar";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnEjecutar_Click;
            // 
            // grpStats
            // 
            grpStats.Controls.Add(txtLog);
            grpStats.Controls.Add(progressBar);
            grpStats.Controls.Add(lblRatio);
            grpStats.Controls.Add(lblMemory);
            grpStats.Controls.Add(lblTime);
            grpStats.Location = new Point(442, 199);
            grpStats.Name = "grpStats";
            grpStats.Size = new Size(430, 350);
            grpStats.TabIndex = 4;
            grpStats.TabStop = false;
            grpStats.Text = "Stats";
            // 
            // txtLog
            // 
            txtLog.Location = new Point(20, 170);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new Size(380, 150);
            txtLog.TabIndex = 4;
            txtLog.Text = "";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(20, 130);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(380, 25);
            progressBar.TabIndex = 3;
            // 
            // lblRatio
            // 
            lblRatio.AutoSize = true;
            lblRatio.Location = new Point(20, 90);
            lblRatio.Name = "lblRatio";
            lblRatio.Size = new Size(123, 15);
            lblRatio.TabIndex = 2;
            lblRatio.Text = "Tasa de compresion: -";
            // 
            // lblMemory
            // 
            lblMemory.AutoSize = true;
            lblMemory.Location = new Point(20, 60);
            lblMemory.Name = "lblMemory";
            lblMemory.Size = new Size(66, 15);
            lblMemory.TabIndex = 1;
            lblMemory.Text = "Memoria: -";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(20, 30);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(48, 15);
            lblTime.TabIndex = 0;
            lblTime.Text = "Tiempo";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(grpStats);
            Controls.Add(grpExecute);
            Controls.Add(grpOutput);
            Controls.Add(grpConfig);
            Controls.Add(grpInputFiles);
            Name = "MainForm";
            Text = "Compresor de Archivos";
            Load += Form1_Load;
            grpInputFiles.ResumeLayout(false);
            grpConfig.ResumeLayout(false);
            grpConfig.PerformLayout();
            grpOutput.ResumeLayout(false);
            grpOutput.PerformLayout();
            grpExecute.ResumeLayout(false);
            grpStats.ResumeLayout(false);
            grpStats.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpInputFiles;
        private ListBox listInputFiles;
        private GroupBox grpConfig;
        private Button btnAddFiles;
        private Button btnClearFiles;
        private Label label1;
        private ComboBox cmbAlgorithm;
        private RadioButton rbCompress;
        private RadioButton rbDecompress;
        private GroupBox grpOutput;
        private Button btnBrowseOutput;
        private TextBox txtOutputFolder;
        private GroupBox grpExecute;
        private Button btnRun;
        private Button btnExit;
        private GroupBox grpStats;
        private Label lblMemory;
        private Label lblTime;
        private Label lblRatio;
        private ProgressBar progressBar;
        private RichTextBox txtLog;
    }
}
