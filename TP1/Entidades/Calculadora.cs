using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el operador ingresado sea valido
        /// </summary>
        /// <param name="operador"> El operador a validar </param>
        /// <returns> El operador ingresado o "+" en cualquier otro caso </returns>
        private static string ValidarOperador(char operador)
        {
            string auxiliar = "+";
            if (operador == '-' || operador == '/' || operador == '*')
            {
                auxiliar = operador.ToString();
            }

            return auxiliar;

        }
        /// <summary>
        /// Realiza operaciones aritmeticas entre dos numeros
        /// </summary>
        /// <param name="num1"> Primer numero de la operacion</param>
        /// <param name="num2"> Segundo numero de la operacion</param>
        /// <param name="operador"> Operador a utilizar en la operacion</param>
        /// <returns> El resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            if (!operador.Equals(null))
            {
                operador = ValidarOperador(operador[0]);

                switch (operador)
                {
                    case "-":
                        resultado = num1 - num2;
                        break;
                    case "+":
                        resultado = num1 + num2;
                        break;
                    case "*":
                        resultado = num1 * num2;
                        break;
                    case "/":
                        resultado = num1 / num2;
                        break;
                    default:
                        resultado = 0;
                        break;
                }
            }
            return resultado;
        }
    }
}
