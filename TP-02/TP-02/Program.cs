using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_2018;

namespace TP_02_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuración de la pantalla
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight - 2);

            // Nombre del alumno
            Console.Title = "Gauto Facundo 2°C"; 

            Changuito changoDeCompras = new Changuito(6);

            Dulce DulceUno = new Dulce(Producto.EMarca.Sancor, "ASD012", ConsoleColor.Black);
            Dulce DulceDos = new Dulce(Producto.EMarca.Ilolay, "ASD913", ConsoleColor.Red);
            Leche LecheUno = new Leche(Producto.EMarca.Pepsico, "HJK789", ConsoleColor.White);
            Leche LecheDos = new Leche(Producto.EMarca.Serenisima, "IOP852", ConsoleColor.Blue, Leche.ETipo.Descremada);
            Snacks SnackUno = new Snacks(Producto.EMarca.Campagnola, "QWE968", ConsoleColor.Gray);
            Snacks SnackDos = new Snacks(Producto.EMarca.Arcor, "TYU426", ConsoleColor.DarkBlue);
            Snacks SnackTres = new Snacks(Producto.EMarca.Sancor, "IOP852", ConsoleColor.Green);
            Snacks SnackCuatro = new Snacks(Producto.EMarca.Sancor, "TRE321", ConsoleColor.Green);

            // Agrego 8 ítems (los últimos 2 no deberían poder agregarse ni el m1 repetido) y muestro
            changoDeCompras += DulceUno;
            changoDeCompras += DulceDos;
            changoDeCompras += LecheUno;
            changoDeCompras += LecheUno;
            changoDeCompras += LecheUno;
            changoDeCompras += SnackUno;
            changoDeCompras += SnackDos;
            changoDeCompras += SnackTres;
            changoDeCompras += SnackCuatro;

            Console.WriteLine(changoDeCompras.ToString());
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Beep();
            Console.Clear();

            // Quito un item y muestro
            changoDeCompras -= DulceUno;

            Console.WriteLine(changoDeCompras.ToString());
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Beep();
            Console.Clear();
            
            // Muestro solo Leches
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.ETipo.Leche));
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Beep();
            Console.Clear();

            // Muestro solo Dulces
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.ETipo.Dulce));
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Beep();
            Console.Clear();

            // Muestro solo Snacks
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.ETipo.Snacks));
            Console.WriteLine("<-------------PRESIONE UNA TECLA PARA SALIR------------->");
            Console.ReadKey();
            Console.Beep();

        }
    }
}
