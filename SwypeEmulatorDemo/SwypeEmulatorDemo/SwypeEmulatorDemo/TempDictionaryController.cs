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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic.Dictionary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwypeEmulatorDemo
{
	public class TempDictionaryController
	{
		private Dictionary<int,WordHashContainer> words;

		public TempDictionaryController()
		{
			words = new Dictionary<int,WordHashContainer>();
		}

		// reads total number of words to add from file. then adds the next word till
		// there are no words left
		public readDictionaryFromFile(String file)
		{
			CScanner scanner=new CScanner("input location of file here");
			scanner.next(); // skip the first line of the dictionary
			scanner.next(); // skip the second line of the dictionary
			while(scanner.hasNext()){
				// get a string containing the first and last character in the next worf
				String word = scanner.next();
				String hash = word[0] + word[word.Length-1];
				// calculates the custom hash code for the word
				int code = hash[0] * 100 + hash[1];
				if (words.ContainsKey(code))
					words[code].Add(word);
				else
					words.Add(code,new WordHashContainer(code,word));
			}
		}

		public List<String> getHashMatches(String hash)
		{
			// returns the List of words that the word Hash Container has that
			// is stored with the hashcode of the parameter string
			return words[hash[0] * 100 + hash[1]].getListOfWords();
		}
	}
}