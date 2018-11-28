using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Validará y realizará la operacion entre los dos numeros ingresados
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <param name="operador">Operador(+,-,*,/)</param>
        /// <returns>Resultado de la operacion entre los dos numeros ingresados</returns>
        public double Operar(Numero num1,Numero num2,string operador)
        {
            operador = Calculadora.ValidarOperador(operador);
            double resultado = 0;

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

        /// <summary>
        /// Valida que el operador ingresado sea +,-,* o /. Sino retornará +
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Operador valido</returns>
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
