using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
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
    public partial class form2: System.Windows.Forms.Form
    {
        private double chieucaodam;
        public form2(double As, double h) 
        {
            InitializeComponent();
            chieucaodam = h;
            textBox4.Text = As.ToString("F0");
        }
        private LocationCurve locCurve;
        public form2(LocationCurve location) 
        {
            InitializeComponent();
            locCurve = location;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int d1, d2, s1, s2;
            GetIntFromComboBox(comboBox1, out d1);
            GetIntFromComboBox(comboBox2, out d2);
            GetIntFromComboBox(comboBox3, out s1);
            GetIntFromComboBox(comboBox4, out s2);
            double As1 = CalculateAs(d1, d2, s1, s2);
            textBox3.Text = As1.ToString("F0");
        }
        private void GetIntFromComboBox(ComboBox comboBox, out int value)
        {
            if (!int.TryParse(comboBox.Text, out value))
            {
                value = 0;
            }
        }
        private void GetDoubleFromTextBox(TextBox textBox, out double value)
        {
            if (!double.TryParse(textBox.Text, out value))
            {
                value = 0;
            }
        }


        private double CalculateAs(double d1, double d2, double s1, double s2)
        {
            double As1 = (s1 * d1 * d1 * 3.14) / 4 + (s2 * d2 * d2 * 3.14) / 4;
            return As1;
        }


        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int d1, d2, s1, s2;
            GetIntFromComboBox(comboBox1, out d1);
            GetIntFromComboBox(comboBox2, out d2);
            GetIntFromComboBox(comboBox3, out s1);
            GetIntFromComboBox(comboBox4, out s2);
            double c; // lớp bảo vệ
            GetDoubleFromTextBox(textBox2, out c);
            Curve loCurve = locCurve.Curve;
            XYZ point1 = loCurve.GetEndPoint(0);
            XYZ point2 = loCurve.GetEndPoint(1);
            XYZ direction = (point2 - point1).Normalize();
            XYZ up = XYZ.BasisZ;
            XYZ right = direction.CrossProduct(up).Normalize();
            XYZ GetBarPosition(int i, int S, double v, double chieucaodam, bool tren)
            {
                double offsetY = -((S - 1) * v) / 2 + i * v;
                double offsetZ = tren ? chieucaodam - c : c;
                return point1 + right * offsetY + up * offsetZ;
            }
            Document doc = null;
            using (Transaction trans = new Transaction(doc, "ve thep doc"))
            {
                trans.Start();
                RebarBarType barType = new FilteredElementCollector(doc)
                .OfClass(typeof(RebarBarType))
                .Cast<RebarBarType>()
                .FirstOrDefault(bt => Math.Abs(bt.BarNominalDiameter - (s1 / 1000.0)) < 0.0001); 
                for(int i = 0; i < s1; i++)
                {
                    XYZ position = GetBarPosition(i, s1, d1, chieucaodam, true);
                    Rebar rebar = Rebar.Create(doc, barType, locCurve, position, RebarHookOrientation.Right, RebarHookOrientation.Right);
                }


            }    


        }
        

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
