using System;

namespace MELabAA
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayExemplo = {121,-25,311,15 };
            var result = radixSort(arrayExemplo);
            
            foreach(int numero in result)
            {
                Console.WriteLine(numero);
            }
        }

        static void countSort(int[] numeros, int exp)
        {
            var output = new int[numeros.Length];

            var count = new int[10];

            for (int i = 0; i < count.Length; i++)
            {
                count[i] = 0;
            }

            foreach (int numero in numeros)
            {
                count[Math.Abs(numero / exp) % 10]++;
            }

            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = numeros.Length - 1; i >= 0; i--)
            {
                output[count[Math.Abs(numeros[i] / exp) % 10] - 1] = numeros[i];
                count[Math.Abs(numeros[i] / exp) % 10]--;
            }

            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = output[i];
            }

        }

        static int[] radixSort(int[] numeros)
        {
            int max = getMax(numeros);

            for(int exp = 1; max / exp > 0; exp *= 10)
            {
                countSort(numeros, exp);
            }

            var resultado = sortNegatives(numeros, NegativeCount(numeros));

            return resultado;
        }

        static int NegativeCount(int[] numeros)
        {
            int count = 0;

            foreach(int numero in numeros)
            {
                if (numero < 0) count++;
            }
            return count;
        }

        static int[] sortNegatives(int[] numeros, int negativeCount)
        {
            if (negativeCount > 0)
            {
                var output = new int[numeros.Length];
                var negativeInserted = 0;
                var positiveInserted = 0;

                foreach (int numero in numeros)
                {
                    if (numero >= 0)
                    {
                        output[negativeCount + positiveInserted] = numero;
                        positiveInserted++;
                    }
                    else
                    {
                        output[negativeCount-1 - negativeInserted] = numero;
                        negativeInserted++;
                    }
                }

                return output;

            }
            else return numeros;
        }

        static int getMax(int[] numeros)
        {
            int max = numeros[0];

            foreach (int numero in numeros)
            {
                if (numero > max)  max = numero;

            }
            
            return max;
        }
    }
}
