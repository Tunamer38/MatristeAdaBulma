using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matris1GrupBulma
{
    class Program
    {

        static void Gruplama(int[,] M, int i, int j, int Satir,int Sütun)
        {
            if (i < 0 || j < 0 || i > (Satir - 1) || j > (Sütun - 1)
                || M[i, j] != 1)
                return;
            if (M[i, j] == 1)
            {
                M[i, j] = 0;
                Gruplama(M, i + 1, j, Satir,Sütun); 
                Gruplama(M, i - 1, j, Satir,Sütun); 
                Gruplama(M, i, j + 1, Satir,Sütun); 
                Gruplama(M, i, j - 1, Satir,Sütun); 
                Gruplama(M, i + 1, j + 1, Satir,Sütun); 
                Gruplama(M, i - 1, j - 1, Satir,Sütun); 
                Gruplama(M, i + 1, j - 1, Satir, Sütun); 
                Gruplama(M, i - 1, j + 1, Satir,Sütun); 
            }
        }

        static int AdaKapasite(int[,] M)
        {
            int Satir = M.GetLength(0);
            int Sütun = M.GetLength(1);
            int count = 0;
            for (int i = 0; i < Satir; i++)
            {
                for (int j = 0; j < Sütun; j++)
                {
                    if (M[i, j] == 1)
                    {
                        count++;
                        Gruplama(M, i, j, Satir,Sütun); 
                    }
                }
            }
            return count;
        }
        static void Main()
        {
            Console.WriteLine("Matrisin Satır Sayısını Giriniz: ");
            int Satir = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Matrisin Sütun Sayısını Giriniz: ");
            int Sütun = Convert.ToInt32(Console.ReadLine());
            int[,] Matris = new int[Satir, Sütun];
            Random rnd = new Random();
            for (int i = 0; i < Satir; i++)
            {
                for (int j = 0; j < Sütun; j++)
                {
                    Matris[i, j] = rnd.Next(0,2);
                }
            } 
            Console.Write("1'li ada sayısı: "+ AdaKapasite(Matris));
            Console.ReadLine();
        }
    }    
}
