using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Laboratorio_S12
{
    public class Libreria
    {
        private static string[] Nombres = new string[0];
        private static double[] Precios = new double[0];
        private static int Contador = 0;

        public static void Registrar()
        {
            //PEDIR NOMBRE
            string NombreLibro = "";
            Console.WriteLine("\n- REGISTRAR LIBRO -");
            bool huboError;

            do
            {
                huboError = false;

                Console.Write("\nNombre del libro: ");
                NombreLibro = Console.ReadLine();

                if (NombreLibro == null || NombreLibro == "")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n¡ERROR! El nombre no puede estar vacío.");
                    Console.WriteLine("Inténtelo nuevamente . . .");
                    Console.ResetColor();
                    huboError = true;
                }
                else
                {
                    for (int i = 0; i < Contador; i++)
                    {
                        if (NombreLibro.ToLower() == Nombres[i].ToLower())
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n¡ERROR! El libro ya existe.");
                            Console.ResetColor();
                            huboError = true;
                            break;
                        }
                    }
                }
            }
            while (huboError);

            //PEDIR PRECIO
            string PrecioTexto;
            double Precio = 0;
            Console.WriteLine("\n");
            Console.WriteLine("- REGISTRAR PRECIO -");

            do
            {
                Console.Write("\nPrecio: ");
                PrecioTexto = Console.ReadLine();

                if (PrecioTexto == null || !double.TryParse(PrecioTexto, out Precio))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n¡ERROR! Precio debe ser un número válido.");
                    Console.WriteLine("Inténtelo nuevamente . . .");
                    Console.ResetColor();
                }
                else
                {
                    if (Precio < 0 || Precio > 1000)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n¡ERROR! Precio debe ser entre 0 y 1000.");
                        Console.WriteLine("Inténtelo nuevamente . . .");
                        Console.ResetColor();
                    }
                }
            }
            while (PrecioTexto == null || !double.TryParse(PrecioTexto, out Precio) || (Precio < 0 || Precio > 1000));


            Array.Resize(ref Nombres, Contador + 1);
            Array.Resize(ref Precios, Contador + 1);

            Nombres[Contador] = NombreLibro;
            Precios[Contador] = Precio;
            Contador++;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nLibro registrado exitosamente.");
            Console.WriteLine("Presione una tecla para volver a la cinta de opciones.");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void Mostrar()
        {
            Console.WriteLine("\n- LIBROS REGISTRADOS: " + Contador + " -\n");

            if (Contador == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("No hay libros registrados.");
                Console.ResetColor();
            }
            else
            {
                for (int i = 0; i < Contador; i++)
                {
                    Console.WriteLine((i + 1) + ". Nombre: " + (Nombres[i]) + ", Precio: " + (Precios[i]) + "\n");

                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Presione una tecla para volver a la cinta de opciones.");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void Modificar()
        {
            string NombreBuscar;
            bool huboError;
            int indice = -1;
            Console.WriteLine("\n- MODIFICAR LIBRO -");
            do
            {
                huboError = false;
                Console.Write("\nNombre del libro a modificar: ");
                NombreBuscar = Console.ReadLine();
                indice = -1;
                for (int i = 0; i < Contador; i++)
                {
                    if (Nombres[i].ToLower() == NombreBuscar.ToLower())
                    {
                        indice = i;
                        break;
                    }
                }
                if (indice == -1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n¡ERROR! Libro no encontrado.");
                    Console.WriteLine("Inténtelo nuevamente . . .");
                    Console.ResetColor();
                    huboError = true;
                }
            }
            while (huboError);

            string NuevoNombre;
            do
            {
                huboError = false;
                Console.Write("\nIngrese el nuevo nombre: ");
                NuevoNombre = Console.ReadLine();
                if (NuevoNombre == null || NuevoNombre == "")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n¡ERROR! El nombre no puede estar vacío.");
                    Console.WriteLine("Inténtelo nuevamente . . .");
                    Console.ResetColor();
                    huboError = true;
                }
                else
                {
                    for (int i = 0; i < Contador; i++)
                    {
                        if (i != indice && Nombres[i].ToLower() == NuevoNombre.ToLower())
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n¡ERROR! El nuevo nombre ya existe.");
                            Console.WriteLine("Inténtelo nuevamente . . .");
                            Console.ResetColor();
                            huboError = true;
                            break;
                        }
                    }
                }
            }
            while (huboError);
            string PrecioTexto;
            double NuevoPrecio = 0;
            do
            {
                Console.Write("\nIngrese el nuevo precio: ");
                PrecioTexto = Console.ReadLine();
                if (PrecioTexto == null || !double.TryParse(PrecioTexto, out NuevoPrecio))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n¡ERROR! Precio debe ser un número válido.");
                    Console.WriteLine("Inténtelo nuevamente . . .");
                    Console.ResetColor();
                }
                else if (NuevoPrecio < 0 || NuevoPrecio > 1000)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n¡ERROR! Precio debe ser entre 0 y 1000.");
                    Console.WriteLine("Inténtelo nuevamente . . .");
                    Console.ResetColor();
                }
            }
            while (PrecioTexto == null || !double.TryParse(PrecioTexto, out NuevoPrecio) || (NuevoPrecio < 0 || NuevoPrecio > 1000));
            Nombres[indice] = NuevoNombre;
            Precios[indice] = NuevoPrecio;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nLibro modificado exitosamente.");
            Console.WriteLine("Presione una tecla para volver a la cinta de opciones.");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void Eliminar()
        {
            string NombreBuscar;
            bool huboError;
            int indice = -1;

            Console.WriteLine("\n- ELIMINAR LIBRO -");
            do
            {
                huboError = false;
                Console.Write("\nNombre del libro a eliminar: ");
                NombreBuscar = Console.ReadLine();
                indice = -1;
                for (int i = 0; i < Contador; i++)
                {
                    if (Nombres[i].ToLower() == NombreBuscar.ToLower())
                    {
                        indice = i;
                        break;
                    }
                }
                if (indice == -1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n¡ERROR! Libro no encontrado.");
                    Console.WriteLine("Inténtelo nuevamente . . .");
                    Console.ResetColor();
                    huboError = true;
                }
            }
            while (huboError);

            for (int i = indice; i < Contador - 1; i++)
            {
                Nombres[i] = Nombres[i + 1];
                Precios[i] = Precios[i + 1];
            }
            Array.Resize(ref Nombres, Contador - 1);
            Array.Resize(ref Precios, Contador - 1);
            Contador--;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nLibro eliminado exitosamente.");
            Console.WriteLine("Presione una tecla para volver a la cinta de opciones.");
            Console.ResetColor();
            Console.ReadKey();
        }

    }
}
