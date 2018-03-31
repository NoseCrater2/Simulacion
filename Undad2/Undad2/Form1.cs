using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Undad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
 List<object> lista = new List<object>();
        private void btnCalcular_Click(object sender, EventArgs e)
        {


        
            tablaBinomial.Columns.Clear();
            
            double p = Convert.ToDouble(txtP.Text);
            int iteraciones = Convert.ToInt32(txtIteracion.Text);

            int n = Convert.ToInt16(txtN.Text);
            crearTabla(n);


            for (int j = 1;j<=iteraciones;j++) { 
                 int unos = 0;
                 lista.Clear();
                 lista.Add(j);
            for (int i = 1;i<= n;i++)
            {
                    double ri = aleatorio();
                  
                    
                lista.Add(ri);
                
                if (ri > 0 && ri < (1 - p)) {
                    lista.Add(0);
                }
                else if(ri > (1-p) && ri < 1)
                {
                    
                    lista.Add(1);
                    unos++;

                }
                
   
            }
            lista.Add(unos);
          

            tablaBinomial.Rows.Add(lista.ToArray());
            }
        }


      
        public void crearTabla(int n)
        {
            tablaBinomial.Columns.Add("i", "iteraciones");
            for (int i = 1; i <= n; i++)
            {                
                tablaBinomial.Columns.Add("c" + i, "ri" + i);
                tablaBinomial.Columns.Add("c" + i, "BE" + i);
            }
            tablaBinomial.Columns.Add("resultado", "RESULTADO");

        }

        Thread t;
        public double aleatorio()
        {  
            Thread.Sleep(100);
            return Math.Round(new Random().NextDouble(), 2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalcular2_Click(object sender, EventArgs e)
        {
            MetodoExponencial exponencial = new MetodoExponencial(tablaExponencial, float.Parse(txtMedia2.Text));
            exponencial.insertar(int.Parse(txtCliente.Text));
        }

        private void btnTriangular_Click(object sender, EventArgs e)
        {
            gridTriangular.Rows.Clear();
            generarTriangular();
        }

        Thread u;
        private void generarTriangular()
        {
            int contador = Convert.ToInt32(txtVariables.Text);
            double rj;
            double ri;
            int a = Convert.ToInt32(txtValMin.Text);
            int b = Convert.ToInt32(txtValMax.Text);
            int c = Convert.ToInt32(txtModa.Text);
            for (int i = 1; i < contador + 1; i++)
            {
                rj = Math.Round(new Random().NextDouble(), 2);
                Thread.Sleep(100);
                ri = Math.Round(new Random().NextDouble(), 2);
                Thread.Sleep(100);

                if (rj > ((c - a) / (b - a)))
                {
                    gridTriangular.Rows.Add(i, rj, ri, b - ((b - c) * Math.Sqrt(1 - ri)));
                }
                else
                {
                    gridTriangular.Rows.Add(i, rj, ri, a + ((c - a) * Math.Sqrt(ri)));
                }


            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            generar2();
        }

        public List<double> generar2()
        {
            int contador = 0;
            tablita.Rows.Clear();
            int a = Convert.ToInt32(txtri.Text);
            double lamda = Convert.ToDouble(txtlamda.Text);
            List<double> listita = new List<double>();
            double ri;
            for (int i = 1; listita.Count < a; i++)
            {
                ri = Math.Round(new Random().NextDouble(), 2);
                if (!listita.Contains(ri))
                {
                    contador++;
                    listita.Add(ri);
                    double b = Math.Log(1 - ri);
                    double c = (-1 / lamda);
                    double d = b * c;
                    tablita.Rows.Add(contador, ri, lamda, Math.Round(d, 3));
                    // *)
                }
            }
            return listita;

        }

        private void btnresultado_Click(object sender, EventArgs e)
        {
            int contador = 1;
            double valorx = Convert.ToDouble(textBox1.Text);
            int valorm = int.Parse(textBox2.Text);
            double resul = (double)Math.Pow(2.1788, -valorm);
            double result = (double)Math.Pow(valorm, valorx);
            double final = (resul * result);
            double rFinal = (final / factorial(valorx));
            textBox3.Text = rFinal + "";
        }

        public double factorial(double n)
        {
            if (n == 1)
                return 1;
            else
                return n * factorial(n - 1);



        }

        double suma;
        private void btncal_Click(object sender, EventArgs e)
        {
            double tfase;

            int fase = int.Parse(txtfases.Text);// numero de fases
            double A = Convert.ToDouble(txtTiempo.Text);// tiempo media
            for (int i = 0; i < fase; i++)
            {
                tfase = exponencial(A);// mandamos al metodo exponencial el numero ingresado por el usuario
                // Angel en esta parte no supe mostrar las fases en el txt solo en consola
                //segun yo deberia mostrarlos asi pero no los muestra
                //txtStotal.Text = "Fase"+ i + "Timpo";
                Console.WriteLine("Fase " + i + " Tiempo " + tfase);// fases con respectivos tiempos
                suma += tfase;
            }

            txtStotal.Text = suma + "";// Suma total de tiempos
        }

        public static double exponencial(double a)
        {
            double exp = -a * Math.Log(Math.Round(new Random().NextDouble(), 5)); //exponencial, siempre daran diferentes

            return exp;

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 acerca = new Form2();
            acerca.Show();
            
        }
    }
}
