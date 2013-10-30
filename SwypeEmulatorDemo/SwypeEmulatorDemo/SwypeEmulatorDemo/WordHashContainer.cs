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
	public class WordHashContainer
	{
		private ArrayList words;
		private String hash;

		public WordHashContainer(String code)
		{
			words = new ArrayList();
			hash=code;
		}

		public WordHashContainer(String code,String first)
		{
			words = new ArrayList();
			hash=code;
			words.Add(first);
		}

		// hashcode is the ascii value of the first character in hash
		// concatenated with the hash code of the second character
		public int GetHashCode()
		{
			return hash[0] * 100 + hash[1];
		}

		public List<String> getListOfWords() { return words; }
		public void Add(String param) { words.Add(param); }
	}
}