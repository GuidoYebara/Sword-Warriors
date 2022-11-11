using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SwordWarriors
{
    public class Punto
    {
        public int x { get; set; }
        public int y { get; set; }
        public ConsoleColor color { get; set; }

        public Punto() { }
        public Punto(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Punto(int x, int y,ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
    }
}
