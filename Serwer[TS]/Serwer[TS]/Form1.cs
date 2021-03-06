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
using Serwer_TS_.Database;

namespace Serwer_TS_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            m_oDBConnector = Connector.GetInstance();
        }
        private TcpListener serwer = null;
        private TcpClient klient = null;
        private BinaryReader czytanie = null;
        private BinaryWriter pisanie = null;
        private bool polaczeniaAktywne = false;
        delegate void UstawTekstCall(string tekst);
        private Connector m_oDBConnector;


        private void Form1_Load(object sender, EventArgs e)
        {
            UstawTekst("Kliknij start by uruchomić serwer...");
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (polaczeniaAktywne == false)
            {
                polaczeniaAktywne = true;
                oczekiwanie_na_polaczenie.RunWorkerAsync();
            }
            else
            {
                polaczeniaAktywne = false;
                if (klient != null)
                    klient.Close();
                serwer.Stop();
                oczekiwanie_na_polaczenie.CancelAsync();
                if (odczytywanie_wiadomosci_od_klienta.IsBusy)
                    odczytywanie_wiadomosci_od_klienta.CancelAsync();
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            serwer.Stop();
            klient.Close();
            UstawTekst("Zatrzymano pracę serwera");
            polaczeniaAktywne = false;
        }        

        private void oczekiwanie_na_polaczenie_DoWork(object sender, DoWorkEventArgs e)
        {
            IPAddress serwerIP = null;
            try
            {
                serwerIP = IPAddress.Parse(Text_IP.Text);
            }
            catch
            {
                MessageBox.Show("Błędny format adresu IP!", "Błąd");
                Text_IP.Text = String.Empty;
                polaczeniaAktywne = false;
                return;
            }
            int port = System.Convert.ToInt16(Numer_port.Value);
            serwer = new TcpListener(serwerIP, port);
            try
            {
                serwer.Start();
                UstawTekst("Oczekiwanie na połączenie");
                klient = serwer.AcceptTcpClient();
                NetworkStream ns = klient.GetStream();
                czytanie = new BinaryReader(ns);
                pisanie = new BinaryWriter(ns);
                if (czytanie.ReadString() == "###Hi###")
                {
                    UstawTekst("Klient połączył się z serwerem");
                    odczytywanie_wiadomosci_od_klienta.RunWorkerAsync();
                }
                else
                {
                    UstawTekst("Klient nie mógł się połączyć. Połączenie przerwane");
                    klient.Close();
                    serwer.Stop();
                    polaczeniaAktywne = false;
                }
            }
            catch
            {
                UstawTekst("Połączenie przerwane");
                polaczeniaAktywne = false;
            }
        }

        private void odczytywanie_wiadomosci_od_klienta_DoWork(object sender, DoWorkEventArgs e)
        {
            string wiadomosc;
            bool haslo = false;
            bool login = false;
            string kod = "###0";
            string user_tmp = "";
            
            /*kody wiadomosci:
             * ###0 - inna wiadomosc, nie wyswietlana
             * ###1 - Uwierzytelnienie powiodło się
             * ###2 - Uwierzytelnienie nie powiodło sie
            */

            try
            {
                while((wiadomosc=czytanie.ReadString())!="###BYE###")
                {
                    if (wiadomosc.Equals(m_oDBConnector.GetLogin(wiadomosc)) == true)
                    {
                        login = true;
                        user_tmp = m_oDBConnector.GetLogin(wiadomosc);
                    }
                    if (wiadomosc.Equals(m_oDBConnector.GetPassword(user_tmp)) == true)
                    {
                        haslo = true;
                    }
                    if ((login == true) && (haslo == true) && (wiadomosc.Equals("###Haslo")))
                    {
                        kod = "###1";
                        pisanie.Write(kod);
                        UstawTekst("Uwierzytelniono użytkownika: " + user_tmp);
                        UstawTekst("Członek grupy: " + m_oDBConnector.GetGroup(user_tmp));
                        kod = "###0";
                        login = false;
                        haslo = false;
                    }
                    else
                    {
                        if (wiadomosc.Equals("###Haslo"))
                        {
                            kod = "###2";
                            pisanie.Write(kod);
                            kod = "###0";
                        }
                    }
                }
                klient.Close();
                serwer.Stop();
                UstawTekst("Połączenie zostało przerwane przez klienta");
            }
            catch
            {
                UstawTekst("Klient rozłączony");
                polaczeniaAktywne = false;
                klient.Close();
                serwer.Stop();
            }
        }
        
        private void WpiszTekst(string kto, string wiadomosc)
        {
            UstawTekst(kto + "napisał: " + wiadomosc);            
        }

        private void UstawTekst(string wiadomosc)
        {
            if (listBox1.InvokeRequired)
            {
                UstawTekstCall f = new UstawTekstCall(UstawTekst);
                this.Invoke(f,new object[] {wiadomosc});
            }
            else
            {
                this.listBox1.Items.Add(wiadomosc);
            }
        }
    }
}
