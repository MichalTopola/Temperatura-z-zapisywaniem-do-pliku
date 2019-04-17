using System;
using System.IO;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            string buffor;
            double srednia = 0;
            double buf = 0;

            double[] temperatury = new double[7];
            string[] DniTygodnia = new string[7] { "Poniedzialku", "Wtorku", "Srody", "Czwartku", "Piatku", "Soboty", "Niedzieli" };
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("Podaj temperature dla " + DniTygodnia[i]);

                buffor = Console.ReadLine();
                temperatury[i] = Double.Parse(buffor);

            }

            try
            {
                using (StreamWriter plik = new StreamWriter(Path.Combine("C:/Users/MT/Desktop/Zapis do pliku", "Plik.txt")))
                {
                    for (int i = 0; i < 7; i++)
                        plik.WriteLine(temperatury[i]);
                }

            }
            catch
            {
                Console.WriteLine("Cos poszlo nie tak");
            }
            for (int z = 0; z < 7; z++)
                srednia += temperatury[z] / 7;

            Console.WriteLine("Srednia to: " + srednia);

            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                    if (temperatury[j] > temperatury[j + 1])
                    {
                        buf = temperatury[j];
                        temperatury[j] = temperatury[j + 1];
                        temperatury[j + 1] = buf;
                    }

            /*   for (int x = 0; x < 7; x++) 
               {
                   for (int y = 6; y>0; y--)
                   {
                       if (temperatury[y] > temperatury[x])
                       {
                           buf= temperatury[x];
                           temperatury[x] = temperatury[y];
                           temperatury[y]=buf;
                       }
                   }
               }*/



            Console.WriteLine("Najmniejsza tempertaura to: " + temperatury[0]);
            Console.WriteLine("Najwieksza tempertaura to: " + temperatury[6]);
            using (StreamReader streamR = new StreamReader("C:/Users/MT/Desktop/Zapis do pliku/Plik.txt"))
            {
                string czytajaca;
                while ((czytajaca=streamR.ReadLine()) != null )
                {
                    Console.WriteLine("Temperatura:" + czytajaca);
                }
            }
                Console.ReadLine();

        }
    }
}