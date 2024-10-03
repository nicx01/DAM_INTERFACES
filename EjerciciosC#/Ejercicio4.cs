using System;
using System.Collections.Generic;
using System.Linq;
//Dada un array de enteros, encuentra todo los números que aparecen
//un número impar de veces.

public class Ejercicio4
{
    public void RecogerAparicionesImpares()
    {
        Console.WriteLine("Por favor, ingrese una secuencia de numeros separado por comas(1,24,56):");
        string numeros = Console.ReadLine();
        string[] partes = numeros.Split(',');
        int[] arrayNumeros = partes.Select(int.Parse).ToArray();

        Dictionary<int, int> conteo = new Dictionary<int, int>();

        foreach (int num in arrayNumeros)
        {
            if (conteo.ContainsKey(num))
            {
                conteo[num]++;
            }
            else
            {
                conteo[num] = 1;
            }
        }
        Console.WriteLine("Estos numeros tienen apariciones impares:");
        foreach (var par in conteo)
        {
            if (par.Value%2==1 )
            {
                Console.WriteLine(par.Key);

            }
        }
    }
}