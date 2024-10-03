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
                Console.WriteLine("4. Ejercicio 4");
                Console.Write("Ingrese su opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            new Ejercicio1().CantidadVocales();
                            break;
                        case 2:
                            new Ejercicio2().ValidarPin();
                            break;
                        case 3:
                            new Ejercicio3().CalcularRepeticiones();
                            break;
                        case 4:
                            new Ejercicio4().RecogerAparicionesImpares();
                            break;
                        case 0:
                            Console.WriteLine("Saliendo...");
                            return;
                        default:
                            Console.WriteLine("Opción no válida, intente nuevamente.");
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
