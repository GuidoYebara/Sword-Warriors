using System;
using System.Collections.Generic;
using System.Text;

namespace SwordWarriors
{
    public class Movimiento : Animacion
    {
        public Movimiento(ConsoleColor colorescudo, ConsoleColor colorespada, ConsoleColor colorcuerpo)
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
                /*Cabeza:*/new Punto(0,-3,colorcuerpo),new Punto(0,-2,colorcuerpo),new Punto(0,-1,colorcuerpo),
                new Punto(1,-3,colorcuerpo),new Punto(1,-2,colorcuerpo),

                /*Cuerpo:*/new Punto(0,0,colorcuerpo),new Punto(0,1,colorcuerpo),new Punto(0,2,colorcuerpo),new Punto(0,3,colorcuerpo),
                new Punto(1,0,colorcuerpo),new Punto(1,1,colorcuerpo),new Punto(2,2,colorcuerpo),new Punto(3,1,colorcuerpo),

                /*Pierna I:*/new Punto(-1,4,colorcuerpo),new Punto(-1,5,colorcuerpo),new Punto(-1,6,colorcuerpo),new Punto(-2,7,colorcuerpo),

                /*Pierna D:*/new Punto(1,4,colorcuerpo),new Punto(2,5,colorcuerpo),new Punto(2,6,colorcuerpo),

                /*Escudo:*/new Punto(-3,0,colorescudo),new Punto(-3,1,colorescudo),new Punto(-3,2,colorescudo),new Punto(-3,3,colorescudo),
                new Punto(-2,0,colorescudo),new Punto(-2,1,colorescudo),new Punto(-2,2,colorescudo),new Punto(-2,3,colorescudo),
                new Punto(-2,4,colorescudo),new Punto(-1,0,colorescudo),new Punto(-1,1,colorescudo),new Punto(-1,2,colorescudo),
                new Punto(-1,3,colorescudo),

                /*Espada:*/new Punto(4,0,colorespada),new Punto(4,1,colorespada),new Punto(4,2,colorespada),new Punto(5,1,colorespada),
                new Punto(6,1,colorespada),new Punto(7,1,colorespada),new Punto(8,2,colorespada),new Punto(9,2,colorespada),
                new Punto(10,2,colorespada),
            };
            sprite2.refpuntos = new List<Punto>
            {
                /*Cabeza:*/new Punto(0,-3,colorcuerpo),new Punto(0,-2,colorcuerpo),new Punto(0,-1,colorcuerpo),
                new Punto(1,-3,colorcuerpo),new Punto(1,-2,colorcuerpo),

                /*Cuerpo:*/new Punto(0,0,colorcuerpo),new Punto(0,1,colorcuerpo),new Punto(0,2,colorcuerpo),new Punto(0,3,colorcuerpo),
                new Punto(1,0,colorcuerpo),new Punto(1,1,colorcuerpo),new Punto(2,2,colorcuerpo),new Punto(3,2,colorcuerpo),

                /*Pierna I:*/new Punto(-1,4,colorcuerpo),new Punto(-1,5,colorcuerpo),new Punto(-2,6,colorcuerpo),new Punto(-2,7,colorcuerpo),

                /*Pierna D:*/new Punto(1,4,colorcuerpo),new Punto(2,5,colorcuerpo),new Punto(1,6,colorcuerpo),

                /*Escudo:*/new Punto(-3,0,colorescudo),new Punto(-3,1,colorescudo),new Punto(-3,2,colorescudo),new Punto(-3,3,colorescudo),
                new Punto(-2,0,colorescudo),new Punto(-2,1,colorescudo),new Punto(-2,2,colorescudo),new Punto(-2,3,colorescudo),
                new Punto(-2,4,colorescudo),new Punto(-1,0,colorescudo),new Punto(-1,1,colorescudo),new Punto(-1,2,colorescudo),
                new Punto(-1,3,colorescudo),
                
                /*Espada:*/new Punto(4,1,colorespada),new Punto(4,2,colorespada),new Punto(4,3,colorespada),new Punto(5,2,colorespada),
                new Punto(6,2,colorespada),new Punto(7,2,colorespada),new Punto(8,3,colorespada),new Punto(9,3,colorespada),
                new Punto(10,3,colorespada),
                ///*Espada:*/new Punto(4,1,colorespada),new Punto(4,2,colorespada),new Punto(4,3,colorespada),new Punto(5,2,colorespada),
                //new Punto(6,2,colorespada),new Punto(7,3,colorespada),new Punto(8,3,colorespada),new Punto(9,4,colorespada),
                //new Punto(10,4,colorespada),

            };
            sprite3.refpuntos = new List<Punto>
            {
                /*Cabeza:*/new Punto(0,-3,colorcuerpo),new Punto(0,-2,colorcuerpo),new Punto(0,-1,colorcuerpo),
                new Punto(1,-3,colorcuerpo),new Punto(1,-2,colorcuerpo),

                /*Cuerpo:*/new Punto(0,0,colorcuerpo),new Punto(0,1,colorcuerpo),new Punto(0,2,colorcuerpo),new Punto(0,3,colorcuerpo),
                new Punto(1,0,colorcuerpo),new Punto(1,1,colorcuerpo),new Punto(2,2,colorcuerpo),new Punto(3,1,colorcuerpo),

                /*Pierna I:*/new Punto(-1,4,colorcuerpo),new Punto(-1,5,colorcuerpo),new Punto(-2,6,colorcuerpo),new Punto(-3,7,colorcuerpo),

                /*Pierna D:*/new Punto(1,4,colorcuerpo),new Punto(2,5,colorcuerpo),new Punto(2,6,colorcuerpo),new Punto(2,7,colorcuerpo),

                /*Escudo:*/new Punto(-3,0,colorescudo),new Punto(-3,1,colorescudo),new Punto(-3,2,colorescudo),new Punto(-3,3,colorescudo),
                new Punto(-2,0,colorescudo),new Punto(-2,1,colorescudo),new Punto(-2,2,colorescudo),new Punto(-2,3,colorescudo),
                new Punto(-2,4,colorescudo),new Punto(-1,0,colorescudo),new Punto(-1,1,colorescudo),new Punto(-1,2,colorescudo),
                new Punto(-1,3,colorescudo),

                /*Espada:*/new Punto(4,0,colorespada),new Punto(4,1,colorespada),new Punto(4,2,colorespada),new Punto(5,1,colorespada),
                new Punto(6,1,colorespada),new Punto(7,1,colorespada),new Punto(8,2,colorespada),new Punto(9,2,colorespada),
                new Punto(10,2,colorespada),

            };

