using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MSL;

namespace MultiSMTPgui
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        string[] ac;
        public Form1()
        {
            InitializeComponent();
            panel1.Click += Panel1_Click;
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            ac = openFileDialog1.FileNames;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SMTP_static.send(materialTextBox1.Text, materialTextBox2.Text, materialTextBox3.Text, materialTextBox4.Text, Convert.ToInt32(materialTextBox5.Text), materialTextBox2.Text, materialTextBox6.Text, materialTextBox7.Text, materialMultiLineTextBox1.Text, ac);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
