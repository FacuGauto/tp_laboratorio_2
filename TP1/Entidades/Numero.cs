 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        private string SetNumero
        {
            set => numero = ValidarNumero(value);
        }

        public Numero()
        {

        }

        public Numero(double numero) => this.numero = numero;

        public Numero(string strNumero)
        {
            double numero = Convert.ToDouble(strNumero);
            this.numero = numero;
        }

        public static double operator -(Numero n1, Numero n2) => n1.numero - n2.numero;

        public static double operator *(Numero n1, Numero n2) => n1.numero * n2.numero;

        public static double operator /(Numero n1, Numero n2) => n1.numero / n2.numero;

        public static double operator + (Numero n1, Numero n2) => n1.numero + n2.numero;
        
        private double ValidarNumero(string strNumero)
        {
            double numero;
            if(double.TryParse(strNumero,out numero))
            {
                return numero;
            }
            return 0;
        }

        public string BinarioDecimal(string binario)
        {
            int resultado = 0;
            char[] array = binario.ToCharArray();
            Array.Reverse(array);
            foreach (char b in array)
            {
                if(b != '0' && b != '1')
                {
                    return "Valor invalido";
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    resultado += (int)Math.Pow(2, i);
                }
            }
            return resultado.ToString();
        }

        public string DecimalBinario(double d)
        {
            string resultado = "";
            d = Math.Abs(d);
            /*if (d < 0)
            {
                return "Valor invalido";
            }*/
            if(d == 0)
            {
                return "0";
            }
            
            while(d>0)
            {
                if(d % 2 ==0)
                {
                    resultado = "0" + resultado;
                }
                else
                {
                    resultado = "1" + resultado;
                }
                d = (int)d / 2;
            }

            return resultado;
        }

        public string DecimalBinario(string strnumero)
        {
            string resultado = "";
            double numero = Convert.ToDouble(strnumero);

            resultado = DecimalBinario(numero);

            return resultado;
        }

    }
}
