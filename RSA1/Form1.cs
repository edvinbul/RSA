using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace RSA1
{
    public partial class Form1 : Form
    {
        RSAParameters publickey;
        RSAParameters privatekey;
        public Form1()
        {
            InitializeComponent();

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            publickey = rsa.ExportParameters(false);
            privatekey = rsa.ExportParameters(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSACryptoServiceProvider rsaencrypt = new RSACryptoServiceProvider();
            rsaencrypt.ImportParameters(publickey);

            byte[] cleararray = Encoding.Unicode.GetBytes(textBox1.Text);

            byte[] firstbyte = rsaencrypt.Encrypt(cleararray, false);

            textBox2.Text = Convert.ToBase64String(firstbyte);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RSACryptoServiceProvider rsadecrypt = new RSACryptoServiceProvider();
            rsadecrypt.ImportParameters(privatekey);

            byte[] secondbyte = Convert.FromBase64String(textBox2.Text);

            byte[] cleararrays = rsadecrypt.Decrypt(secondbyte, false);

            textBox3.Text = Encoding.Unicode.GetString(cleararrays);
        }
    }
}
