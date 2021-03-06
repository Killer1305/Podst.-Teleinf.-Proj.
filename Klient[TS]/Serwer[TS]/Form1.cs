﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace Klient_TS_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private BinaryReader czytanie = null;
        private BinaryWriter pisanie = null;
        private bool polaczeniaAktywne;
        delegate void UstawTekstCall(string tekst);
        private TcpClient klient=null;
        byte[] SHA1_Passwd_byte;
        string SHA1_Passwd_string = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Kliknij połącz by połączyć z serwerem...");
        }

        private void polacz_click(object sender, EventArgs e)
        {
            if (polaczeniaAktywne == false)
            {
                nawiazanie_polaczenia_z_serwerem.RunWorkerAsync();
            }
            else
            {
                polaczeniaAktywne = false;
                if (klient != null)
                {
                    pisanie.Write("###BYE###");
                    klient.Close();
                }
            }
        }

        private void login_click(object sender, EventArgs e)
        {
            if (polaczeniaAktywne == true)
            {
                pisanie.Write(Text_Login.Text);
                UstawTekst("Wysłano login");
                pisanie.Write("###Login");
            }
        }

        private void passwd_click(object sender, EventArgs e)
        {
            if (polaczeniaAktywne == true)
            {
                SHA1_Passwd_byte = hashuj(Text_password.Text);
                foreach (byte Bajt in SHA1_Passwd_byte)
                {
                    SHA1_Passwd_string += Bajt.ToString("x");
                }
                pisanie.Write(SHA1_Passwd_string);
                UstawTekst("Wysłano hasło");
                pisanie.Write("###Haslo");
            }
        }

        private void nawiazanie_polaczenia_z_serwerem_DoWork(object sender, DoWorkEventArgs e)
        {
            string serwerIP = null;
            try
            {
                serwerIP = Text_IP.Text;
            }
            catch
            {
                MessageBox.Show("Błędny format adresu IP!", "Błąd");
                Text_IP.Text = String.Empty;
                polaczeniaAktywne = false;
                return;
            }

            int port = System.Convert.ToInt16(Numer_port.Value);
            
            try
            {
                klient = new TcpClient(serwerIP, port);
                NetworkStream ns = klient.GetStream();
                czytanie = new BinaryReader(ns);
                pisanie = new BinaryWriter(ns);
                pisanie.Write("###Hi###");
                this.UstawTekst("Próba połączenia z serwerem");
                polaczeniaAktywne = true;
                odczytanie_wiadomosc_z_serwera.RunWorkerAsync();
            }
            catch
            {
                this.UstawTekst("Nie można nawiązać połączenia");
                polaczeniaAktywne = false;               
            }
        }

        private void odczytanie_wiadomosc_z_serwera_DoWork(object sender, DoWorkEventArgs e)
        {
            string wiadomosc;
            UstawTekst("Połączono z serwerem");
            string kod = "###0";

            /*kody wiadomosci:
             * ###0 - inna wiadomosc, nie wyswietlana
             * ###1 - Uwierzytelnienie powiodło się
             * ###2 - Uwierzytelnienie nie powiodło sie
            */
            
            try
            {
                while ((wiadomosc = czytanie.ReadString()) != "###BYE###")
                {
                    if (wiadomosc.Equals("###1"))
                        WpiszTekst("Serwer", "Uwierzytelnienie powiodło się");
                    if (wiadomosc.Equals("###2"))
                        WpiszTekst("Serwer", "Uwierzytelnienie nie powiodło się");                    
                }
                UstawTekst("Połączenie zostało przerwane");
                polaczeniaAktywne = false;
                klient.Close();
            }
            catch
            {
                UstawTekst("Połączenie zostało przerwane");
                polaczeniaAktywne = false;
                klient.Close();
            }
        }

        private void UstawTekst(string wiadomosc)
        {
            if (listBox1.InvokeRequired)
            {
                UstawTekstCall f = new UstawTekstCall(UstawTekst);
                this.Invoke(f, new object[] { wiadomosc });
            }
            else
            {
                this.listBox1.Items.Add(wiadomosc);
            }
        }

        private void WpiszTekst(string kto, string wiadomosc)
        {
            UstawTekst(kto + " napisał: " + wiadomosc);
        }

        static byte[] hashuj(String dane)
        {
            SHA1 sha1_hash = new SHA1CryptoServiceProvider();
            return sha1_hash.ComputeHash(Encoding.UTF8.GetBytes(dane));
        }

    }
}
