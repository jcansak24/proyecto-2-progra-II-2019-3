using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianguloPascal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el numero de filas a generar: ");
            int filas = int.Parse(Console.ReadLine());
            Console.WriteLine("\n\n***************Triangulo de Pascal***************\n");
            objDelegado pascal = new objDelegado(Piramide.generarTriangulo);
            pascal(filas); 
        }
        delegate void objDelegado(int tam);
    }

    class Piramide
    {
        public static void generarTriangulo(int tam)
        {
            int[][] auxNum = new int[tam][];
            
            for (int z =0; z<tam; z++) auxNum[z] = new int[z+1];
            
            for (int x=0; x<tam; x++)
                for (int y=0; y<x+1; y++)
                    auxNum[x][y] = 0;
            
            for (int i = 0; i<tam; i++)
            {
                for (int j = 0; j<i+1; j++) {
                    if (i > 1)
                    {
                        if (j == 0 || j == i) auxNum[i][j] = 1;
                        else auxNum[i][j] = auxNum[i - 1][j - 1] + auxNum[i - 1][j];                                                                   
                    }
                    else auxNum[i][j] = 1;                    
                }
                string space = " "; Console.Write("\t\t");
                for (int x = 0; x < tam - (i + 1); x++) Console.Write(space); 
                for (int k=0; k<i+1;k++) Console.Write($"{auxNum[i][k]}{space}");
                
                Console.Write("\n");
            }   
        }
    }
}