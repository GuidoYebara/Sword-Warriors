using System;
using System.Collections.Generic;
using System.Text;

namespace SwordWarriors
{
    public class Puntaje : Animacion   
    {
        public int numero { get; set; }
        public int numeroanterior { get; set; }
        public Puntaje(ConsoleColor color)
        {
            this.sprites = new List<Sprite>();

            Sprite sprite1 = new Sprite();
            Sprite sprite2 = new Sprite();
            Sprite sprite3 = new Sprite();
            Sprite sprite4 = new Sprite();

            sprite1.refpuntos = new List<Punto>  //Numero 0 dibujado
            {
                new Punto(1,0,color),new Punto(-1,0,color),new Punto(1,1,color),new Punto(-1,1,color),new Punto(1,-1,color),new Punto(-1,-1,color),new Punto(0,2,color),new Punto(0,-2,color),
            };
            sprite2.refpuntos = new List<Punto>  //Numero 1 dibujado
            {
                new Punto(0,0,color),new Punto(0,-1,color),new Punto(0,-2,color),new Punto(-1,-1,color),new Punto(0,1,color),new Punto(0,2,color)
            };
            sprite3.refpuntos = new List<Punto> //Numero 2 dibujado
            {
                new Punto(0,0,color),new Punto(1,-1,color),new Punto(0,-2,color),new Punto(-1,-2,color),new Punto(-1,1,color),new Punto(0,2,color),new Punto(1,2,color)
            };
            sprite4.refpuntos = new List<Punto> //Numero 3 dibujado
            {
                new Punto(0,0,color),new Punto(1,-1,color),new Punto(0,-2,color),new Punto(-1,-2,color),new Punto(1,1,color),new Punto(0,2,color),new Punto(-1,2,color)
            };

            this.sprites.Add(sprite1);
            this.sprites.Add(sprite2);
            this.sprites.Add(sprite3);
            this.sprites.Add(sprite4);

            this.numero = 0;
            this.numeroanterior = 0;

        }




    }
}
