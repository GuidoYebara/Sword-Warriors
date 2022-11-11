using System;
using System.Collections.Generic;
using System.Text;

namespace SwordWarriors
{
    public class Luna
    {
        public List<Punto> refpuntos { get; set; }
        public Luna()
        {
            this.refpuntos = new List<Punto>()
            {
                new Punto(59,2),new Punto(60,2),new Punto(61,2), new Punto(58,3),new Punto(59,3),new Punto(60,3),
                new Punto(61,3),new Punto(62,3),new Punto(57,4),new Punto(58,4),new Punto(59,4),new Punto(57,5),
                new Punto(58,5),new Punto(59,5),new Punto(57,6), new Punto(58,6),new Punto(59,6),new Punto(60,6),
                new Punto(63,6),new Punto(58,7),new Punto(59,7),new Punto(60,7),new Punto(61,7),new Punto(62,7),
                new Punto(59,8),new Punto(60,8),new Punto(61,8),
            };
            foreach(Punto p in this.refpuntos)
            {
                OtrosMetodos.pintar(p.x,p.y,ConsoleColor.Gray);
            }
        }
    }
}
