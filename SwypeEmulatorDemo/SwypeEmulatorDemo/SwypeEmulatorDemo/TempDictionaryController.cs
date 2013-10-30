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
// Note this class is under construction and should not be implemented in
// the demo yet
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
	public class TempDictionaryController
	{
		private HashSet<WordHashContainer> words;

		public TempDictionaryController()
		{
			words = new HashSet<WordHashContainer>();
		}

		// reads total number of words to add from file. then adds the next word till
		// there are no words left
		public readDictionaryFromFile(String file)
		{
			//TODO: read number of words from file
			int numWords = 0;
			for(int i=0;i<numWords;i++){
				// TODO: read next word from the file
				String word = "example";
				String hash = word[0] + word[word.Length-1]; // "ee"
				if (words.Contains(new WordHashContainer(hash))){
					int code = hash[0] * 100 + hash[1];
					words[hash].Add(word);
				}else
					words.Add(new WordHashContainer(hash,word));
			}
		}

		public List<String> getHashMatches(String hash)
		{
			int hashNum = hash[0] * 100 + hash[1];
			return words[hashNum].getListOfWords();
		}
	}
}