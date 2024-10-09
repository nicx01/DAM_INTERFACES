using System;
using System.Collections.Generic;
using System.Linq;
//Un triángulo de color se crea a partir de una fila de colores, cada uno de los
//cuales es rojo, verde o azul. Las filas sucesivas, cada una con un color
//menos que la anterior, se generan considerando los dos colores que se
//tocan en la fila anterior.


public class Ejercicio12
{
    public void ColorearTriangulo()
    {
        Console.WriteLine("Dame una secuencia de RGB par en mayusculas");
        string secuencia = Console.ReadLine();
        string nuevaLinea = secuencia;

        if (secuencia.Length % 2 == 0)
        {
            while (secuencia.Length > 0)
            {
                Console.WriteLine();
                secuencia = nuevaLinea;
                nuevaLinea = "";
                for (int i = 0; i < secuencia.Length - 1; i += 2)
                {
                    if (secuencia[i] == secuencia[i + 1])
                    {
                        Console.Write(secuencia[i]);
                        nuevaLinea += secuencia[i];
                    }
                    else if ((secuencia[i] == 'G' && secuencia[i + 1] == 'B') || (secuencia[i] == 'B' && secuencia[i + 1] == 'G'))
                    {
                        Console.Write('R');
                        nuevaLinea += 'R';
                    }
                    else if ((secuencia[i] == 'R' && secuencia[i + 1] == 'B') || (secuencia[i] == 'B' && secuencia[i + 1] == 'R'))
                    {
                        Console.Write('G');
                        nuevaLinea += 'G';
                    }
                    else if ((secuencia[i] == 'R' && secuencia[i + 1] == 'G') || (secuencia[i] == 'G' && secuencia[i + 1] == 'R'))
                    {
                        Console.Write('B');
                        nuevaLinea += 'B';
                    }
                    else
                    {
                        Console.WriteLine("algo esta mal");
                        return;
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Es impar");
        }
    }
}