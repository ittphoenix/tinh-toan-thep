using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;


namespace giaodien
{
    public partial class form1 : System.Windows.Forms.Form

    {
        private UIDocument _uidoc;

        public form1(UIDocument uidoc)
        {
            InitializeComponent();
            _uidoc = uidoc;
        }

        public form1()
        {

        }

        private void tinhtoandam_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {

                IList<Reference> pickedRefs = _uidoc.Selection.PickObjects(ObjectType.Element, "Chọn các dầm");
                foreach (Reference reference in pickedRefs)
                {
                    Element element = _uidoc.Document.GetElement(reference);
                    if (element is FamilyInstance beam)
                    {
                        LocationCurve location = beam.Location as LocationCurve;
                        if (location == null || location.Curve == null)
                        {
                            MessageBox.Show("doi tuong khong hop le");
                            continue;
                            form2 form2 = new form2(location);

                        }
                        double L = location.Curve.Length;
                        double b = GetParamValue(beam, "b");
                        double h = GetParamValue(beam, "h"); 
                        textBox1.Text = (b * 304.8).ToString("F0");
                        textBox2.Text = (h * 304.8).ToString("F0");
                        textBox3.Text = (L * 304.8).ToString("F0");
                    }
                    else 
                    {
                        MessageBox.Show("doi tuong khong hop le");
                    }
                    


                }
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                TaskDialog.Show("Huỷ", "da chon 0 dam");
            }
            this.Show();
        }
        private double GetParamValue(FamilyInstance fi, string paramName)
        {
            Parameter param = fi.Symbol.LookupParameter(paramName);
            if (param != null && param.StorageType == StorageType.Double)
            {
                return param.AsDouble(); 
            }
            return 0;

            
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
            this.Hide();
            double Rb, Rbt, Rs, a;
            GetDoubleFromTextBox(textBox13, out Rb);
            GetDoubleFromTextBox(textBox14, out Rbt);
            GetDoubleFromTextBox(textBox15, out Rs);
            GetDoubleFromTextBox(textBox7, out a); // khoảng cách từ trọng tâm cốt thép đến đáy dầm

            double b, h, L, M;
            GetDoubleFromTextBox(textBox1, out b);
            GetDoubleFromTextBox(textBox2, out h);
            GetDoubleFromTextBox(textBox3, out L);
            GetDoubleFromTextBox(textBox4, out M);

            double As = CalculateAs(M, Rb, b, h, a, Rs);

            form2 form2 = new form2(As, h);
            form2.Show();

            
        }
        private double CalculateAs(double M, double Rb, double b, double h, double a, double Rs)
        {
           
            double h0 = h - a;
            double x = (M / (Rb * b * h0 * h0)) * 1000000;
            double ξ = 1 - Math.Sqrt(1 - 2 * x);
            double As = (0.9 * Rb * b * h0 * ξ) / Rs;

            return As;




        }
        private void GetDoubleFromTextBox(System.Windows.Forms.TextBox textBox, out double value)
        {
            if (!double.TryParse(textBox.Text, out value))
            {
                MessageBox.Show("Vui lòng nhập gia trị hợp lệ");
                value = 0;
                
            }
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
