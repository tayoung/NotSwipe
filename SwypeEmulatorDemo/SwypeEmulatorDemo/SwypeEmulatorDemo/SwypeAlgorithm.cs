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

class SwipeDictionaryObject : IComparable {
	// Data
	public string word;
	public float weight;
	
	// Overrides
	
	// CompareTo: Used for sorting.
	public int CompareTo (object obj) {
		if (obj == null)
			return 1;
		
		SwipeDictionaryObject otherDict = obj as SwipeDictionaryObject;
		if (otherDict != null) {
			return this.weight.CompareTo (otherDict.weight);
		} else {
			throw new ArgumentException ("Object being compared not a SwipeDictionaryObject");
		}
	}
	
}

namespace SwypeEmulatorDemo
{
    public class SwypeAlgorithm
    {
        private List<string> dictionary; // assumed to be in alphabetical order
        private float[,] mat; // matrix for algorithm
        private DictionaryController dicttemp = new DictionaryController();
        // not sure why the weights are needed <--- Probably used to find closest matches.
        private float[] wei; // weights for the angles

        public SwypeAlgorithm()
        {
            mat = new float[300, 300];
            wei = new float[300];
            dictionary = new List<string>();
            // add words to dictionary
        }

        /////////////////////////////////// TEST HARNESS /////////////////////////////////////
        public void algorithm(String param, List<Vector2> vectors)
        {
            // initialization code
            //dictionary.Add("alpaca");
            //dictionary.Add("hello");
            //dictionary.Add("kill"); // This is a good base case.
            
            //dictionary.Sort();
            List<string> possibilities = new List<String>();
            if(param.Length > 0)
                possibilities = findBestMatches(param, vectors);
            Console.WriteLine("This is the user input : " + param);
            Console.WriteLine("This is the predicted matches : ");
            for (int i = 0; i < possibilities.Count; i++)
                Console.WriteLine(i + ": " + possibilities[i]);
        }
        ////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////// METHODS COPIED DIRECTLY FROM SWYPEMODEL.M ///////////////////////
        ///////////////////// I own none of this code. ////////////////////////////////////////
		
		//
		// Tyler's Code
        private float wlcs (string input, string word) {
			for (int i=1; i <= word.Length; i++) {
				for (int j=1; j <= input.Length; j++) {
				
					if (input [j - 1] == word [i - 1])
						mat[i, j] = Math.Max (mat [i - 1, j - 1] + wei [j - 1], mat [i - 1, j] - 30);
					else
						mat[i, j] = Math.Max (mat [i - 1, j], mat [i, j - 1]);
				}
			}
			return mat [word.Length, input.Length];
	    }
		
		// 
		// Zack's code
        private bool matches(String input, String word){
            int j = 0, i = 0;
            for (; i<input.Length && j<word.Length; i++)
                if (input[i]==word[j])
                    while (j<word.Length && input[i]==word[j])
                        j++;
            return j==word.Length;
        }

        // Main Algorithm
        // Tyler's Code
        private List<string> findBestMatches(String input, List<Vector2> entrancePoints){
            // this is the main algorithm. It has room to be optimized a lot but
            // theoretically it should work. Although, I do not understand it
            // completely yet.
            int begin = input[0] - 'a';
			int end = input[input.Length-1] - 'a';
			// I honestly don't know what to do with this since we don't know the file format.
			//string path = String.Format ("/var/swype/English/{0}-{1}.plist", new int[]{begin,end});
			// Here we need to open the file and put it in the words List, but see above.

            List<string> words = dictionary;//new List<string> (); // THIS IS TEMP

			List<float> weights = findAngleDifferences (findAnglesForPoints (entrancePoints));
			
            // Tyler mod: i+1 was out of bounds
            // index out of bounds for array?
			for (int i=0; i < weights.Count; i++) {
                //Console.WriteLine(weights.Count);
                wei[i + 1] = weights[i];
			}
			wei[0] = 180;
			wei[weights.Count + 1] = 180;
			List<SwipeDictionaryObject> arr = new List<SwipeDictionaryObject> ();
			
			/*This Code is Deprecated - Now controlled by DictionaryController.cs
            
            // TODO: Optimiaztion, possibly using binary search.
			for(int i=0; i < words.Count; i++) {
				string word = words [i];
				if(matches(input, word)) {
					SwipeDictionaryObject tmp = new SwipeDictionaryObject ();
					tmp.weight = (words.Count - i) / (words.Count * 180 + wlcs(input, word));
					tmp.word = word;
					arr.Add (tmp);
				}
			}*/

            List<String> answers = dicttemp.getHashMatches(input);

            // called read from file in the constructor of the dictionary controller
			
			//arr.Sort();

            answers.Sort();
			
			// Return sorted list of results.
			// TODO: Can probably do this at the same time as the dictionary object construction.
			/*List<string> results = new List<string> ();
			foreach(SwipeDictionaryObject o in arr) {
				results.Add (o.word);
			}*/
			
			//return results;
            return answers;
        }
		/***************** Helper functions *****************/

        private static float angleFromPoints(Vector2 start, Vector2 end){
            float opp, adj;
            if(start.X <= end.X && start.Y <= end.Y){
                opp = end.Y - start.Y;
                adj = end.X - start.X;
                if (adj==0)
                    return 90;
                return toDeg((float)Math.Atan(opp/adj));
            } else if (start.X >= end.X && start.Y <= end.Y){
                opp = end.Y - start.Y;
                adj = start.X - end.X;
                if (adj == 0)
                    return 90;
                return 180 - toDeg((float)Math.Atan(opp/adj));
            } else if (start.X >= end.X && start.Y >= end.Y){
                opp = start.Y - end.Y;
                adj = start.X - end.X;
                if (adj==0)
                    return 270;
                return 180 + toDeg((float)Math.Atan(opp/adj));
            } else if (start.X <= end.X && start.Y >= end.Y){
                opp = start.Y - end.Y;
                adj = end.X - start.X;
                if (adj==0)
                    return 270;
                return 360 - toDeg((float)Math.Atan(opp/adj));
            }
            return 0;
        }

        // Convert radians to degrees
        private static float toDeg(float param) {
            return param / (float) Math.PI * 180;
        }
	
		// Returns list of angles between each adjacent vector.
		private static List<float> findAnglesForPoints (List<Vector2> entrancePoints) {
			List<float> results = new List<float> ();
			
			for (int i=1; i < entrancePoints.Count; i++) {
				Vector2 t1 = entrancePoints [i - 1];
				Vector2 t2 = entrancePoints [i];
				//results.Add (Vector2.Angle(t1, t2));	// Unity library
                results.Add(angleFromPoints(t1, t2));
			}
			return results;
		}
		
		// Returns a list of all differences in the angles.
		private static List<float> findAngleDifferences (List<float> angles) {
			List<float> results = new List<float> ();
			
			for (int i=1; i < angles.Count; i++) {
				float t1 = angles [i - 1];
				float t2 = angles [i];
				results.Add (minAngle (t1, t2));
			}
			return results;
		}
	
		// Self-explanatory name.
		private static float minAngle (float a1, float a2) {
			float min = Math.Min (a1, a2);
			float max = Math.Max (a1, a2);
			return Math.Max (max - min, min - max + 360);
		}
    }
}