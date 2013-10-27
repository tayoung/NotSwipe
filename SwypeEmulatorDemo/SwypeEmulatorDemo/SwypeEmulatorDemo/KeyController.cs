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

namespace SwypeEmulatorDemo
{
    public class KeyController
    {
        private String currentValue;
        private String lastPressed;

        public KeyController()
        {
            currentValue = "";
            lastPressed = "";
        }

        public bool addKey(String key)
        {
            if (key.Equals(lastPressed)||key.Equals(""))
                return false;
            lastPressed = key;
            currentValue += key;
            return true;
        }

        public String getCurrent()
        {
            return currentValue;
        }

        public void clear()
        {
            currentValue = "";
            lastPressed = "";
        }
    }
}
