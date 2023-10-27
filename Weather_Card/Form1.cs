using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Weather_Card
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToShortDateString();

            label18.Text = DateTime.Now.ToShortTimeString();

            string API = "43c239fac5c38aa12e15add65a1d54f6";

            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid="+API;

            XDocument weather = XDocument.Load(connection);

            var temperature = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            var wind = weather.Descendants("speed").ElementAt(0).Attribute("value").Value;
            
            var humidity = weather.Descendants("humidity").ElementAt(0).Attribute("value").Value;

            var state = weather.Descendants("weather").ElementAt(0).Attribute("value").Value;

            var sensed = weather.Descendants("feels_like").ElementAt(0).Attribute("value").Value;

            var min = weather.Descendants("temperature").ElementAt(0).Attribute("min").Value;

            var max = weather.Descendants("temperature").ElementAt(0).Attribute("max").Value;

            var pressure = weather.Descendants("pressure").ElementAt(0).Attribute("value").Value;

            label3.Text = temperature.ToString();

            label6.Text = wind.ToString() + " m/s";

            label8.Text = humidity.ToString() + " %";

            label13.Text = sensed.ToString();   

            label20.Text = min.ToString();

            label21.Text = max.ToString();

            label27.Text = pressure.ToString() + " hPa";

            if(state == "açık")
            {
                pictureBox1.ImageLocation = @"C:\Users\Mert AYDIN\Downloads\Oxygen-Icons.org-Oxygen-Status-weather-clear.48.png";
            }

            if (state == "bulutlu")
            {
                pictureBox1.ImageLocation = @"C:\Users\Mert AYDIN\Downloads\Oxygen-Icons.org-Oxygen-Status-weather-many-clouds.48.png";
            }

            if(state == "yağmurlu")
            {
                pictureBox1.ImageLocation = @"C:\Users\Mert AYDIN\Downloads\Oxygen-Icons.org-Oxygen-Status-weather-showers.48.png";
            }

            if( state == "parçalı bulutlu")
            {
                pictureBox1.ImageLocation = @"C:\Users\Mert AYDIN\Downloads\Oxygen-Icons.org-Oxygen-Status-weather-clouds.48.png";
            }

        }
    }
}
