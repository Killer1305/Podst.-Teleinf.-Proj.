﻿namespace Klient_TS_
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
            this.Send_Login = new System.Windows.Forms.Button();
            this.Send_Password = new System.Windows.Forms.Button();
            this.Text_Login = new System.Windows.Forms.TextBox();
            this.Text_password = new System.Windows.Forms.TextBox();
            this.Label_Login = new System.Windows.Forms.Label();
            this.Label_Password = new System.Windows.Forms.Label();
            this.Label_port = new System.Windows.Forms.Label();
            this.Numer_port = new System.Windows.Forms.NumericUpDown();
            this.polacz_button = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.nawiazanie_polaczenia_z_serwerem = new System.ComponentModel.BackgroundWorker();
            this.odczytanie_wiadomosc_z_serwera = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.Numer_port)).BeginInit();
            this.SuspendLayout();
            // 
            // Text_IP
            // 
            this.Text_IP.Location = new System.Drawing.Point(73, 15);
            this.Text_IP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            // Send_Login
            // 
            this.Send_Login.Location = new System.Drawing.Point(248, 60);
            this.Send_Login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Send_Login.Name = "Send_Login";
            this.Send_Login.Size = new System.Drawing.Size(100, 28);
            this.Send_Login.TabIndex = 2;
            this.Send_Login.Text = "Wyślij login";
            this.Send_Login.UseVisualStyleBackColor = true;
            this.Send_Login.Click += new System.EventHandler(this.login_click);
            // 
            // Send_Password
            // 
            this.Send_Password.Location = new System.Drawing.Point(248, 92);
            this.Send_Password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Send_Password.Name = "Send_Password";
            this.Send_Password.Size = new System.Drawing.Size(100, 28);
            this.Send_Password.TabIndex = 3;
            this.Send_Password.Text = "Wyślij hasło";
            this.Send_Password.UseVisualStyleBackColor = true;
            this.Send_Password.Click += new System.EventHandler(this.passwd_click);
            // 
            // Text_Login
            // 
            this.Text_Login.Location = new System.Drawing.Point(73, 63);
            this.Text_Login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Text_Login.Name = "Text_Login";
            this.Text_Login.Size = new System.Drawing.Size(165, 22);
            this.Text_Login.TabIndex = 4;
            // 
            // Text_password
            // 
            this.Text_password.Location = new System.Drawing.Point(73, 95);
            this.Text_password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Text_password.Name = "Text_password";
            this.Text_password.PasswordChar = '*';
            this.Text_password.Size = new System.Drawing.Size(165, 22);
            this.Text_password.TabIndex = 5;
            // 
            // Label_Login
            // 
            this.Label_Login.AutoSize = true;
            this.Label_Login.Location = new System.Drawing.Point(16, 66);
            this.Label_Login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Login.Name = "Label_Login";
            this.Label_Login.Size = new System.Drawing.Size(47, 17);
            this.Label_Login.TabIndex = 6;
            this.Label_Login.Text = "Login:";
            // 
            // Label_Password
            // 
            this.Label_Password.AutoSize = true;
            this.Label_Password.Location = new System.Drawing.Point(16, 98);
            this.Label_Password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Password.Name = "Label_Password";
            this.Label_Password.Size = new System.Drawing.Size(52, 17);
            this.Label_Password.TabIndex = 7;
            this.Label_Password.Text = "Hasło: ";
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
            this.Numer_port.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            // polacz_button
            // 
            this.polacz_button.Location = new System.Drawing.Point(128, 278);
            this.polacz_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.polacz_button.Name = "polacz_button";
            this.polacz_button.Size = new System.Drawing.Size(100, 28);
            this.polacz_button.TabIndex = 15;
            this.polacz_button.Text = "Połącz";
            this.polacz_button.UseVisualStyleBackColor = true;
            this.polacz_button.Click += new System.EventHandler(this.polacz_click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(16, 127);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(331, 132);
            this.listBox1.TabIndex = 17;
            // 
            // nawiazanie_polaczenia_z_serwerem
            // 
            this.nawiazanie_polaczenia_z_serwerem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.nawiazanie_polaczenia_z_serwerem_DoWork);
            // 
            // odczytanie_wiadomosc_z_serwera
            // 
            this.odczytanie_wiadomosc_z_serwera.DoWork += new System.ComponentModel.DoWorkEventHandler(this.odczytanie_wiadomosc_z_serwera_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.polacz_button);
            this.Controls.Add(this.Numer_port);
            this.Controls.Add(this.Label_port);
            this.Controls.Add(this.Label_Password);
            this.Controls.Add(this.Label_Login);
            this.Controls.Add(this.Text_password);
            this.Controls.Add(this.Text_Login);
            this.Controls.Add(this.Send_Password);
            this.Controls.Add(this.Send_Login);
            this.Controls.Add(this.Label_IP);
            this.Controls.Add(this.Text_IP);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Połączenie TCP - klient";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Numer_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Text_IP;
        private System.Windows.Forms.Label Label_IP;
        private System.Windows.Forms.Button Send_Login;
        private System.Windows.Forms.Button Send_Password;
        private System.Windows.Forms.TextBox Text_Login;
        private System.Windows.Forms.TextBox Text_password;
        private System.Windows.Forms.Label Label_Login;
        private System.Windows.Forms.Label Label_Password;
        private System.Windows.Forms.Label Label_port;
        private System.Windows.Forms.NumericUpDown Numer_port;
        private System.Windows.Forms.Button polacz_button;
        private System.Windows.Forms.ListBox listBox1;
        private System.ComponentModel.BackgroundWorker nawiazanie_polaczenia_z_serwerem;
        private System.ComponentModel.BackgroundWorker odczytanie_wiadomosc_z_serwera;
    }
}

