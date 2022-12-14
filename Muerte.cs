using System;
using System.Collections.Generic;
using System.Text;

namespace SwordWarriors
{
    public class Muerte : Animacion
    {
        public Muerte(ConsoleColor colorescudo, ConsoleColor colorespada, ConsoleColor colorcuerpo)
        {
            this.sprites = new List<Sprite>();
            this.hitboxes = new List<Hitbox>();

            Sprite sprite1 = new Sprite();
            Sprite sprite2 = new Sprite();
            Sprite sprite3 = new Sprite();

            Hitbox hitbox1 = new Hitbox();
            Hitbox hitbox2 = new Hitbox();
            Hitbox hitbox3 = new Hitbox();

            //El punto central es el punto por debajo del cuello
            sprite1.refpuntos = new List<Punto>
            {
                /*Cabeza:*/new Punto(0,-1,colorcuerpo),new Punto(1,-1,colorcuerpo),new Punto(0,0,colorcuerpo),
                new Punto(1,0,colorcuerpo),

                /*Cuerpo:*/new Punto(0,1,colorcuerpo),new Punto(-1,2,colorcuerpo),new Punto(0,2,colorcuerpo),new Punto(1,2,colorcuerpo),
                new Punto(-2,3,colorcuerpo),new Punto(0,3,colorcuerpo),new Punto(1,3,colorcuerpo),new Punto(0,4,colorcuerpo),

                /*Pierna I:*/new Punto(0,5,colorcuerpo),new Punto(0,6,colorcuerpo),new Punto(-2,7,colorcuerpo),new Punto(-1,7,colorcuerpo),
                new Punto(0,7,colorcuerpo),

                /*Pierna D:*/new Punto(1,5,colorcuerpo),new Punto(2,5,colorcuerpo),new Punto(3,6,colorcuerpo),new Punto(2,7,colorcuerpo),
              
                /*Escudo:*/new Punto(-5,3,colorescudo),new Punto(-4,3,colorescudo),new Punto(-6,4,colorescudo),new Punto(-5,4,colorescudo),
                new Punto(-4,4,colorescudo),new Punto(-3,4,colorescudo),new Punto(-6,5,colorescudo),new Punto(-5,5,colorescudo),
                new Punto(-4,5,colorescudo),new Punto(-3,5,colorescudo),new Punto(-5,6,colorescudo),new Punto(-4,6,colorescudo),
                new Punto(-3,6,colorescudo),

                /*Espada:*/new Punto(3,2,colorespada),new Punto(2,3,colorespada),new Punto(3,4,colorespada),new Punto(4,5,colorespada),
                new Punto(5,6,colorespada),new Punto(6,7,colorespada)
            };

            sprite2.refpuntos = new List<Punto>
            {
                /*Cabeza:*/new Punto(0,0,colorcuerpo),new Punto(1,0,colorcuerpo),new Punto(0,1,colorcuerpo),new Punto(1,1,colorcuerpo),

                /*Cuerpo:*/new Punto(0,2,colorcuerpo),new Punto(0,3,colorcuerpo),new Punto(1,3,colorcuerpo),new Punto(0,4,colorcuerpo),
                new Punto(2,4,colorcuerpo),new Punto(3,5,colorcuerpo),new Punto(4,6,colorcuerpo),

                /*Pierna I:*/new Punto(0,5,colorcuerpo),new Punto(-1,6,colorcuerpo),new Punto(-3,7,colorcuerpo),new Punto(-2,7,colorcuerpo),

                /*Pierna D:*/new Punto(1,5,colorcuerpo),new Punto(2,6,colorcuerpo),new Punto(1,7,colorcuerpo),

                /*Escudo:*/new Punto(-6,5,colorescudo),new Punto(-5,5,colorescudo),new Punto(-4,5,colorescudo),new Punto(-7,6,colorescudo),
                new Punto(-6,6,colorescudo),new Punto(-5,6,colorescudo),new Punto(-4,6,colorescudo),new Punto(-3,6,colorescudo),                

                /*Espada:*/new Punto(3,7,colorespada),new Punto(2,8,colorespada),new Punto(4,8,colorespada),new Punto(1,9,colorespada),
                new Punto(0,10,colorespada),new Punto(-1,11,colorespada)
            };

            sprite3.refpuntos = new List<Punto>
            {
                /*Cabeza:*/new Punto(-5,6,colorcuerpo),new Punto(-4,6,colorcuerpo),new Punto(-5,7,colorcuerpo),
                new Punto(-4,7,colorcuerpo),

                /*Cuerpo:*/new Punto(-3,7,colorcuerpo),new Punto(-2,7,colorcuerpo),new Punto(-1,7,colorcuerpo),new Punto(0,7,colorcuerpo),
                new Punto(-2,8,colorcuerpo),new Punto(-1,9,colorcuerpo),

                /*Piernas:*/new Punto(1,6,colorcuerpo),new Punto(2,5,colorcuerpo),new Punto(3,6,colorcuerpo),new Punto(1,7,colorcuerpo),
                new Punto(2,7,colorcuerpo),new Punto(3,7,colorcuerpo),new Punto(4,7,colorcuerpo),new Punto(5,7,colorcuerpo),

                /*Escudo:*/new Punto(-10,6,colorescudo),new Punto(-9,6,colorescudo),new Punto(-8,6,colorescudo),new Punto(-11,7,colorescudo),
                new Punto(-10,7,colorescudo),new Punto(-9,7,colorescudo),new Punto(-8,7,colorescudo),

                /*Espada:*/new Punto(-3,9,colorespada),new Punto(-2,10,colorespada),new Punto(-3,11,colorespada),new Punto(-1,11,colorespada),
                new Punto(-4,12,colorespada),new Punto(-5,13,colorespada),new Punto(-6,14,colorespada),
            };


            this.sprites.Add(sprite1);
            this.sprites.Add(sprite2);
            this.sprites.Add(sprite3);

            hitbox1.refhitboxes = new List<Punto>
            {
                new Punto(1,0),new Punto(0,0),new Punto(-1,0),new Punto(-2,0),new Punto(-3,0)
            };
            hitbox2.refhitboxes = new List<Punto>
            {
                new Punto(1,0),new Punto(0,0),new Punto(-1,0),new Punto(-2,0),new Punto(-3,0)
            };
            hitbox3.refhitboxes = new List<Punto>
            {
                new Punto(1,0),new Punto(0,0),new Punto(-1,0),new Punto(-2,0),new Punto(-3,0)          
            };

            this.hitboxes.Add(hitbox1);
            this.hitboxes.Add(hitbox2);
            this.hitboxes.Add(hitbox3);
        }
    }
}
