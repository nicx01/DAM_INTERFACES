using System;
using System.Collections.Generic;
using System.Linq;
//Implementar la función que toma como argumento una secuencia de
//enteros o string y devuelve una lista de elementos sin ningún
//elemento repetido y preservando el orden original de los elementos.

public class Ejercicio5
{
    public void DevolverSinRepetidos()
    {
        Console.WriteLine("Por favor, ingrese una frase:");
        string secuencia = Console.ReadLine();
        HashSet<char> seen = new HashSet<char>();
        List<char> result = new List<char>();

        foreach (char c in secuencia)
        {
            if (!seen.Contains(c))
            {
                seen.Add(c);
                result.Add(c);
            }
        }
        string resultadoFinal = new string(result.ToArray());
        Console.WriteLine("La secuencia sin repeticiones es "+ resultadoFinal);
    }
}