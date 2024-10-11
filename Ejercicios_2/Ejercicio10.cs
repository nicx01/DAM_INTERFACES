using System;
using System.Collections.Generic;
using System.Linq;
//Escriba una función que tome un número decimal como entrada, y
//devuelva el número de bits que son iguales a uno en la
//representación binaria de ese número. Comprueba que la entrada no
//sea negativa.


public class Ejercicio10
{
    public void CalcularUnosBinario()
    {
        Console.WriteLine("Dame un numero positivo");
        string input = Console.ReadLine();
        int numero = int.Parse(input);
        int unos = 0;
        if (numero > 0)
        {
            while (numero > 0)
            {
                if (numero % 2 == 1) { unos++; }
                numero = numero / 2;
            }
            Console.WriteLine("El numero tiene " + unos + " uno(s)");
        }
        else
        {
            Console.WriteLine("El numero no es positivo");
        }


    }
}