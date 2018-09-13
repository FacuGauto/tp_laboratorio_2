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

        public DecimalBinario

    }
}
