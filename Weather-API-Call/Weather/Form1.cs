using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using System.Net.Http;
using Json.Net;
using Newtonsoft.Json;
using System.Text.Json;
using System.Net;
using API;


namespace Weather
{
    public partial class Form1 : Form
    {
        APIManager _apiManager;

        public Form1()
        {
            InitializeComponent();
            _apiManager = new APIManager();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text!="")
            {
                //string selectedCity = comboBox1.SelectedItem.ToString();
                string selectedCity = comboBox1.Text;

                WeatherData data = _apiManager.API(selectedCity);
                if (data.success == true)
                {
                    WeatherDetail today = data.result[0];
                    lblDayAndDate.Text = today.date + today.day;
                    lblDegree.Text = today.degree.ToString();
                    lblDescription.Text = today.description;
                    lblMaxDeg.Text = today.max.ToString();
                    lblMinDeg.Text = today.min.ToString();
                    pcBoxIcon.Image = GetIcon(today.icon);
                }
                else
                {
                    MessageBox.Show("Lütfen doğru bir şehir giriniz!");
                }

            }
            else
            {
                MessageBox.Show("Lütfen şehir seçiniz!");
            }

        }


        private Image GetIcon(string imageUrl)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(imageUrl);

                    using (var stream = new System.IO.MemoryStream(data))
                    {
                        Image image = Image.FromStream(stream);
                        return image;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim yüklenirken bir hata oluştu: " + ex.Message);
                return null;
            }
        }

       

    }
}
