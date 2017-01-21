using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranspositionCipher2
{
    class Program
    {
        static void Main(string[] args)
        {
        /************************   ENCIPHER    **************************/

            string key = "TRANSPOSITION";
            int sizeKey = key.Length;
            int k, z = 0;

            string text = "HEREISASECRETMESSAGEENCIPHEREDBYTRANSPOSITION";
            int sizeText = text.Length;

            char[] temp = new char[sizeKey - 1];          //tablica na klucz

            char[] plainText = new char[sizeText];     //tablica na wprowadzony tekst
            plainText = text.ToCharArray();

            char[] encipherText = new char[sizeText];     //tablica na zaszyfrowany tekst

            temp = key.ToCharArray();

            for (int i = 65; i < 91; i++)                 //ASCII: A(65) - Z(90)
            {
                for (int j = 0; j < sizeKey; j++)
                {
                    if ((char)i == temp[j])
                    {
                        k = j;
                        do
                        {
                            encipherText[z] = plainText[k];
                            k += sizeKey;
                            z += 1;
                        } while (k < sizeText);
                    }
                }
            }
            Console.WriteLine(plainText);
            Console.WriteLine(encipherText);
           
        /************************   DECIPHER    **************************/
            int x, y, l, m;
            l = 0;
            z = 0;
            k = sizeText;
            x = sizeText % sizeKey;                     //liczba wierszy z większą liczbą kolumn
            y = sizeText / sizeKey;                     //wysokość kolumny
            char[] decipherText = new char[sizeText];  //tablica na odszyfrowany tekst

            if (x >= 0)               //jeśli reszta >= 0
            {
                y += 1;
            }                         //pierwsze x kolumn będzie miało wysokość y,reszta y - 1
            m = y;

            char[,] temp2 = new char[sizeKey, m];

            for (int i = 65; i < 91; i++)                 //ASCII: A(65) - Z(90)
            {
                for (int j = 0; j < sizeKey; j++)
                {
                    if ((char)i == temp[j])         //temp - tablica z literami klucza
                    {
                        m = y;                      //zmienna pomocnicza, aby powrócić do wartości y
                        if (j > x - 1)              //jeśli kolumna niższa - wypisz -1 mniej znaków
                        {
                            m -= 1;
                        }
                            for (int a = 0; a < m; a++)
                            {
                                temp2[j, a] = encipherText[a + l];
                            }
                            l += m;
                    }
                }
            }

            l = 0;
            for (int i = 0; i < y; i++)           //zapis macierzy do tablicy
            {
                for (int j = 0; j < sizeKey; j++)
                {
                    if (temp2[j, i] != '\0')
                    {
                        decipherText[l] = temp2[j, i];
                        l += 1;
                    }
                }
            }
        Console.WriteLine(decipherText);
        Console.ReadKey();
        }
    }
}
