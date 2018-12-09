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

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        /// <summary>
        /// Recorre la lista de paquetes agregando cada uno en el listbox correspondiente.
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            
            foreach (Paquete paquete in this.correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(paquete);
                        break;
                }
            }
        }

        /// <summary>
        /// Muestra los datos en rtbMostrar y los guarda en un txt
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(elemento is null))
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    elemento.MostrarDatos(elemento).Guardar("salida.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al guarda txt");
                }
                
            }
        }
        
        /// <summary>
        /// Agregara el paquete al correo y actualizara los estados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string trackingID = this.mtxtTrackingID.Text;
            string direccion = this.txtDireccion.Text;

            Paquete paquete = new Paquete(direccion, trackingID);

            paquete.InformarEsatdo += Paquete_InformarEsatdo;
            paquete.DataBase += this.fallaDataBase;

            try
            {
                this.correo += paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.ActualizarEstados();
            this.mtxtTrackingID.Clear();
            this.txtDireccion.Clear();
        }

        private void Paquete_InformarEsatdo(object obj, EventArgs args)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(Paquete_InformarEsatdo);
                this.Invoke(d, new object[] { obj, args });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void fallaDataBase(object obj, EventArgs args)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado delegado = new Paquete.DelegadoEstado(fallaDataBase);
                this.Invoke(delegado, new object[] { obj, args });
            }
            else
            {
                MessageBox.Show("Error al guardar en BASE DE DATOS");
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void btnMostarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paquete paquete = (Paquete)this.lstEstadoEntregado.SelectedItem;
            this.rtbMostrar.Text = string.Format("{0}", paquete.ToString());
        }
    }
}
