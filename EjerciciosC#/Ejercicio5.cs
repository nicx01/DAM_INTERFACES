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
        Console.WriteLine("Por favor, ingrese una secuencia de caracteres:");
        string secuencia = Console.ReadLine();
        for (int i = 0; secuencia.Length > i; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (secuencia[j] == secuencia[i])
                {
                    secuencia = secuencia.Remove(i);
                    break;
                }
            }
        }
        Console.WriteLine("La secuencia sin repeticiones es "+secuencia);
    }
}