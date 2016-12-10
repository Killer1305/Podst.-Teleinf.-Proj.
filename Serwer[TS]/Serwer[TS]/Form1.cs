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

namespace Serwer_TS_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private TcpListener serwer = null;
        private TcpClient klient = null;
      //  private string adresIP = "127.0.0.1";
        private BinaryReader czytanie = null;
        private BinaryWriter pisanie = null;
        private bool polaczeniaAktywne = false;
        private string loginKlienta = "wafelek";
        private string hasloKlienta = "zaq1@WSX";
        delegate void UstawTekstCall(string tekst);
       //watki dla przyciskow//
       // delegate void UstawStopCall(bool dostepnosc);
        //delegate void UstawStartCall(bool dostepnosc);
        //delegate void UstawLoginCall(bool dostepnosc);
        //delegate void UstawPasswordCall(bool dostepnosc);


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
            //UstawStop(false);
            //UstawLogin(false);
           // UstawPassword(false);
          //  UstawStart(true)
            polaczeniaAktywne = false;
        }

        private void login_Click(object sender, EventArgs e)
        {
            
            if (polaczeniaAktywne == true)
            {
                pisanie.Write(Text_Login.Text);
                pisanie.Write("###Login");
                UstawTekst("Wysłano login");
            }
        }

        private void passwd_Click(object sender, EventArgs e)
        {
            if (polaczeniaAktywne == true)
            {
                pisanie.Write(Text_password.Text);
                pisanie.Write("###Haslo");
                UstawTekst("Wysłano hasło");
            }
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
                    //UstawStop(true);
                    //UstawLogin(true);
                    //UstawPassword(true);
                    //UstawStart(false);
                    UstawTekst("Klient połączył się z serwerem");
                    odczytywanie_wiadomosci_od_klienta.RunWorkerAsync();
                }
                else
                {
                    UstawTekst("Klient nie mógł się połączyć. Połączenie przerwane");
                    klient.Close();
                    serwer.Stop();
                    polaczeniaAktywne = false;
                    //UstawStop(false);
                    //UstawLogin(false);
                    //UstawPassword(false);
                    //UstawStart(true);
                }
            }
            catch//(Exception error)
            {
               // MessageBox.Show(error.ToString());
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
            /*kody wiadomosci:
             * 0 - inna wiadomosc, nie wyswietlana
             * 1 - Autoryzacja powiodła się
             * 2 - Autoryzcja nie powiodła sie
            */
            try
            {
                while((wiadomosc=czytanie.ReadString())!="###BYE###")
                {

                   


                        if (wiadomosc.Equals(loginKlienta) == true)
                            login = true;


                        if (wiadomosc.Equals(hasloKlienta) == true)
                            haslo = true;
                    

                    if (wiadomosc.Equals("###1"))
                        WpiszTekst("ktos", "Autoryzacja powiodła się");

                    if (wiadomosc.Equals("###2"))
                        WpiszTekst("ktos", "Autoryzacja nie powiodła się");
                      //   WpiszTekst("ktos", wiadomosc);

                    if ((login == true) && (haslo == true) && (wiadomosc.Equals("###Haslo")))
                    {
                        kod = "###1";
                        pisanie.Write(kod);
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
               // UstawStop(false);
                //UstawLogin(false);
                //UstawPassword(false);
                //UstawStart(true);
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

        ///watki dla przyciskow///
        /*
        private void UstawStop(bool dostepnosc)
        {
            if (Stop_button.InvokeRequired)
            {
                UstawStopCall g = new UstawStopCall(UstawStop);
                this.Invoke(g, new object[] { dostepnosc });
            }
            else
            {
                this.Send_Login.Enabled = dostepnosc;
            }
        }

        private void UstawStart(bool dostepnosc)
        {
            if (Start_button.InvokeRequired)
            {
                UstawStartCall h = new UstawStartCall(UstawStart);
                this.Invoke(h, new object[] { dostepnosc });
            }
            else
            {
                this.Send_Login.Enabled = dostepnosc;
            }
        }

        private void UstawLogin(bool dostepnosc)
        {
            if (Send_Login.InvokeRequired)
            {
                UstawLoginCall i = new UstawLoginCall(UstawLogin);
                this.Invoke(i, new object[] { dostepnosc });
            }
            else
            {
                this.Send_Login.Enabled = dostepnosc;
            }
        }

        private void UstawPassword(bool dostepnosc)
        {
            if (Send_Login.InvokeRequired)
            {
                UstawPasswordCall j = new UstawPasswordCall(UstawPassword);
                this.Invoke(j, new object[] { dostepnosc });
            }
            else
            {
                this.Send_Login.Enabled = dostepnosc;
            }
        }
         * */
    }
}
