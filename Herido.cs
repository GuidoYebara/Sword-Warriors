using System;
using System.Collections.Generic;
using System.Text;

namespace SwordWarriors
{
    public class Herido : Animacion
    {
        public Herido(ConsoleColor colorescudo, ConsoleColor colorespada, ConsoleColor colorcuerpo)
        {
            this.sprites = new List<Sprite>();
            this.hitboxes = new List<Hitbox>();

            Sprite sprite1 = new Sprite();
            Sprite sprite2 = new Sprite();

            Hitbox hitbox1 = new Hitbox();
            Hitbox hitbox2 = new Hitbox();

            //El punto central es el punto por debajo del cuello
            sprite1.refpuntos = new List<Punto>
            {
                /*Cabeza:*/new Punto(0,-3,colorcuerpo),new Punto(1,-3,colorcuerpo),new Punto(0,-2,colorcuerpo),new Punto(1,-2,colorcuerpo),

                /*Cuerpo:*/new Punto(0,-1,colorcuerpo),new Punto(0,0,colorcuerpo),new Punto(-1,1,colorcuerpo),new Punto(0,1,colorcuerpo),new Punto(1,1,colorcuerpo),
                new Punto(0,2,colorcuerpo),new Punto(2,2,colorcuerpo),new Punto(0,3,colorcuerpo),

                /*Pierna I:*/new Punto(-1,4,colorcuerpo),new Punto(-1,5,colorcuerpo),new Punto(-2,6,colorcuerpo),new Punto(-3,7,colorcuerpo),

                /*Pierna D:*/new Punto(1,4,colorcuerpo),new Punto(2,5,colorcuerpo),new Punto(2,6,colorcuerpo),new Punto(2,7,colorcuerpo),

                /*Escudo:*/new Punto(-4,0,colorescudo),new Punto(-3,0,colorescudo),new Punto(-2,0,colorescudo),new Punto(-4,1,colorescudo),
                new Punto(-3,1,colorescudo),new Punto(-2,1,colorescudo),new Punto(-4,2,colorescudo),new Punto(-3,2,colorescudo),
                new Punto(-2,2,colorescudo),new Punto(-4,3,colorescudo),new Punto(-3,3,colorescudo),new Punto(-2,3,colorescudo),
                new Punto(-3,4,colorescudo),

                /*Espada:*/new Punto(4,2,colorespada),new Punto(3,3,colorespada),new Punto(2,4,colorespada),new Punto(4,4,colorespada),
                new Punto(5,4,colorespada),new Punto(6,4,colorespada),new Punto(7,5,colorespada),new Punto(8,5,colorespada),new Punto(9,5,colorespada),
               
                /*Sangre:*/new Punto(2,-1,ConsoleColor.Red),new Punto(0,1,ConsoleColor.Red),new Punto(1,2,ConsoleColor.Red)

            };

            sprite2.refpuntos = new List<Punto>
            {
                /*Cabeza:*/new Punto(0,-3,colorcuerpo),new Punto(1,-3,colorcuerpo),new Punto(0,-2,colorcuerpo),new Punto(1,-2,colorcuerpo),

                /*Cuerpo:*/new Punto(0,-1,colorcuerpo),new Punto(0,0,colorcuerpo),new Punto(-1,0,colorcuerpo),new Punto(1,0,colorcuerpo),
                new Punto(3,0,colorcuerpo),new Punto(-2,1,colorcuerpo),new Punto(0,1,colorcuerpo),new Punto(2,1,colorcuerpo),new Punto(0,3,colorcuerpo),
                new Punto(0,2,colorcuerpo),

                /*Pierna I:*/new Punto(-1,4,colorcuerpo),new Punto(-1,5,colorcuerpo),new Punto(-2,6,colorcuerpo),new Punto(-3,7,colorcuerpo),

                /*Pierna D:*/new Punto(1,4,colorcuerpo),new Punto(2,5,colorcuerpo),new Punto(2,6,colorcuerpo),new Punto(2,7,colorcuerpo),

                /*Escudo:*/new Punto(-5,0,colorescudo),new Punto(-4,0,colorescudo),new Punto(-3,0,colorescudo),new Punto(-5,1,colorescudo),
                new Punto(-4,1,colorescudo),new Punto(-3,1,colorescudo),new Punto(-5,2,colorescudo),new Punto(-4,2,colorescudo),
                new Punto(-3,2,colorescudo),new Punto(-5,3,colorescudo),new Punto(-4,3,colorescudo),new Punto(-3,3,colorescudo),new Punto(-4,4,colorescudo),      

                /*Espada:*/new Punto(5,0,colorespada),new Punto(4,1,colorespada),new Punto(3,2,colorespada),new Punto(5,2,colorespada),new Punto(6,2,colorespada),new Punto(7,2,colorespada),
                 new Punto(8,2,colorespada),new Punto(9,3,colorespada),new Punto(10,3,colorespada),

                /*Sangre:*/new Punto(-4,-2,ConsoleColor.Red),new Punto(-1,-1,ConsoleColor.Red),new Punto(-1,2,ConsoleColor.Red),new Punto(-2,4,ConsoleColor.Red),
                new Punto(-5,5,ConsoleColor.Red),new Punto(1,1,ConsoleColor.Red),new Punto(1,2,ConsoleColor.Red),new Punto(3,-1,ConsoleColor.Red),
                new Punto(4,-4,ConsoleColor.Red),new Punto(5,4,ConsoleColor.Red),new Punto(6,7,ConsoleColor.Red)
            };

            this.sprites.Add(sprite1);
            this.sprites.Add(sprite2);

            hitbox1.refhitboxes = new List<Punto>
            {
                //new Punto(3,2),new Punto(3,1),new Punto(3,0),new Punto(3,-1),new Punto(3,-2)

                new Punto(-1,2),new Punto(-1,1),new Punto(-1,0),new Punto(-1,-1),new Punto(-1,-2),
                new Punto(1,2),new Punto(1,1),new Punto(1,0),new Punto(1,-1),new Punto(1,-2)

            };
            hitbox2.refhitboxes = new List<Punto>
            {               
                //new Punto(3,2),new Punto(3,1),new Punto(3,0),new Punto(3,-1),new Punto(3,-2)

                new Punto(-1,2),new Punto(-1,1),new Punto(-1,0),new Punto(-1,-1),new Punto(-1,-2),
                new Punto(1,2),new Punto(1,1),new Punto(1,0),new Punto(1,-1),new Punto(1,-2)

            };


            this.hitboxes.Add(hitbox1);
            this.hitboxes.Add(hitbox2);
        }
    }
}

 