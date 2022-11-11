using System;
using System.Collections.Generic;
using System.Text;

namespace SwordWarriors
{
    public class ContadorDuelo : Animacion
    {

        public ContadorDuelo(ConsoleColor color)
        {

            this.sprites = new List<Sprite>();

            Sprite sprite1 = new Sprite();
            Sprite sprite2 = new Sprite();
            Sprite sprite3 = new Sprite();
            Sprite sprite4 = new Sprite();

            sprite1.refpuntos = new List<Punto>  //Numero 1 dibujado
            {
                new Punto(0,0,color),new Punto(1,-1,color),new Punto(0,-2,color),new Punto(-1,-2,color),new Punto(1,1,color),new Punto(0,2,color),new Punto(-1,2,color)
            };
            sprite2.refpuntos = new List<Punto> //Numero 2 dibujado
            {
                new Punto(0,0,color),new Punto(1,-1,color),new Punto(0,-2,color),new Punto(-1,-2,color),new Punto(-1,1,color),new Punto(0,2,color),new Punto(1,2,color)
            };
            sprite3.refpuntos = new List<Punto> //Numero 3 dibujado
            {
                new Punto(0,0,color),new Punto(0,-1,color),new Punto(0,-2,color),new Punto(-1,-1,color),new Punto(0,1,color),new Punto(0,2,color)
            };
            sprite4.refpuntos = new List<Punto> //Palabra Duelo dibujada
            {
                new Punto(-9,-2,color),new Punto(-9,-1,color),new Punto(-9,0,color),new Punto(-9,1,color),new Punto(-9,2,color),
                new Punto(-8,-2,color),new Punto(-8,2,color),
                new Punto(-7,-1,color),new Punto(-7,0,color),new Punto(-7,1,color),
                new Punto(-5,-2,color),new Punto(-5,-1,color),new Punto(-5,0,color),new Punto(-5,1,color),
                new Punto(-4,2,color),
                new Punto(-3,-2,color),new Punto(-3,-1,color),new Punto(-3,0,color),new Punto(-3,1,color),
                new Punto(-1,-1,color),new Punto(-1,0,color),new Punto(-1,1,color),
                new Punto(0,-2,color),new Punto(0,0,color),new Punto(0,2,color),
                new Punto(1,-2,color),new Punto(1,2,color),
                new Punto(3,-2,color),new Punto(3,-1,color),new Punto(3,0,color),new Punto(3,1,color),
                new Punto(4,2,color),
                new Punto(5,2,color),
                new Punto(7,-2,color),new Punto(7,-1,color),new Punto(7,0,color),new Punto(7,2,color)
            };

            this.sprites.Add(sprite1);
            this.sprites.Add(sprite2);
            this.sprites.Add(sprite3);
            this.sprites.Add(sprite4);

        }
    }
}
