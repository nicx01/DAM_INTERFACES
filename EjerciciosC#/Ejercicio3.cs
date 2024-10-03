using System;
using System.Collections.Generic;
using System.Linq;
//Haz una función que como parámetro reciba un array de números y
//obtenga el número que menos repeticiones haya tenido. En caso de
//empate devuelve el número más pequeño.

public class Ejercicio3
{
    public int CalcularRepeticiones()
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


        int numeroMenosFrecuente = Int32.MaxValue;
        int minFrecuencia = Int32.MaxValue;

        foreach (var par in conteo)
        {
            if (par.Value < minFrecuencia || (par.Value == minFrecuencia && par.Key < numeroMenosFrecuente))
            {
                minFrecuencia = par.Value;
                numeroMenosFrecuente = par.Key;
            }
        }
        Console.WriteLine("El numero minimo de apariciones es "+minFrecuencia+" y el mas pequeño de ellos es "+numeroMenosFrecuente);
        return minFrecuencia;
    }
}