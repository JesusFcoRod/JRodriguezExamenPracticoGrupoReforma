using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int op;

            Console.WriteLine("1.- SUMA DE DOS MATRICES 3X3");
            Console.WriteLine("2.- FACTORIAL");
            Console.WriteLine("SELECCIONE UNA OPCION: ");
            op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    int[,] MatrizA = new int[3, 3];
                    int[,] MatrizB = new int[3, 3];
                    int[,] MatrizRes = new int[3, 3];

                    Console.WriteLine("Datos Matriz A: ");

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Console.WriteLine("Ingrese el dato: ");
                            MatrizA[i, j] = int.Parse(Console.ReadLine());
                        }
                    }

                    Console.WriteLine("Datos Matriz B: ");
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Console.WriteLine("Ingrese el dato: ");
                            MatrizB[i, j] = int.Parse(Console.ReadLine());
                        }
                    }

                    Console.WriteLine("SUMANDO LAS MATRICES...");
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            MatrizRes[i, j] = MatrizA[i, j] + MatrizB[i, j];
                        }
                    }

                    Console.WriteLine("La matriz resultante es: ");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write("\n");
                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write(MatrizRes[i, j] + " ");
                        }

                    }

                    Console.ReadKey();
                    break;

                case 2:
                    int Numero;
                    Console.WriteLine("Ingrese un numero: ");
                    Numero = int.Parse(Console.ReadLine());
                    Console.WriteLine("El factorial del numero "+ Numero +" es " + Factorial(Numero));
                    Console.ReadKey();
                    break;
            }
        }

        public static int Factorial(int Numero)
        {
            if (Numero == 0)
            {
                return 1;
            }
            else
            {
                return Numero * Factorial(Numero - 1);
            }
        }

    }
}
