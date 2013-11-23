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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwypeEmulatorDemo
{
	public class WordHashContainer
	{
		private List<String> words;
		private int code;

		public WordHashContainer(int hash,String first)
		{
			words = new List<String>();
			code=hash;
			words.Add(first);
		}

		// hashcode is the ascii value of the first character in hash
		// concatenated with the hash code of the second character
		public override int GetHashCode()
		{
			return code;
		}

        public List<String> getListOfWords() { words.Sort(); return words; }
		public void Add(String param) { words.Add(param); }
	}
}