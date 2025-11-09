using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Laboratorio_S12
{
    internal class Menu
    {
        static void DibujarEncabezado(int opcionSeleccionada)
        {
            string[] arregloMenu = { "  REGISTRAR  ", "  MOSTRAR  ", "  MODIFICAR  ", "  ELIMINAR  ", "  SALIR  " };

            Console.Clear();

            Console.WriteLine("*--------------------------------------------------------*");
            Console.WriteLine("|                                                        |");
            Console.WriteLine("|                BIENVENIDO A LA LIBRERÍA                |");
            Console.WriteLine("|                                                        |");
            Console.WriteLine("*--------------------------------------------------------*");

            for (int i = 0; i < arregloMenu.Length; i++)
            {
                if (i == opcionSeleccionada)
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(arregloMenu[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(arregloMenu[i]);
                }
            }
            Console.WriteLine("\n*--------------------------------------------------------*");
        }

        public static void Main(string[] args)
        {
            int Opc;
            do
            {
                Opc = MenuInteractivo();
                DibujarEncabezado(Opc);

                switch (Opc)
                {
                    case 0:
                        Libreria.Registrar();
                        break;

                    case 1:
                        Libreria.Mostrar();
                        break;

                    case 2:
                        Libreria.Modificar();
                        break;

                    case 3:
                        Libreria.Eliminar();
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nCerrando programa . . .");
                        Console.WriteLine("¡Hasta luego! :)");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
            while (Opc != 4);

        }

        public static int MenuInteractivo()
        {
            string[] arregloMenu = { "  REGISTRAR  ", "  MOSTRAR  ", "  MODIFICAR  ", "  ELIMINAR  ", "  SALIR  " };

            int index = 0;
            ConsoleKey tecla;

            do
            {
                DibujarEncabezado(index);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nUse las flechas <- -> para navegar.");
                Console.WriteLine("\nPresione ENTER para seleccionar una opción.");
                Console.ResetColor();

                ConsoleKeyInfo info = Console.ReadKey(true);
                tecla = info.Key;

                if (tecla == ConsoleKey.RightArrow)
                {
                    index++;
                    if (index > arregloMenu.Length - 1) index = 0;
                }
                else if (tecla == ConsoleKey.LeftArrow)
                {
                    index--;
                    if (index < 0) index = arregloMenu.Length - 1;
                }
            } while (tecla != ConsoleKey.Enter);

            return index;
        }
    }
}
