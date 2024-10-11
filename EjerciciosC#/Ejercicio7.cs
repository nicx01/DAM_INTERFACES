using System;
using System.Collections.Generic;
using System.Linq;
//Escribe una función que tenga como parámetro un array de números
//enteros. Tu trabajo es tomar esa array y encontrar un índice N en el
//que la suma de los enteros a la izquierda de N sea igual a la suma de
//los enteros a la derecha de N. Si no hay ningún índice que haga que
//esto ocurra, devuelve -1. Si se le da un array con múltiples
//respuestas, devuelve el menor índice correcto.


public class Ejercicio7
{
    public void CalcularIndiceDelMedio()
    {
        Console.WriteLine("Por favor, ingrese una cadena de numeros enteros (1,2,3,4,5) (min 3 largo):");
        string numeros = Console.ReadLine();
        string[] partes = numeros.Split(',');
        int[] arrayNumeros = partes.Select(int.Parse).ToArray();
        int sumaIzquierda = 0, sumaDerecha = 0;
        if (arrayNumeros.Length > 2)
        {
            for (int i = 1; i < arrayNumeros.Length - 1; i++)
            {
                sumaIzquierda = 0;
                sumaDerecha = 0;
                for (int j = 0; j < i; j++)
                {
                    sumaIzquierda += arrayNumeros[j];
                }
                for (int k = i + 1; k < arrayNumeros.Length; k++)
                {
                    sumaDerecha += arrayNumeros[k];
                }
                if (sumaIzquierda == sumaDerecha)
                {
                    Console.WriteLine("El indice de el medio es " + i);
                    return;
                }
            }
            Console.WriteLine("No se ha encontrado resultado");
            return;
        }
        Console.WriteLine("Minimo 3 de largo");
    }
}