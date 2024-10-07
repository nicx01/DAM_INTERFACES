using System;
using System.Collections.Generic;
using System.Linq;
//Escribe una función que tome un parámetro positivo num y devuelva
//su persistencia multiplicativa, que es el número de veces que debes
//multiplicar los dígitos de num hasta llegar a un solo dígito.

public class Ejercicio6
{
    public void CalcularPersistenciaMultiplicativa()
    {
        Console.WriteLine("Por favor, ingrese un numero:");
        string input = Console.ReadLine();
        int numero = int.Parse(input);
        int persistencia = 0;
        int multiplicacion = int.MaxValue;
        int copyNumero = numero;
        while (multiplicacion >= 10 && copyNumero>=10)
        {
            multiplicacion = 1;
            while (copyNumero > 0)
            {
                multiplicacion=multiplicacion*(copyNumero%10);
                copyNumero = copyNumero/10;
            }
            copyNumero = multiplicacion;
            persistencia++;
        }

        Console.WriteLine("La persistencia multiplicativa es " + persistencia);
    }
}