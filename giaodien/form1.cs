using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace giaodien
{
    public partial class form1: Form

    {
        public form1()
        {
            InitializeComponent();
        }

        private void tinhtoandam_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            string selected = comboBox1.SelectedItem.ToString();

            switch (selected)
            {
                case "B15":
                    textBox13.Text = "8.5";
                    textBox14.Text = "0.75";
                    break;
                case "B20":
                    textBox13.Text = "11.5";
                    textBox14.Text = "0.9";
                    break;
                case "B25":
                    textBox13.Text = "14.5";
                    textBox14.Text = "1.05";
                    break;
                case "B30":
                    textBox13.Text = "17";
                    textBox14.Text = "1.15";    
                    break;
                case "B35":
                    textBox13.Text = "19.5";
                    textBox14.Text = "1.3";
                    break;
                case "B40":
                    textBox13.Text = "22";
                    textBox14.Text = "1.4";
                    break;
                default:
                    textBox13.Text = "";
                    textBox14.Text = "";
                    break;
            }
        }



        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null) return;

            string selected = comboBox2.SelectedItem.ToString();

            switch (selected)
            {
                case "CB300-V":
                    textBox15.Text = "260";
                    break;
                case "CB400-V":
                    textBox15.Text = "350";
                    break;
                case "CB500-V":
                    textBox15.Text = "435";
                    break;
                case "CB300-T": 
                    textBox15.Text = "260";
                    break;
                case "CB240-T":
                    textBox15.Text = "210";
                    break;
                default:
                    textBox15.Text = "";
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form2 form2 = new form2();
            form2.Show();
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }
    }
}
