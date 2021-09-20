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
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Limpia el formulario colocando los valores por defecto en los distintos campos
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "0";
            this.cmbOperador.Text = "";
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = false;
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de querer salir?", "Salir", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
         }

        /// <summary>
        /// Realiza la operacion deseada entre los dos numeros ingresados
        /// </summary>
        /// <param name="numero1">Primer operando</param>
        /// <param name="numero2">Segundo operando</param>
        /// <param name="operador">Operador escogido</param>
        /// <returns>El resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            char auxChar;
            Operando PrimerNumero = new Operando(numero1);
            Operando SegundoNumero = new Operando(numero2);

            char.TryParse(operador, out auxChar);

            return Calculadora.Operar(PrimerNumero, SegundoNumero, auxChar);
        }

        private void btnoperar_Click(object sender, EventArgs e)
        {
            double resultado;
            string auxOperador = "+";
            
            resultado = (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text));
            if(resultado == double.MinValue)
            {
                MessageBox.Show("No se puede dividir por 0!!!", "Division por 0", MessageBoxButtons.OK);
            }
            else
            {                 
                this.lblResultado.Text = resultado.ToString();
                btnConvertirADecimal.Enabled = false;
                btnConvertirABinario.Enabled = true;

                if(cmbOperador.Text != string.Empty)
                {
                    auxOperador = cmbOperador.Text;
                }
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat($"{txtNumero1.Text} {auxOperador} {txtNumero2.Text} = {lblResultado.Text}");
                lstOperaciones.Items.Add(sb.ToString());


            }

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Operando().BinarioDecimal(this.lblResultado.Text);
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Operando().DecimalBinario(this.lblResultado.Text);
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FormCalculadora.ActiveForm.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
    }
}
