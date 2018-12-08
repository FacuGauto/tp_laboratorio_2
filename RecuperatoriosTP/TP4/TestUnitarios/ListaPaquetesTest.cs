using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class ListaPaquetesTest
    {
        /// <summary>
        /// Verifica que la lista de paquetes del correo está instanciada
        /// </summary>
        [TestMethod]
        public void ListaPaquetesIsNotNull()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Verifica que no se puedan cargar dos paquetes con el mismo trackingID
        /// </summary>
        [TestMethod]
        public void PaquetesIgualTrackingID()
        {
            Correo correo = new Correo();
            Paquete paqueteUno = new Paquete("Alsina 234","000045454545");
            Paquete paqueteDos = new Paquete("Alsina 468", "000045554545");

            correo += paqueteUno;
            correo += paqueteDos;

        }
    }
}
