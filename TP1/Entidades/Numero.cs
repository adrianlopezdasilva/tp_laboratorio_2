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


        #region Constructores
        /// <summary>
        /// Constructor por defecto que asigna el valor 0 al atribuo numero
        /// </summary>
        public Numero() : this(0)
        {

        }
        /// <summary>
        /// Sobrecarga del constructor de Numero
        /// </summary>
        /// <param name="numero"> Valor a asignar</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Sobrecarga del constructor de Numero
        /// </summary>
        /// <param name="strNumero"> Valor a asignar</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        /// <summary>
        /// Valida que el string recibido sea un numero valido
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        #region Metodos
        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario"> El numero a convertir </param> 
        /// <returns> El numero convertido o un mensaje de error </returns>
        public string BinarioDecimal(string binario)
        {
            string auxString = "Valor invalido";
            double auxDouble;

            if (this.EsBinario(binario))
            {
                double.TryParse(binario, out auxDouble);
                auxString = Convert.ToInt32(binario, 2).ToString();
            }

            return auxString;
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="binario"> El binario a convertir </param> 
        /// <returns> El numero convertido o un mensaje de error </returns>
        public string DecimalBinario(double numero)
        {
            string auxString = "Valor invalido";

            if (numero >= 0)
            {
                auxString = Convert.ToString(Convert.ToInt32(numero), 2);
            }

            return auxString;
        }

        /// <summary>
        ///  Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero"> El numero a converitr </param>
        /// <returns> El numero convertido o un mensaje de error</returns>
        public string DecimalBinario(string numero)
        {
            double auxNumero;
            string auxString = "Valor invalido";

            if (double.TryParse(numero, out auxNumero))
            {
                auxString = DecimalBinario(auxNumero);
            }

            return auxString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            bool retorno = true;
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '1' && binario[i] != '0')
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }


        /// <summary>
        /// Comprueba que el valor recibido sea numérico y lo retorna en formato double
        /// </summary>
        /// <param name="strNumero"> String a validar </param> 
        /// <returns> El valor ingresado o 0 en caso de error </returns> 
        private double ValidarNumero(string strNumero)
        {
            double auxNumero = 0;
            if (!strNumero.Equals(null))
            {
                double.TryParse(strNumero, out auxNumero);
            }

            return auxNumero;
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del operador resta   
        /// </summary>
        /// <param name="n1"> Primer numero de la operacion</param>
        /// <param name="n2"> Segundo numero de la operacion</param>
        /// <returns> El resultado de la operacion </returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador multiplicacion   
        /// </summary>
        /// <param name="n1"> Primer numero de la operacion</param>
        /// <param name="n2"> Segundo numero de la operacion</param>
        /// <returns> El resultado de la operacion </returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador dividir   
        /// </summary>
        /// <param name="n1"> Primer numero de la operacion</param>
        /// <param name="n2"> Segundo numero de la operacion</param>
        /// <returns> El resultado de la operacion </returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }
        /// <summary>
        /// Sobrecarga del operador sumar   
        /// </summary>
        /// <param name="n1"> Primer numero de la operacion</param>
        /// <param name="n2"> Segundo numero de la operacion</param>
        /// <returns> El resultado de la operacion </returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        #endregion
    }
}
