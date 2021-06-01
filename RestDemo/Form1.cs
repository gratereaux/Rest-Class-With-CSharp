using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestDemo
{
    public partial class Form1 : Form
    {
        RestClient rClient = new RestClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            txtUrl.Text = "https://api.marcos.do/central_bank_rates";
 
            rClient.endPoint = txtUrl.Text;
            rClient.AccessToken = "123456789";
            
            string strResponse = string.Empty;
            strResponse = rClient.MakeGet();

            debugOutput(strResponse);

        }

        private void btnRun2_Click_1(object sender, EventArgs e)
        {
            txtUrl.Text = "https://httpbin.org/post";

            rClient.endPoint = txtUrl.Text;
            rClient.AccessToken = "123456789";
            rClient.data1 = "Hola Mundo!";

            string strResponse = string.Empty;

            var postRs = rClient.MakePost();

            debugOutput(postRs);
        }

        private void btnPut_Click(object sender, EventArgs e)
        {

            txtUrl.Text = "https://httpbin.org/put";

            rClient.endPoint = txtUrl.Text;
            rClient.AccessToken = "123456789";
            rClient.data1 = "Hola Mundo!";

            string strResponse = string.Empty;

            var postRs = rClient.MakePut();

            debugOutput(postRs);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtUrl.Text = "https://httpbin.org/delete";

            rClient.endPoint = txtUrl.Text;
            rClient.AccessToken = "123456789";

            string strResponse = string.Empty;

            var postRs = rClient.MakeDelete();

            debugOutput(postRs);
        }




        private void debugOutput(string strDebubText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebubText + Environment.NewLine);
                // Place text on textBox
                txtResult.Text = strDebubText + Environment.NewLine;
                txtResult.SelectionStart = txtResult.TextLength;
                txtResult.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
    }
}
