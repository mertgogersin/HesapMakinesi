using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HesapMakinesi
{
    public partial class MainPage : ContentPage
    {
        int durum = 1;
        string islem;
        double ilkSayi = 0;
       
        public MainPage()
        {
            InitializeComponent();
            Temizle(this, null);
        }

        private void SayiBas(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string tusDegeri = button.Text;

            if (txtSonuc.Text == "0" && tusDegeri != ",")
            {
                txtSonuc.Text = "";
            }
            
            txtSonuc.Text += tusDegeri;
            
                
            
        }

        private void Temizle(object sender, EventArgs e)
        {
            ilkSayi = 0;
            durum = 1;
            txtSonuc.Text = "0";
            sayac = 0;
        }
        int sayac = 0;
        private void IslemSec(object sender, EventArgs e)
        {
            sayac++;
            Button button = (Button)sender;
            durum = 2;
            string operand = button.Text;
            islem = operand;
            ilkSayi = Convert.ToDouble(txtSonuc.Text);
            if(sayac == 1)
            {
                txtSonuc.Text += operand;
            }
        }
        
        private void IslemiTamamla(object sender, EventArgs e)
        {
            if(durum == 2)
            {
                double sonuc = Calculate(ilkSayi, islem);
                
                txtSonuc.Text = sonuc.ToString("#,##0.0000");
                if(txtSonuc.Text == "0,0000") { txtSonuc.Text = "0"; }
                ilkSayi = sonuc;
                durum = 1;
                sayac = 0;
            }
        }
        public double Calculate(double ilkSayi, string operand)
        {
            double sonuc = 0;
            double ikinciSayi = 0;
            switch (operand)
            {
                case "÷":
                    ikinciSayi = Convert.ToDouble(txtSonuc.Text.Split('÷')[1]);
                    sonuc = ilkSayi / ikinciSayi;
                    if(ikinciSayi == 0) { 
                        DisplayAlert("Hata", "Sayı sıfıra bölünemez.", "OK");
                        sonuc = 0;
                    }
                    break;
                case "×":
                    ikinciSayi = Convert.ToDouble(txtSonuc.Text.Split('×')[1]);
                    sonuc = ilkSayi * ikinciSayi;
                    break;
                case "+":
                    ikinciSayi = Convert.ToDouble(txtSonuc.Text.Split('+')[1]);
                    sonuc = ilkSayi + ikinciSayi;
                    break;
                case "-":
                    ikinciSayi = Convert.ToDouble(txtSonuc.Text.Split('-')[1]);
                    sonuc = ilkSayi - ikinciSayi;
                    break;
            }

            return sonuc;
        }
    }
}
