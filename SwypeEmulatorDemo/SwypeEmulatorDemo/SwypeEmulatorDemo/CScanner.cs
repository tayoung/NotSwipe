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
using Microsoft.Xna.Graphics;
using Microsoft.Xna.Input;

namespace SwypeEmulatorDemo{
	public class CScanner : System.IO.StringReader{
		private string current;

		public Scanner(string file) : base(file){
			readNext();
		}

		private void readNext(){ // reads the next word from the file
			// sets up the string builder to build the string
			StringBuilder builder=new StringBuilder();
			// sets an int to the next byte in the string
			int next=this.Read();
			// while the next byte is a character and not a white space
			// add it to the string builder
			for(;!char.IsWhiteSpace(nextChar)&&next>=0;next=this.Read())
				builder.Append((char)next);
			// while there is white space remaining skip the whitespace
			while(this.Peek()>=0&&(char.IsWhiteSpace((char)this.Peek())))
				this.Read();
			current=(builder.Length>0)?builder.toString():null;
		}

		// returns if this scanner currently has a string to return
		public bool hasNext(){
			return current!=null;
		}

		// returns the next string the scanner has then reads the next string in
		public string next(){
			string temp=current;
			readNext();
			return temp;
		}
	}
}