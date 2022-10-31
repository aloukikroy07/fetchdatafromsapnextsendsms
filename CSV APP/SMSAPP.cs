using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSAPP
{
    public partial class SMSAPP : Form
    {
        public SMSAPP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string documentType = comboBox1.Text;
            DateTime fromDate = dateTimePicker1.Value;
            DateTime toDate = dateTimePicker2.Value;
          

            if(documentType == "Delivery")
            {
                Delivery delivery = new Delivery(documentType, fromDate, toDate);
                delivery.Show();
            }

            else if(documentType == "Invoice")
            {
                Invoice invoice = new Invoice(documentType, fromDate, toDate);
                invoice.Show();
            }

            else if(documentType == "Outgoing Payment")
            {
                Outgoing_Payments outgoing_Payments = new Outgoing_Payments(documentType, fromDate, toDate);
                outgoing_Payments.Show();
            }

            else
            {
                MessageBox.Show("Please select SAP document type");
            }
        }

        private void SMSAPP_Load(object sender, EventArgs e)
        {

        }
    }
}
