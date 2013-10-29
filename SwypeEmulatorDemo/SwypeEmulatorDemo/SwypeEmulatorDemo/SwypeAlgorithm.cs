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
        private double[][] mat; // matrix for algorithm
        private double[] wei; // not really sure why this is needed

        public SwypeAlgorithm()
        {
            mat = new double[300][300];
            wei = new double[300];
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

        ///////////////////// METHODS COPIED DIRECTLY FROM SWYPEMODEL.M ///////////////////////
        ///////////////////// I own none of this code. ////////////////////////////////////////

        private double wlcs(String input,String word){
            for (int i = 0; i <= word.Length; i++){
                mat[0][i] = 0;
                mat[i][0] = 0;
            }
            for (int i = 1; i <= word.Length; i++)
                for (int j = 1; j <= input.Length; j++){
                    if (input[i] == word[j])
                        mat[i][j] = Math.MAX(mat[i-1][j-1]+wei[j-1], mat[i-1][j]-30);
                    else
                        mat[i][j] = Math.MAX(mat[i-1][j], mat[i][j-1]);
            return mat[word.Length][input.Length];
        }

        private bool mathches(String input,String word){
            int j = 0; i = 0;
            for (; i<input.Length && j<word.Length; i++)
                if (input[i]==word[j])
                    while (j<word.Length && input[i]==word[j])
                        j++;
            return j==word.Length;
        }

        private ArrayList findAnglesForPoints(Vector2[] points){
            ArrayList temp = new ArrayList();
            for (int i = 1; i<points.Count; i++)
                temp.Add(angleFromPoints(points[i-1],points[i]));
            return temp;
        }

        private double angleFromPoints(Vector2 start,Vector2 end){
            if(start.X <= end.X && start.Y <= end.Y){
                double opp = end.Y - start.Y;
                double adj = end.X - start.X;
                if (adj==0)
                    return 90;
                return toDeg(Math.Atan(opp/adj));
            } else if (start.X >= end.X && start.Y <= end.Y){
                double opp = end.Y - start.Y;
                double adj = start.X - end.X;
                if (adj == 0)
                    return 90;
                return 180 - toDeg(Math.Atan(opp/adj));
            } else if (start.X >= end.X && start.Y >= end.Y){
                double opp = start.Y - end.Y;
                double adj = start.X - end.X;
                if (adj==0)
                    return 270;
                return 180 + toDeg(Math.Atan(opp/adj));
            } else if (start.X <= end.X && start.Y >= end.Y){
                double opp = start.Y - end.Y;
                double adj = end.X - start.X;
                if (adj==0)
                    return 270;
                return return 360 - toDeg(Math.Atan(opp/adj));
            }
            return 0;
        }

        private ArrayList findAngleDifferences(ArrayList points){
            ArrayList temp = new ArrayList();
            for (int i = 1; i < points.Count; i++)
                temp.Add(angleFromPoints((Vector2)points[i-1], (Vector2)points[i]));
            return temp;
        }

        private double toDeg(double param){
            return param / Math.PI() * 180;
        }

        private double minAngle(double a1, double a2){
            double min = Math.MIN(a1,a2);
            double max = Math.MAX(a1,a2);
            return Math.MIN(max-min,min-max+360);
        }

        private ArrayList findBestMatches(String input,ArrayList points){
            int begin = input[0] - 97;
            int end = input[input.Length-1] - 97;
            // using dictionary instance variable as the list of words
            ArrayList weights = findAngleDifferences(findAnglesForPoints(points));
            for (int i = 0; i < weights.Count; i++)
                wei[i+1] = (double)weights[i];
            wei[0] = 180;
            wei[weights.Count+1] = 180;
            // This code could be easily optimized by using a binary search. TODO later
            ArrayList possibilities = new ArrayList();
            for (int i = 0; i < dictionary.Count; i++){
                String word = (String)dictionary[i];
                if (matches(input,word)){
                    
                }
            }
        }
    }
}
