using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using webszolgaltatas.v2.MnbServiceReference;

namespace webszolgaltatas.v2
{
    public partial class Form1 : Form
    {
        MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();

        public Form1()
        {
            InitializeComponent();
            GetExchangeRates();

        }


        private void GetExchangeRates()
        {
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"


            };

            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
        }


    }
}
