// ***
// *
// * Aurality Studios
// *
// * Swype Algorithm Demo
// *
// * Zackary Misso & Tyler Young
// *
// ***
//
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Collections.Generic.Dictionary;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwypeEmulatorDemo
{
	public class DictionaryController
	{
		private Dictionary<int,WordHashContainer> words;

		public DictionaryController()
		{
			words = new Dictionary<int,WordHashContainer>();
            readDictionaryFromFile("C:/Users/Aurality Studios/NotSwipe/SwypeEmulatorDemo/SwypeEmulatorDemo/SwypeEmulatorDemo/Full_English_Dictionary.txt");
		}

		// reads total number of words to add from file. then adds the next word till
		// there are no words left
		public void readDictionaryFromFile(String file)
		{
			CScanner scanner=new CScanner(file);
            Console.WriteLine(scanner.next()); // skip the first line of the dictionary, this is because it is blank in our source file
			scanner.next(); // skip the second line of the dictionary, this is because it is blank in our source file
            words.Add(30, new WordHashContainer(30, "accents"));
            words[30].Add("alpacas");
            words[30].Add("ambulances");
            words[30].Add("apples");
            words[30].Add("ambushes");
			/*while(scanner.hasNext()){
				// get a string containing the first and last character in the next worf
				String word = scanner.next();
                Console.WriteLine("scanner is not empty");
				String hash = (char)word[0] + "" + (char)word[word.Length-1];
				// calculates the custom hash code for the word
				int code = hash[0] * 100 + hash[1];
				if (words.ContainsKey(code))
					words[code].Add(word);
				else
					words.Add(code,new WordHashContainer(code,word));
			}*/

            // TEST CODE
            Console.WriteLine("begin test code");
            //List<String> ws = getHashMatches("as");
            List<String> ws = words[30].getListOfWords();
            for (int i = 0; i < ws.Count; i++)
                Console.WriteLine(ws[i]);
		}

		public List<String> getHashMatches(String hash)
		{
			// returns the List of words that the word Hash Container has that
			// is stored with the hashcode of the parameter string
			return words[hash[0] * 100 + hash[1]].getListOfWords();
		}
	}
}