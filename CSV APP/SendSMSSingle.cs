using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSAPP
{
    public partial class SendSMSSingle : Form
    {
        public SendSMSSingle(DocumentInfo docInfo, string message)
        {
            InitializeComponent();

            documentInfo = docInfo;
            textMessage = message;
        }

        DocumentInfo documentInfo;
        string textMessage;

        private void SendSMSSingle_Load(object sender, EventArgs e)
        {
            textBox1.Text = documentInfo.DocumentNumber;
            textBox4.Text = documentInfo.CardName;
            textBox2.Text = documentInfo.ContactPersonName;
            textBox3.Text = documentInfo.ContactPersonNumber;
            richTextBox1.Text = textMessage;
            textBox8.Text = documentInfo.VehicleNumber;
            textBox5.Text = documentInfo.DriverName;
            textBox7.Text = documentInfo.DriverMobile;
            textBox6.Text = documentInfo.TSOName;
            textBox9.Text = documentInfo.TSOMobile;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            label11.Visible = true;
            SendSMSToCustomer(textBox3.Text, richTextBox1.Text, "CUSTOMER");
            SendSMSToCustomer(textBox9.Text, richTextBox1.Text, "TSO");
            pictureBox1.Visible = false;
            label11.Visible = false;
        }

        public static void SendSMSToCustomer(string mobileNo, string sms, string person)
        {
            string customermobileNo = mobileNo;
            string message = sms;
            string responseText;
            //string message = "Hello. Welcome SMS.";
            string firstMessage = "http://masking.zaman-it.com/smsapi?api_key=C2002769632ec7877570d8.90820609&type=text&contacts=88" + customermobileNo + "&senderid=FINIS&msg=" + message;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(firstMessage);

            HttpWebResponse response = (HttpWebResponse)myReq.GetResponse();

            WebHeaderCollection header = response.Headers;

            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
            }

            if (responseText.Contains("SMS SUBMITTED") && person == "CUSTOMER")
            {
                MessageBox.Show("Send SMS to customer successfully!");
            }

            else if (responseText.Contains("SMS SUBMITTED") && person == "TSO")
            {
                MessageBox.Show("Send SMS to TSO successfully!");
            }

            else
            {
                MessageBox.Show("SMS send failed!");
            }
        }
    }
}
