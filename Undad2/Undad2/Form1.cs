using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Undad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        General g = new General();
        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            tablaNormal.Rows.Clear();
            double desviacion = Convert.ToDouble(txtDesviacion.Text);
            double media = Convert.ToDouble(txtMedia.Text);
            int iteraciones = Convert.ToInt32(txtIteraciones.Text);
            for (int i  = 1; i<iteraciones+1; i++)
            {

                double sum = sumatoria12();
                double sumMenos6 = sum - 6;
                tablaNormal.Rows.Add(i, sum, sumMenos6, (sumMenos6*desviacion)+media);
            }
           
        }

        public double sumatoria12()
        {

            List<double> lista = new List<double>();
            double ri = 0;

            while (lista.Count < 13)
            {
                ri = Math.Round(new Random().NextDouble(), 2);
                if (!lista.Contains(ri))
                lista.Add(ri);
            }

            
            return lista.Sum();

        }

        public List<double> generar()
        {
            int count = 0;

            tablaUniforme.Rows.Clear();
            int a = Convert.ToInt32(txtA.Text);
            int b = Convert.ToInt32(txtB.Text);
            int medicion = Convert.ToInt32(txtMedicion.Text);
            List<double> lista = new List<double>();
            double ri;
            for (int i = 1; lista.Count < medicion; i++)
            {
                ri = Math.Round(new Random().NextDouble(), 2);
                if (!lista.Contains(ri))
                {
                    count++;
                    lista.Add(ri);
                    tablaUniforme.Rows.Add(count, ri, a+(b-a)*ri);
                }

            }



            return lista;

        }

        private void btn1_Click(object sender, EventArgs e)
        {

            generar();
        

        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {
            txtA2.Text = txtA.Text;
        }
    }
}
