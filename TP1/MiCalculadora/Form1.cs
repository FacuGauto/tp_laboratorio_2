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
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();

            lblResultado.Text = numero.BinarioDecimal(txtNumero1.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
        }

        private static double Operar(string numero1,string numero2,string operador)
        {
            double resultado;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            Calculadora calculadora = new Calculadora();

            resultado = calculadora.Operar(num1, num2, operador);
            
            return resultado;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = txtNumero1.Text;
            string numero2 = txtNumero2.Text;
            string operador = cmbOperador.Text;
            double resultado;

            resultado = LaCalculadora.Operar(numero1,numero2,operador);
            lblResultado.Text = resultado.ToString();
        }

        private void btnCovertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();

            lblResultado.Text = numero.DecimalBinario(txtNumero1.Text);
        }
    }
}
