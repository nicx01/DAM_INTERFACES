using System;
using System.Collections.Generic;
using System.Linq;
//Implementa una función de diferencia, que devuelva un array que
//tenga todos los valores de la lista pasada como primer parámetro
//que no están presentes en la lista b manteniendo su orden. Si un
//valor está presente en b, todas sus apariciones deben ser eliminadas
//de la otra


public class Ejercicio8
{
    public void DiferenciaArrays()
    {
        Console.WriteLine("Por favor, ingrese una cadena de numeros enteros (1,2,3,4,5) (min 3 largo):");
        string numeros1 = Console.ReadLine();
        string[] partes1 = numeros1.Split(',');
        int[] arrayNumeros1 = partes1.Select(int.Parse).ToArray();

        Console.WriteLine("Por favor, ingrese otra cadena de numeros enteros (1,2,3,4,5) (min 3 largo):");
        string numeros2 = Console.ReadLine();
        string[] partes2 = numeros2.Split(',');
        int[] arrayNumeros2 = partes2.Select(int.Parse).ToArray();
        bool ambas = false;
        for (int i = 0; i < arrayNumeros2.Length; i++)
            {
                for (int j = 0; j < arrayNumeros1.Length; j++)
                {
                    if (arrayNumeros1[j] != arrayNumeros2[i])
                    {
                        ambas= true;
                        break;
                    }
                }
            if (ambas)
            {
                Console.Write(arrayNumeros2[i]+" ");
            }
            ambas = false;
            }
        }
}