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

        /// <summary>
        /// Constructor por defecto. Asigna el valor 0 al atributo numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        ///Propiedad que valida y asigna un valor al atributo numero.
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);   
            }
        }

        /// <summary>
        /// Resta entre dos numeros
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>Resultado de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplicacion entre dos numeros
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>Resultado de la multiplicacion de dos numeros</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Division entre dos numeros
        /// </summary>
        /// <param name="n1">Divisor</param>
        /// <param name="n2">Dividendo</param>
        /// <returns>Resultado de la division</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
                return double.MinValue;
            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Suma entre dos numeros
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>Resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        
        /// <summary>
        /// Comprueba que el valor recibido sea numerico
        /// </summary>
        /// <param name="strNumero">string a validar</param>
        /// <returns>double con el numero validado</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero;
            if(double.TryParse(strNumero,out numero))
            {
                return numero;
            }
            return 0;
        }

        /// <summary>
        /// Convierte un string binario a decimal
        /// </summary>
        /// <param name="binario">string con numero binario</param>
        /// <returns>string con numero decimal.De no poder convertirse retorna "Valor invalido"</returns>
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

        /// <summary>
        /// Convierte de un numero decimal a un string binario
        /// </summary>
        /// <param name="d">numero decimal</param>
        /// <returns>string con el numero que ingreso en binario</returns>
        public string DecimalBinario(double d)
        {
            string resultado = "";
            d = Math.Abs(d);
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

        /// <summary>
        /// Convierte un numero string decimal a binario
        /// </summary>
        /// <param name="strnumero">string con numero decimal</param>
        /// <returns>>string con el numero que ingreso en binario. De no poder convertirse retorna "Valor invalido"</returns>
        public string DecimalBinario(string strnumero)
        {
            double numero;

            if (double.TryParse(strnumero, out numero))
            {
                return DecimalBinario(numero);
            }

            return "Valor invalido";
        }

    }
}
