using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matris1GrupBulma
{
    class Program
    {

        static void Gruplama(int[,] M, int i, int j, int Satir,
                        int Sütun)
        {

            
            if (i < 0 || j < 0 || i > (Satir - 1) || j > (Sütun - 1)
                || M[i, j] != 1)
            {
                return;
            }

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

        static int countIslands(int[,] M)
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
            int[,] Matris = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Matris[i, j] = 0;
                }
            }
            #region 1 Atama
            Matris[0, 0] = 1;
            Matris[0, 3] = 1;
            Matris[0, 6] = 1;
            Matris[2, 0] = 1;
            Matris[4, 0] = 1;
            Matris[7, 2] = 1;
            Matris[7, 5] = 1;
            Matris[5, 7] = 1;
            Matris[3, 7] = 1;
            Matris[1, 1] = 1;
            Matris[1, 3] = 1;
            Matris[1, 6] = 1;
            Matris[2, 1] = 1;
            Matris[2, 5] = 1;
            Matris[2, 6] = 1;
            Matris[3, 2] = 1;
            Matris[3, 5] = 1;
            Matris[3, 6] = 1;
            Matris[4, 2] = 1;
            Matris[5, 2] = 1;
            Matris[5, 6] = 1;
            Matris[6, 6] = 1;
            Matris[5, 4] = 1;
            //Matris[4,4] = 1;


            #endregion

            Console.Write("1'li ada sayısı: "
                          + countIslands(Matris));
            Console.ReadLine();
        }
    }    
}
