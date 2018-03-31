using System;
using System.Windows.Forms;

namespace Undad2
{
    internal class MetodoExponencial
    {

        private float media = 0;
        private float Ri = 0f;
        private DataGridView tabla;

        public MetodoExponencial(DataGridView tabla, float media)
        {

            this.tabla = tabla;
            this.media = (float)media;

            this.tabla.Rows.Clear();
        }

        public void insertar(int n)
        {
            for (int i = 0; i < n; i++)
            {

                ri();
                tabla.Refresh();
                tabla.Rows.Add((i + 1), Ri, Tiemposervicio(Ri));

            }
        }

        public double Tiemposervicio(float ri)
        {
            String cadxfinal = ((float)-media) * ((float)Math.Log(1 - ri)) + "";

            /////////////////////////////////////////////////////////////////////////////////////////////////
            if (cadxfinal.Length >= 4)
            {
                cadxfinal = cortar(cadxfinal + "", 4);
            }
            else
            {
                cadxfinal = concatenarceros(cadxfinal + "", 4);
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////   

            double x = Double.Parse(cadxfinal);
            return (x);
        }

        public float aleatorio()
        {

            return float.Parse(new Random().NextDouble() + "");
        }




        public float ri()
        {

            String cadxfinal = aleatorio() + "";

            /////////////////////////////////////////////////////////////////////////////////////////////////
            if (cadxfinal.Length >= 6)
            {
                cadxfinal = cortar(cadxfinal + "", 4);
            }
            else
            {
                cadxfinal = concatenarceros(cadxfinal + "", 4);
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////
            Ri = float.Parse(cadxfinal);
            return this.Ri;
        }

        public String concatenarceros(String cad, int digitos)
        {
            String cadena = cad;
            if (cadena.Length < 6)
            {
                for (int i = cadena.Length; i < digitos; i++)
                {
                    cadena = cadena + "0";
                }
            }
            return cadena;
        }
        public String cortar(String cad, int digitos)
        {
            String cadcortada = cad;
            if (cadcortada.Length >= digitos)
            {
                cadcortada = cadcortada.Substring(0, digitos);
            }
            return cadcortada;
        }


    }
}
