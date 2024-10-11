using System;
//Los cajeros automáticos permiten códigos PIN de 4 o 6 dígitos y los
//códigos PIN no pueden contener más que exactamente 4 dígitos o
//exactamente 6 dígitos. Si a la función se le pasa una cadena de PIN
//válida, devuelve true, de lo contrario devuelve false
public class Ejercicio2
{
    public bool ValidarPin()
    {
        Console.WriteLine("Por favor, ingrese el pin:");
        string pin = Console.ReadLine();
        if (pin.Length == 4 || pin.Length == 6)
        {
            Console.WriteLine("Pin válido");
            return true;
        }
        Console.WriteLine("Este pin no es válido");
        return false;
    }
}