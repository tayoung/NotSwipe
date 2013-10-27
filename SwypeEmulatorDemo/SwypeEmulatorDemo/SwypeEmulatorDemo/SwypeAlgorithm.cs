// ***
// *
// * Aurality Studios
// *
// * Swype Algorithm Demo
// *
// * Zackary Misso & Tyler Young
// *
// ***
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwypeEmulatorDemo
{
    public class SwypeAlgorithm
    {
        private ArrayList dictionary; // assumed to be in alphabetical order

        public SwypeAlgorithm()
        {
            dictionary = new ArrayList();
            // add words to dictionary
        }

        /////////////////////////////////// MAIN ALGORITHM /////////////////////////////////////
        public void algorithm(String param)
        {
            // initialization code
            ArrayList possible = new ArrayList();
            dictionary = dictionarySort(dictionary);
            // implement
            Console.WriteLine("This is the predicted string : "+param);
        }
        ////////////////////////////////////////////////////////////////////////////////////////

        private ArrayList dictionarySort(ArrayList list) // sorts dictionary in ascending order
        {
            if (list.Count == 0)
                return list;
            int i = 0;
            ArrayList a = new ArrayList();
            ArrayList b = new ArrayList();
            for (; i < list.Count / 2; i++)
                a.Add(list[i]);
            for (; i < list.Count; i++)
                b.Add(list[i]);
            return merge(dictionarySort(a), dictionarySort(b));
        }

        private ArrayList merge(ArrayList a, ArrayList b) // assumed to be is sorted order
        {
            ArrayList answer = new ArrayList();
            int ac=0; int bc=0;
            for (;ac+bc < a.Count + b.Count;)
            {
                if (ac == a.Count)
                    answer.Add(b[bc++]);
                else if (bc == b.Count)
                    answer.Add(a[ac++]);
                else if (((String)a[ac]).CompareTo((String)b[bc]) > 0)
                    answer.Add(b[bc++]);
                else if (((String)a[ac]).CompareTo((String)b[bc]) < 0)
                    answer.Add(a[ac++]);
                else
                {
                    answer.Add(a[ac++]);
                    bc++;
                }
            }
            return answer;
        }
    }
}
