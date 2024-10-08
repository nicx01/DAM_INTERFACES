using System;
using System.Collections.Generic;
using System.Linq;
//El teorema de los cuatro cuadrados de Lagrange, también conocido
//como conjetura de Bachet, afirma que todo número natural puede
//representarse como la suma de cuatro cuadrados enteros.

public class Ejercicio11
{
    public void CalcularBachet()
    {
        Console.WriteLine("Dame un numero positivo");
        string input = Console.ReadLine();
        int numero = int.Parse(input);
        bool encontrado = false;
        
        if (numero > 0)
        {
            for(int a = 0; a*a <= numero; a++)
            {
                for (int b = 0; b*b <= numero; b++)
                {
                    for (int c = 0; c*c <= numero; c++)
                    {
                        for (int d = 0; d*d <= numero; d++)
                        {
                            if (numero == a*a + b*b + c*c + d*d)
                            {
                                System.Console.WriteLine("Los numeros son " + a + " " + b + " " + c + " " + d);
                                encontrado = true;
                            }

                        }
                    }
                }
            }
            if (!encontrado) { Console.WriteLine("El teorema no se cumple :c"); }
        }
        else
        {
            Console.WriteLine("El numero no es positivo");
        }

       
    }
}