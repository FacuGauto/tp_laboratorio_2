using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;

namespace TestValoresNulos
{
    [TestClass]
    public class UnitTest1
    {
        Alumno alumno;
        Profesor profesor;
        Universidad universidad;

        [TestMethod]
        public void TestMethod1()
        {
            alumno = new Alumno(1, "Juan", "Lopez", "12234456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            profesor = new Profesor(2, "Roberto", "Juarez", "32234456", Persona.ENacionalidad.Argentino);
            universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);
            Assert.IsNotNull(alumno);
            Assert.IsNotNull(profesor);

        }
    }
}
