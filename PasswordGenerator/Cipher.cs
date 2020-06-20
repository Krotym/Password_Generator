﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordGenerator
{
    class Cipher
    {
        string[] letter = {"a","b","c","d","e","f","g",
                           "h","i","j","k","l","m","n",
                           "o","p","q","r","s","t","u",
                           "v","w","x","y","z"};
        string[] digital = {"1","2","3","4","5","6","7",
                            "8","9","10","11","12","13","14",
                            "15","16","17","18","19","20","21",
                            "22","23","24","25","26" };
        string[] hex = {"1","2","3","4","5","6","7",
                        "8","9","a","b","c","d","e",
                        "f","10","11","12","13","14","15",
                        "16","17","18","19","1a" };
        string pass = "";
        int flag;
        public int seach(string ch)
        { int pos=0;
            for (int i = 0; i < 25; i++)
            {
                if (ch == letter[i])
                {
                    pos = i;
                    flag = 1;
                    break;
                }
                else if (ch == digital[i])
                {
                    pos = i;
                    flag = 2;
                    break;
                }
                else if (ch == hex[i])
                {
                    pos = i;
                    flag = 3;
                    break;
                }
            }
            return pos;
        }

        public void cryptic (string str,int change)
        {
            Random rand = new Random();
            char[] FirstWord= str.ToArray(), TwoWord = str.ToArray();
            //перемешивание
            for(int i=0;i<str.Length;i++)
            {
                char time = FirstWord[i];
                int t = rand.Next(0, str.Length);
                FirstWord[i] = FirstWord[t];
                FirstWord[t] = time;
            }
             

            //замена
            for (int i = 0; i < change; i++)
            {
                string choic = "";
                int c = rand.Next(0, str.Length-1);
                int pos = seach(FirstWord[c].ToString());
                do
                {
                    int t = rand.Next(1, 3);
                    if ((t == 1) && (t != flag))
                    {
                        choic = letter[pos];
                    }
                    else if ((t == 2) && (t != flag))
                    {
                        choic = digital[pos];
                    }
                    else if ((t == 3) && (t != flag))
                    {
                        choic = hex[pos];
                    }
                } while (choic == "");
               

                if (choic.Length == 2)
                {
                    char[] ch = choic.ToArray();
                    TwoWord[c] = ch[0];
                    if (c + 1 < str.Length)
                    { TwoWord[c + 1] = ch[1];
                        if (c+2 <=str.Length)
                        {
                            for (int j = c + 2; j< str.Length; j++)
                            {
                                TwoWord[j] = FirstWord[j - 1];

                            }
                            for (int k = 0; k < str.Length; k++)
                            {
                                FirstWord[k] = TwoWord[k];

                            }
                        }
                    }
                }
                else    
                FirstWord[c] = Char.Parse(choic);
            }
            for (int i = 0; i < str.Length; i++)
            {
                pass += FirstWord[i];
            }
        }
        public string cryp()
        {

            return pass;
        }
    }
}
