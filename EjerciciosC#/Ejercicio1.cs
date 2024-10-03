using System;
//Haz una función que calcule y devuelva el número de vocales en la
//cadena dada. Consideraremos a, e, i, o, u como vocales. La cadena de
//entrada sólo consta de letras minúsculas y/o espacios.

public class Ejercicio1
{
    public int CantidadVocales()
    {
        Console.WriteLine("Por favor, ingrese una palabra:");
        string palabra = Console.ReadLine();
        char[] vocales = {'a', 'e', 'i', 'o', 'u'};
        int numVocales = 0;
        for (int i = 0; i < palabra.Length; i++)
        {
            if (Array.Exists(vocales, v => v == palabra[i]))
            {
                numVocales++;
            }
        }
    Console.WriteLine("La palabra " + palabra + " tiene "+ numVocales +" vocales");
        return numVocales;
    }
}