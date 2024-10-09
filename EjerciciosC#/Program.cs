using System;

namespace EjerciciosInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            while (true)
            {
                Console.WriteLine("Seleccione un ejercicio o 0 para salir:");
                Console.WriteLine("1. Ejercicio 1");
                Console.WriteLine("2. Ejercicio 2");
                Console.WriteLine("3. Ejercicio 3");
                Console.WriteLine("4. Ejercicio 4");
                Console.WriteLine("5. Ejercicio 5");
                Console.WriteLine("6. Ejercicio 6");
                Console.WriteLine("7. Ejercicio 7");
                Console.WriteLine("7. Ejercicio 7");
                Console.WriteLine("8. Ejercicio 8");
                Console.WriteLine("9. Ejercicio 9");
                Console.WriteLine("10. Ejercicio 10");
                Console.WriteLine("11. Ejercicio 11");
                Console.WriteLine("12. Ejercicio 12");
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
                        case 5:
                            new Ejercicio5().DevolverSinRepetidos();
                            break;
                        case 6:
                            new Ejercicio6().CalcularPersistenciaMultiplicativa();
                            break;
                        case 7:
                            new Ejercicio7().CalcularIndiceDelMedio();
                            break;
                        case 8:
                            new Ejercicio8().DiferenciaArrays();
                            break;
                        case 9:
                            new Ejercicio9().ReordenarDigitos();
                            break;
                        case 10:
                            new Ejercicio10().CalcularUnosBinario();
                            break;
                        case 11:
                            new Ejercicio11().CalcularBachet();
                            break;
                        case 12:
                            new Ejercicio12().ColorearTriangulo();
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

            };
        }
    }
}
