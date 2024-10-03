using System;

namespace EjerciciosInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.WriteLine("Seleccione un ejercicio o 0 para salir:");
                Console.WriteLine("1. Ejercicio 1");
                Console.WriteLine("2. Ejercicio 2");
                Console.WriteLine("3. Ejercicio 3");
                Console.Write("Ingrese su opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            new Ejercicio1().CantidadVocales();
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 0:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida, intente nuevamente.");
                            return;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }

                Console.WriteLine();

            } while (true);
        }
    }
}
