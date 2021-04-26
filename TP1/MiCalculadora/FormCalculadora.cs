using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : System.Windows.Forms.Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FormCalculadora.ActiveForm.Close();
        }

         private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Convert.ToString(Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text));
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        private void btnCovertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Numero().BinarioDecimal(this.lblResultado.Text);
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {          
            this.lblResultado.Text = new Numero().DecimalBinario(this.lblResultado.Text);
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = false;
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// Limpia el formulario colancando los valores por defecto en los distintos campos
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "0";
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = false;
        }

        /// <summary>
        /// Realiza la operacion deseada entre los dos numeros ingresados
        /// </summary>
        /// <param name="numero1">Primer operando</param>
        /// <param name="numero2">Segundo operando</param>
        /// <param name="operador">Operador escogido</param>
        /// <returns>El resultado de la operacion</returns>
        private static double Operar (string numero1, string numero2, string operador)
        {
            Numero PrimerNumero = new Numero(numero1);
            Numero SegundoNumero = new Numero(numero2);

            return Calculadora.Operar(PrimerNumero, SegundoNumero, operador);
        }


    }
}
