using System;

public class Ejercicio1
{
    public void CantidadVocales()
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
    }
}