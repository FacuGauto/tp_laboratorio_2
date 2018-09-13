using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public double Operar(Numero num1,Numero num2,String operador)
        {
            double resultado;
            operador = Calculadora.ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                default:
                    break;
            }
            return resultado;
        }

        private static string ValidarOperador(string operador)
        {
            string[] operadores = {"+","-","/","*"};
            int validacion;
            for (int i = 0; i < operadores.Length; i++)
            {
                validacion = operador.CompareTo(operadores[i]);
                if (validacion == 0)
                {
                    return operador;
                }
            }
            return "+";
        }
    }
}
