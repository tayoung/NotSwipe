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
		private ArrayList words;
		private int code;

		public WordHashContainer(int code,String first)
		{
			words = new ArrayList();
			hash=code;
			words.Add(first);
		}

		// hashcode is the ascii value of the first character in hash
		// concatenated with the hash code of the second character
		public int GetHashCode()
		{
			return code;
		}

		public List<String> getListOfWords() { return words.Sort(); }
		public void Add(String param) { words.Add(param); }
	}
}