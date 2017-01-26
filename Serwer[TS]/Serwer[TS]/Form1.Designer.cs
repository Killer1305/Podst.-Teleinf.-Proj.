namespace Serwer_TS_
{
    partial class Form1
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
            this.Text_IP = new System.Windows.Forms.TextBox();
            this.Label_IP = new System.Windows.Forms.Label();
            this.Label_port = new System.Windows.Forms.Label();
            this.Numer_port = new System.Windows.Forms.NumericUpDown();
            this.Start_button = new System.Windows.Forms.Button();
            this.Stop_button = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.oczekiwanie_na_polaczenie = new System.ComponentModel.BackgroundWorker();
            this.odczytywanie_wiadomosci_od_klienta = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.Numer_port)).BeginInit();
            this.SuspendLayout();
            // 
            // Text_IP
            // 
            this.Text_IP.Location = new System.Drawing.Point(73, 15);
            this.Text_IP.Margin = new System.Windows.Forms.Padding(4);
            this.Text_IP.Name = "Text_IP";
            this.Text_IP.Size = new System.Drawing.Size(153, 22);
            this.Text_IP.TabIndex = 0;
            // 
            // Label_IP
            // 
            this.Label_IP.AutoSize = true;
            this.Label_IP.Location = new System.Drawing.Point(3, 18);
            this.Label_IP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_IP.Name = "Label_IP";
            this.Label_IP.Size = new System.Drawing.Size(69, 17);
            this.Label_IP.TabIndex = 1;
            this.Label_IP.Text = "Adres IP: ";
            // 
            // Label_port
            // 
            this.Label_port.AutoSize = true;
            this.Label_port.Location = new System.Drawing.Point(236, 18);
            this.Label_port.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_port.Name = "Label_port";
            this.Label_port.Size = new System.Drawing.Size(42, 17);
            this.Label_port.TabIndex = 8;
            this.Label_port.Text = "Port: ";
            // 
            // Numer_port
            // 
            this.Numer_port.Location = new System.Drawing.Point(275, 16);
            this.Numer_port.Margin = new System.Windows.Forms.Padding(4);
            this.Numer_port.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Numer_port.Name = "Numer_port";
            this.Numer_port.Size = new System.Drawing.Size(61, 22);
            this.Numer_port.TabIndex = 9;
            this.Numer_port.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // Start_button
            // 
            this.Start_button.Location = new System.Drawing.Point(45, 278);
            this.Start_button.Margin = new System.Windows.Forms.Padding(4);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(100, 28);
            this.Start_button.TabIndex = 15;
            this.Start_button.Text = "Start";
            this.Start_button.UseVisualStyleBackColor = true;
            this.Start_button.Click += new System.EventHandler(this.start_Click);
            // 
            // Stop_button
            // 
            this.Stop_button.Location = new System.Drawing.Point(201, 278);
            this.Stop_button.Margin = new System.Windows.Forms.Padding(4);
            this.Stop_button.Name = "Stop_button";
            this.Stop_button.Size = new System.Drawing.Size(100, 28);
            this.Stop_button.TabIndex = 16;
            this.Stop_button.Text = "Stop";
            this.Stop_button.UseVisualStyleBackColor = true;
            this.Stop_button.Click += new System.EventHandler(this.stop_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(16, 63);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(331, 196);
            this.listBox1.TabIndex = 17;
            // 
            // oczekiwanie_na_polaczenie
            // 
            this.oczekiwanie_na_polaczenie.DoWork += new System.ComponentModel.DoWorkEventHandler(this.oczekiwanie_na_polaczenie_DoWork);
            // 
            // odczytywanie_wiadomosci_od_klienta
            // 
            this.odczytywanie_wiadomosci_od_klienta.DoWork += new System.ComponentModel.DoWorkEventHandler(this.odczytywanie_wiadomosci_od_klienta_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Stop_button);
            this.Controls.Add(this.Start_button);
            this.Controls.Add(this.Numer_port);
            this.Controls.Add(this.Label_port);
            this.Controls.Add(this.Label_IP);
            this.Controls.Add(this.Text_IP);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Połączenie TCP - serwer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Numer_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Text_IP;
        private System.Windows.Forms.Label Label_IP;
        private System.Windows.Forms.Label Label_port;
        private System.Windows.Forms.NumericUpDown Numer_port;
        private System.Windows.Forms.Button Start_button;
        private System.Windows.Forms.Button Stop_button;
        private System.Windows.Forms.ListBox listBox1;
        private System.ComponentModel.BackgroundWorker oczekiwanie_na_polaczenie;
        private System.ComponentModel.BackgroundWorker odczytywanie_wiadomosci_od_klienta;
    }
}

