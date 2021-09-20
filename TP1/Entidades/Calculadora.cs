using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza una operacion entre 2 numeros
        /// </summary>
        /// <param name="num1"> Primer operando </param>
        /// <param name="num2"> Segundo operando </param>
        /// <param name="operador"> Operador a utilizar </param>
        /// <returns> El resultado de la operacion </returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;

            if(!operador.Equals(null))
            {
                operador = ValidarOperador(operador);

                switch(operador)
                {
                    case '-':
                        resultado = num1 - num2;
                        break;
                    case '+':
                        resultado = num1 + num2;
                        break;
                    case '*':
                        resultado = num1 * num2;
                        break;
                    case '/':
                        resultado = num1 / num2;
                        break;
                    default:
                        resultado = 0;
                        break;
                }              
            }
            return resultado;
        }
        /// <summary>
        /// Valida que el operador ingresado sea valido
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>El operador ingresado o "+" en cualquier otro caso</returns>
        private static char ValidarOperador(char operador)
        {
            char auxChar = '+';

            if(operador == '-' || operador == '/' || operador == '*')
            {
                auxChar = operador;
            }
            return auxChar;
        }
    }
}
