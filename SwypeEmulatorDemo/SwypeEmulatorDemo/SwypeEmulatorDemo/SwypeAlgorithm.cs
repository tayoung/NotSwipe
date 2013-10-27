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
        private String swyped;
        private ArrayList dictionary;

        public SwypeAlgorithm()
        {
            // implement dictionary
        }

        // this is the code that is important
        public void algorithm(String param)
        {
            // implement
            Console.WriteLine("This is the predicted string : "+param);
        }
    }
}
