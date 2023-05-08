using System;
using System.IO;

namespace dzieliwin2
{
    class Program
    {
        static void Main(string[] args)
        {
          
            int n, m;
            int poziomkryt;
            int i, j;
            int woda=0;


            string path2 = "wczytajduzy.txt";
            StreamReader odczyt = File.OpenText(path2);
            string s = odczyt.ReadLine();
            string[] wymiary = s.Split(" ");
            n = Int32.Parse(wymiary[0]);
            m = Int32.Parse(wymiary[1]);
            int[,] loch = new int[n + 2, m + 2];
            int[,] znacznik = new int[n + 2, m + 2];
            for (int r = 1; r < n + 1; r++)
            {
                s = odczyt.ReadLine();
                string[] sufity = s.Split(" ");
                for (int d = 1; d < m + 1; d++)
                {
                    loch[r, d] = Int32.Parse(sufity[d - 1]);
                }

            }
            s = odczyt.ReadLine();
            wymiary = s.Split(" ");
            i = Int32.Parse(wymiary[0]);
            j = Int32.Parse(wymiary[1]);

            poziomkryt = loch[i, j] - 1;
            int b;
            if (m > n)
            {
                b = m;
            }
            else
            {
                b = n;
            }
            znacznik[i, j] = 1;
            for(int t=0; t<b*b;t++)
            {
                for (int r = 1; r < n + 1; r++)
                {
                   
                    for (int d = 1; d < m + 1; d++)
                    {
                       if(znacznik[r,d]==1)
                        {
                            if (((loch[r,d] - loch[r - 1, d - 1]) > -5 && (loch[r, d] - loch[r - 1, d - 1]) < 5) && loch[r-1,d-1]>poziomkryt)
                            {
                                znacznik[r - 1, d - 1] = 1;
                            }
                            if (((loch[r, d] - loch[r - 1, d]) > -5 && (loch[r, d] - loch[r - 1, d]) < 5) && loch[r - 1, d] > poziomkryt)
                            {
                                znacznik[r - 1, d] = 1;
                            }
                            if (((loch[r, d] - loch[r - 1, d + 1]) > -5 && (loch[r, d] - loch[r - 1, d + 1]) < 5) && loch[r - 1, d + 1] > poziomkryt)
                            {
                                znacznik[r-1, d + 1] = 1;
                            }
                            if (((loch[r, d] - loch[r, d-1]) > -5 &&( loch[r, d] - loch[r, d-1]) < 5) && loch[r, d - 1] > poziomkryt)
                            {
                                znacznik[r, d-1] = 1;
                            }
                            if (((loch[r, d] - loch[r, d+1]) > -5 &&( loch[r, d] - loch[r, d+1] )< 5) && loch[r , d + 1] > poziomkryt)
                            {
                                znacznik[r, d+1] = 1;
                            }
                            if (((loch[r, d] - loch[r + 1, d-1]) > -5 && (loch[r, d] - loch[r + 1, d-1]) < 5) && loch[r + 1, d - 1] > poziomkryt)
                            {
                                znacznik[r + 1, d-1] = 1;
                            }
                            if (((loch[r, d] - loch[r + 1, d]) > -5 && (loch[r, d] - loch[r + 1, d]) < 5) && loch[r + 1, d] > poziomkryt)
                            {
                                znacznik[r + 1, d] = 1;
                            }
                            if (((loch[r, d] - loch[r + 1, d +1]) > -5 && (loch[r, d] - loch[r + 1, d+1]) < 5) && loch[r + 1, d + 1] > poziomkryt)
                            {
                                znacznik[r + 1, d+1] = 1;
                            }
                        }
                    }

                }
            }
            for (int r = 1; r < n + 1; r++)
            {
                
                for (int d = 1; d < m + 1; d++)
                {
                    if(znacznik[r,d]==1 && loch[r,d]>=poziomkryt)
                    {
                        if((loch[r,d]-poziomkryt)>=5)
                        {
                            woda += 5;
                        }
                        else
                        {
                            woda += (loch[r, d] - poziomkryt);
                        }
                    }
                }
                
            }
            
            Console.WriteLine(woda);
        }
    }
}
