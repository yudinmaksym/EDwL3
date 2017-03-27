using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EDwL3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "this is a horse";
            string str2 = "she rode a black horse";
            string str3 = "a dog, a dog and two horses";
            string[] doc1 = str1.Split(' ');
            string[] doc2 = str2.Split(' ');
            string[] doc3 = str3.Split(' ');


            double value1 = 1 / Convert.ToDouble(doc1.Length);
            double value2 = 1 / Convert.ToDouble(doc2.Length);
            double value3 = 1 / Convert.ToDouble(doc3.Length);

            int count1 = 0;
            int count2 = 0;
            int count3 = 0;

            int howmanywordswithoutrepeat = 0;

            string slownik;   
            slownik = str1+" "+str2+" " + str3;
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
                double[] vect1 = new double[howmanywordswithoutrepeat];
                double[] vect2 = new double[howmanywordswithoutrepeat];
                double[] vect3 = new double[howmanywordswithoutrepeat];

            //FIRST VECTOR
            foreach (string word in words.Distinct())
                {
                    for(int i =0; i<doc1.Length; i++)
                    {
                        if (doc1[i] == word)
                        {

                            vect1[count1] = value1;
                            count1++;
                            break;

                        }
                        else
                        {
                            if(i == doc1.Length-1)
                            {
                            vect1[count1] = 0;
                            count1++;
                            break;
                            }
                        continue;
                            
                        }
                    }
                    
            }

                for(int j = 0; j < vect1.Length; j++)
                {
                    Console.Write(vect1[j]+" ");
                }
            Console.WriteLine();

            //FIRST VECTOR

            //SECOND VECTOR
            foreach (string word in words.Distinct())
            {
                for (int i = 0; i < doc2.Length; i++)
                {
                    if (doc2[i] == word)
                    {

                        vect2[count2] = value2;
                        count2++;
                        break;

                    }
                    else
                    {
                        if (i == doc2.Length-1)
                        {
                            vect2[count2] = 0;
                            count2++;
                            break;
                        }
                        continue;

                    }
                }
                
            }
            for (int j = 0; j < vect2.Length; j++)
            {
                Console.Write(vect2[j] + " ");
            }
            Console.WriteLine();
            //SECOND VECTOR

            //TRIRD VECTOR
            foreach (string word in words.Distinct())
            {
                for (int i = 0; i < doc3.Length; i++)
                {
                    if (doc3[i] == word)
                    {

                        vect3[count3] = value3;
                        count3++;
                        break;

                    }
                    else
                    {
                        if (i == doc3.Length-1)
                        {
                            vect3[count3] = 0;
                            count3++;
                            break;
                        }
                        continue;

                    }
                }
                
            }
            for (int j = 0; j < vect3.Length; j++)
            {
                Console.Write(vect3[j] + " ");
            }
            Console.WriteLine();
            //TRIRD VECTOR

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
    }

}
