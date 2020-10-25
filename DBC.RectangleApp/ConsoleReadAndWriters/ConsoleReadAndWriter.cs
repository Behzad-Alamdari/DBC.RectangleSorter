﻿using System;

namespace DBC.RectangleApp.ConsoleReadAndWriters
{
    public class ConsoleReadAndWriter : IConsoleReadAndWriter
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}
