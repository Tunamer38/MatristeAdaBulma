using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matris1GrupBulma
{
    class Block
    {
        public int data;
        public Block next;
        public Block(int veri)
        {
            this.data = veri;
        }
    }
    class QueneYapisi
    {
        Block front = null;
        Block rear = null;
        public void Enquene(int a, int b, int[,] Matris)
        {
            Block b1 = new Block(Matris[a, b]);
            if (front == null) front = rear = b1;
            else
            {
                rear.next = b1;
                rear = b1;
            }
        }
        
        public int Dequene(int a,int b,int [,] QueneDizi)
        {
            int data = front.data;
            if (front == null) return -1;
            else front = front.next;
            Console.Write("Matris[{0},{1}]= {2}\t",a,b,QueneDizi[a,b]);
            return data;
        }
    }
    class Program
    {
        static void Gruplama(int[,] M, int i, int j, int Satir, int Sütun)
        {
            if (i < 0 || j < 0 || i > (Satir - 1) || j > (Sütun - 1)
                || M[i, j] != 1)
               return;
            if (M[i, j] == 1)
            {
                QueneYapisi Değer = new QueneYapisi();
                Değer.Enquene(i, j, M);
                Değer.Dequene(i, j, M);
                M[i, j] = 0;
                Gruplama(M, i + 1, j, Satir, Sütun);
                Gruplama(M, i - 1, j, Satir, Sütun);
                Gruplama(M, i, j + 1, Satir, Sütun);
                Gruplama(M, i, j - 1, Satir, Sütun);
                Gruplama(M, i + 1, j + 1, Satir, Sütun);
                Gruplama(M, i - 1, j - 1, Satir, Sütun);
                Gruplama(M, i + 1, j - 1, Satir, Sütun);
                Gruplama(M, i - 1, j + 1, Satir, Sütun);
            }
        }
        static int AdaTespit(int[,] M)
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
                        Gruplama(M, i, j, Satir, Sütun);
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
                    Matris[i, j] = rnd.Next(0, 2);
                }
            }
            
            Console.Write("1'li ADA SAYISI: " + AdaTespit(Matris));
            Console.ReadLine();
        }
    }
}