            this.sprites.Add(sprite1);
            this.sprites.Add(sprite2);
            this.sprites.Add(sprite3);

            hitbox1.refhitboxes = new List<Punto>
            {
                // new Punto(-3,2),new Punto(-3,1),new Punto(-3,0),new Punto(-3,-1),new Punto(-3,-2),
                // new Punto(3,2),new Punto(3,1),new Punto(3,0),new Punto(3,-1),new Punto(3,-2)
                //new Punto(-2,2),new Punto(-2,1),new Punto(-2,0),new Punto(-2,-1),new Punto(-2,-2),
                //new Punto(2,2),new Punto(2,1),new Punto(2,0),new Punto(2,-1),new Punto(2,-2)

                new Punto(-1,0),new Punto(0,0),new Punto(1,0)

            };
            hitbox2.refhitboxes = new List<Punto>
            {
              //  new Punto(-3,2),new Punto(-3,1),new Punto(-3,0),new Punto(-3,-1),new Punto(-3,-2),
               // new Punto(10,2),new Punto(10,1),new Punto(10,0),new Punto(10,-1),new Punto(10,-2)
                //new Punto(-2,2),new Punto(-2,1),new Punto(-2,0),new Punto(-2,-1),new Punto(-2,-2),
                //new Punto(2,2),new Punto(2,1),new Punto(2,0),new Punto(2,-1),new Punto(2,-2)
                new Punto(-1,0),new Punto(0,0),new Punto(1,0)
            };
            hitbox3.refhitboxes = new List<Punto>
            {
              // new Punto(-3,2),new Punto(-3,1),new Punto(-3,0),new Punto(-3,-1),new Punto(-3,-2),
             //  new Punto(10,2),new Punto(10,1),new Punto(10,0),new Punto(10,-1),new Punto(10,-2)
                //new Punto(-2,2),new Punto(-2,1),new Punto(-2,0),new Punto(-2,-1),new Punto(-2,-2),
                //new Punto(2,2),new Punto(2,1),new Punto(2,0),new Punto(2,-1),new Punto(2,-2)
                new Punto(-1,0),new Punto(0,0),new Punto(1,0)
            };

            this.hitboxes.Add(hitbox1);
            this.hitboxes.Add(hitbox2);
            this.hitboxes.Add(hitbox3);

        }
    }
}
