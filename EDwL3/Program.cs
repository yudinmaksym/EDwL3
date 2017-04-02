using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace EDwL3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] muz1= new string[16];


            ///////////////////////////////////////////////////////////////////////////////////

            for (int i =1; i<16; i++)
            {
                var fs = new FileStream("f"+i+".txt", FileMode.Open, FileAccess.Read,
                                     FileShare.ReadWrite | FileShare.Delete);
                
                using (StreamReader reader = new StreamReader(fs, Encoding.GetEncoding("Windows-1250")))
                {
                    muz1[i] = reader.ReadToEnd();
                }
                fs.Close();
            }


            ///////////////////////////////////////////////////////////////////////////////////


            string[][] doc = new string[15][];
            doc[0] = muz1[1].Split(' ');
            doc[1] = muz1[2].Split(' ');
            doc[2] = muz1[3].Split(' ');
            doc[3] = muz1[4].Split(' ');
            doc[4] = muz1[5].Split(' ');
            doc[5] = muz1[6].Split(' ');
            doc[6] = muz1[7].Split(' ');
            doc[7] = muz1[8].Split(' ');
            doc[8] = muz1[9].Split(' ');
            doc[9] = muz1[10].Split(' ');
            doc[10] = muz1[11].Split(' ');
            doc[11] = muz1[12].Split(' ');
            doc[12] = muz1[13].Split(' ');
            doc[13] = muz1[14].Split(' ');
            doc[14] = muz1[15].Split(' ');


            double[] value = new double[15];
            value[0] = 1 / Convert.ToDouble(doc[0].Length);
            value[1] = 1 / Convert.ToDouble(doc[1].Length);
            value[2] = 1 / Convert.ToDouble(doc[2].Length);
            value[3] = 1 / Convert.ToDouble(doc[3].Length);
            value[4] = 1 / Convert.ToDouble(doc[4].Length);
            value[5] = 1 / Convert.ToDouble(doc[5].Length);
            value[6] = 1 / Convert.ToDouble(doc[6].Length);
            value[7] = 1 / Convert.ToDouble(doc[7].Length);
            value[8] = 1 / Convert.ToDouble(doc[8].Length);
            value[9] = 1 / Convert.ToDouble(doc[9].Length);
            value[10] = 1 / Convert.ToDouble(doc[10].Length);
            value[11] = 1 / Convert.ToDouble(doc[11].Length);
            value[12] = 1 / Convert.ToDouble(doc[12].Length);
            value[13] = 1 / Convert.ToDouble(doc[13].Length);
            value[14] = 1 / Convert.ToDouble(doc[14].Length);

            int count1 = 0;


            int howmanywordswithoutrepeat = 0;

            string slownik="";
            slownik = muz1[1] + muz1[2] + muz1[3] + muz1[4] + muz1[5] + muz1[6] + muz1[7] + muz1[8] + muz1[9] + muz1[10] + muz1[11] + muz1[12] + muz1[13] + muz1[14] + muz1[15];
            slownik = Regex.Replace(slownik, @"[\W]", " ");
            slownik = Regex.Replace(slownik, @"\s+", " ");
            string[] words = slownik.Split(' ');

            //SORTING
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length - 1; j++)
                {
                    if (needToReOrder(words[j], words[j + 1]))
                    {
                        string s = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = s;
                    }
                }
            }            
            //SORTING

            foreach (string word in words.Distinct())
            {
                howmanywordswithoutrepeat++;
            }
                double[,] vect1 = new double[15,howmanywordswithoutrepeat];

            //FIRST VECTOR
            for(int j =0; j < 15; j++)
            {
                foreach (string word in words.Distinct())
                {
                    for (int i = 0; i < doc[j].Length; i++)
                    {
                        if (doc[j][i] == word)
                        {

                            vect1[j, count1] = value[j];
                            count1++;
                            break;

                        }
                        else
                        {
                            if (i == doc[j].Length - 1)
                            {
                                vect1[j, count1] = 0;
                                count1++;
                                break;
                            }
                            continue;

                        }
                    }

                }
                count1 = 0;
            }

            //for (int d = 0; d < 15; d++)
            //{
            //    for (int j = 0; j < howmanywordswithoutrepeat; j++)
            //    {
            //        Console.Write(vect1[d, j] + " ");
            //    }
            //    Console.WriteLine();
            //}


            //FIRST VECTOR

            double proverit;
            double rez = 0;
            double rez2 = 0;
            double rez3 = 0;
            int k = 0;
            for(int j = 0; j < 15; j++)
            {
                //k = j + 1;
                for(k = 1; k < 15; k++)
                {
                    rez = 0;
                    rez2 = 0;
                    rez3 = 0;
                    for (int i = 0; i < howmanywordswithoutrepeat; i++)
                    {
                        if (j == 15)
                        {
                            break;
                        }
                        else
                        {   
                            proverit= vect1[j, i] * vect1[k, i];
                            rez += proverit;
                            rez2 += vect1[j, i] * vect1[j, i];
                            rez3 += vect1[k, i] * vect1[k, i];
                        }


                    }
                    double prom = Math.Sqrt(rez2) * Math.Sqrt(rez3);
                    double cos = rez / prom;
                    Console.WriteLine(j+" "+k+" :" + cos);
                    
                }
                
            }
            

        }
            
        
        protected static bool needToReOrder(string s1, string s2)
        {
            for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
            }
            return false;
        }

        protected static bool openallfiles()
        {
            





            return false;
        }
    }

}
