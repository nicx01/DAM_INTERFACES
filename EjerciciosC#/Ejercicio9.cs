using System;
using System.Collections.Generic;
using System.Linq;
//Haz una función que pueda tomar cualquier número entero no
//negativo como argumento y devolverlo con sus dígitos en orden
//descendente. Esencialmente, reordenar los dígitos para crear el
//mayor número posible.


public class Ejercicio9
{
    public void ReordenarDigitos()
    {
        Console.WriteLine("Dame un numero");
        string numeros = Console.ReadLine();
        int[] arrayNumeros = numeros.Select(d => int.Parse(d.ToString())).ToArray();
        Array.Sort(arrayNumeros);
        Array.Reverse(arrayNumeros);
        Console.WriteLine("El numero es: ");
        for (int i = 0; i < arrayNumeros.Length; i++)
        {
            Console.Write(arrayNumeros[i]);
        }
    }
}