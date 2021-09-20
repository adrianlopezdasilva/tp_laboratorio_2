using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public string Numero
        { 
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        #region Constructores

        /// <summary>
        /// Constructor por defecto que asigna el valor 0
        /// </summary>
        public Operando() : this(0)
        {

        }

        /// <summary>
        /// Sobrecarga del costructor Operando
        /// </summary>
        /// <param name="numero"></param>
        /// 
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Sobrecarga del constructor Operando
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero; 
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Comprueba que el valor recibido sea numerico y lo retorna en formato double
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>El valor ingresado o 0 en caso de error</returns>
        private double ValidarOperando(string strNumero)
        {
            double auxNumero = 0;

            if(!strNumero.Equals(null))
            {
                double.TryParse(strNumero, out auxNumero);
            }

            return auxNumero;
        }

        /// <summary>
        /// Valida que la cadena ingresada solo este compuesta por numeros binarios
        /// </summary>
        /// <param name="binario"></param>
        /// <returns> true en caso de exito, falso en caso contrario</returns>
        private bool EsBinario(string binario)
        {
            bool auxBool = true;
            for(int i = 0; i < binario.Length; i++)
            {
                if(binario[i] != '0' && binario[i] != '1')
                {
                    auxBool = false;
                    break;
                }
            }

            return auxBool;
        }

        /// <summary>
        /// Convierte el string ingresado de binario a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>El numero expresado en decimales o un mensaje de error </returns>
        public string BinarioDecimal(string binario)
        {
            string auxString = "Valor invalido";
            double auxDouble;

            if(this.EsBinario(binario) == true)
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
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del operador resta
        /// </summary>
        /// <param name="n1">Primer operando de la operacion</param>
        /// <param name="n2">Segundo operando de la operacion</param>
        /// <returns>El resultado de la operacion </returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador suma
        /// </summary>
        /// <param name="n1">Primer operando de la operacion</param>
        /// <param name="n2">Segundo operando de la operacion</param>
        /// <returns>El resultado de la operacion </returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador division
        /// </summary>
        /// <param name="n1">Primer operando de la operacion</param>
        /// <param name="n2">Segundo operando de la operacion</param>
        /// <returns>El resultado de la operacion </returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if(n2.numero == 0)
            {
                return double.MinValue;
            }

            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador multiplicacion
        /// </summary>
        /// <param name="n1">Primer operando de la operacion</param>
        /// <param name="n2">Segundo operando de la operacion</param>
        /// <returns>El resultado de la operacion </returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        #endregion

    }
}
