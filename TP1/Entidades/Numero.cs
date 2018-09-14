 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
        private double numero;

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
            foreach (char b in binario)
            {
                if(b != '0' && b != '1')
                {
                    return "Valor invalido";
                }
            }
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == '1')
                {
                    resultado += (int)Math.Pow(2, i);
                }
            }
            return resultado.ToString();
        }

        public string DecimalBinario(double d)
        {
            string resultado = "";
            if (d < 0)
            {
                return "Valor invalido";
            }
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

    }
}
