using System;
using System.Collections.Generic;
using System.Text;

namespace SwordWarriors
{
    public class AtaqueFuerte : Animacion
    {
        public AtaqueFuerte(ConsoleColor colorescudo, ConsoleColor colorespada, ConsoleColor colorcuerpo)
        {
            this.sprites = new List<Sprite>();
            this.hitboxes = new List<Hitbox>();

            Sprite sprite1 = new Sprite();
            Sprite sprite2 = new Sprite();
            Sprite sprite3 = new Sprite();

            Hitbox hitbox1 = new Hitbox();
            Hitbox hitbox2 = new Hitbox();
            Hitbox hitbox3 = new Hitbox();

            sprite1.refpuntos = new List<Punto>
            {
                /*Cabeza:*/new Punto(0,-3,colorcuerpo),new Punto(0,-2,colorcuerpo),new Punto(0,-1,colorcuerpo),
                new Punto(1,-3,colorcuerpo),new Punto(1,-2,colorcuerpo),

                /*Cuerpo:*/new Punto(0,0,colorcuerpo),new Punto(0,1,colorcuerpo),new Punto(0,2,colorcuerpo),new Punto(0,3,colorcuerpo),
                new Punto(1,1,colorcuerpo),new Punto(2,0,colorcuerpo),new Punto(3,-1,colorcuerpo),new Punto(3,-2,colorcuerpo),

                /*Pierna I:*/new Punto(-1,4,colorcuerpo),new Punto(-1,5,colorcuerpo),new Punto(-2,6,colorcuerpo),new Punto(-2,7,colorcuerpo),

                /*Pierna D:*/new Punto(1,4,colorcuerpo),new Punto(2,5,colorcuerpo),new Punto(2,6,colorcuerpo),new Punto(1,7,colorcuerpo),

                /*Escudo:*/new Punto(-3,0,colorescudo),new Punto(-3,1,colorescudo),new Punto(-3,2,colorescudo),new Punto(-3,3,colorescudo),
                new Punto(-2,0,colorescudo),new Punto(-2,1,colorescudo),new Punto(-2,2,colorescudo),new Punto(-2,3,colorescudo),
                new Punto(-2,4,colorescudo),new Punto(-1,0,colorescudo),new Punto(-1,1,colorescudo),new Punto(-1,2,colorescudo),
                new Punto(-1,3,colorescudo),

                /*Espada:*/new Punto(2,-3,colorespada),new Punto(3,-3,colorespada),new Punto(4,-3,colorespada),new Punto(3,-4,colorespada),
                new Punto(3,-5,colorespada),new Punto(3,-6,colorespada),new Punto(3,-7,colorespada),new Punto(3,-8,colorespada),
                new Punto(3,-9,colorespada)
            };

            sprite2.refpuntos = new List<Punto>
            {
                /*Cabeza:*/new Punto(0,-3,colorcuerpo),new Punto(0,-2,colorcuerpo),new Punto(0,-1,colorcuerpo),
                new Punto(1,-3,colorcuerpo),new Punto(1,-2,colorcuerpo),

                /*Cuerpo:*/new Punto(0,0,colorcuerpo),new Punto(0,1,colorcuerpo),new Punto(0,2,colorcuerpo),new Punto(0,3,colorcuerpo),
                new Punto(1,1,colorcuerpo),new Punto(2,0,colorcuerpo),

                /*Pierna I:*/new Punto(-1,4,colorcuerpo),new Punto(-1,5,colorcuerpo),new Punto(-2,6,colorcuerpo),new Punto(-2,7,colorcuerpo),

                /*Pierna D:*/new Punto(1,4,colorcuerpo),new Punto(2,5,colorcuerpo),new Punto(1,6,colorcuerpo),new Punto(2,4,colorcuerpo),

                /*Escudo:*/new Punto(-1,0,colorescudo),new Punto(-1,1,colorescudo),new Punto(-1,2,colorescudo),new Punto(-1,3,colorescudo),
                new Punto(-2,0,colorescudo),new Punto(-2,1,colorescudo),new Punto(-2,2,colorescudo),

                /*Espada:*/new Punto(4,0,colorespada),new Punto(3,-1,colorespada),new Punto(2,-2,colorespada),new Punto(4,-2,colorespada),
                new Punto(5,-3,colorespada),new Punto(6,-4,colorespada),new Punto(7,-5,colorespada),new Punto(8,-6,colorespada),

            };
            sprite3.refpuntos = new List<Punto>
            {
                /*Cabeza:*/new Punto(0,-3,colorcuerpo),new Punto(0,-2,colorcuerpo),new Punto(0,-1,colorcuerpo),
                new Punto(1,-3,colorcuerpo),new Punto(1,-2,colorcuerpo),

                /*Cuerpo:*///new Punto(0,0,colorcuerpo),new Punto(1,0,colorcuerpo),
                /*Cuerpo:*/new Punto(0,0,colorcuerpo),new Punto(0,1,colorcuerpo),new Punto(0,2,colorcuerpo),new Punto(0,3,colorcuerpo),
                new Punto(1,0,colorcuerpo),new Punto(2,1,colorcuerpo),new Punto(3,1,colorcuerpo),new Punto(4,1,colorcuerpo),new Punto(5,1,colorcuerpo),

                /*Pierna I:*/new Punto(-1,4,colorcuerpo),new Punto(-2,5,colorcuerpo),new Punto(-3,6,colorcuerpo),new Punto(-4,7,colorcuerpo),

                /*Pierna D:*/new Punto(1,4,colorcuerpo),new Punto(2,4,colorcuerpo),new Punto(3,5,colorcuerpo),new Punto(3,6,colorcuerpo),
                new Punto(2,7,colorcuerpo),

                /*Escudo:*/new Punto(-1,0,colorescudo),new Punto(-1,1,colorescudo),new Punto(-1,2,colorescudo),new Punto(-1,3,colorescudo),
                new Punto(-2,0,colorescudo),new Punto(-2,1,colorescudo),new Punto(-2,2,colorescudo),

                /*Espada:*/new Punto(6,0,colorespada),new Punto(6,1,colorespada),new Punto(6,2,colorespada),new Punto(7,1,colorespada),
                new Punto(8,1,colorespada),new Punto(9,1,colorespada),new Punto(10,1,colorespada),new Punto(11,1,colorespada),
                new Punto(12,1,colorespada)

            };

            this.sprites.Add(sprite1);
            this.sprites.Add(sprite2);
            this.sprites.Add(sprite3);

            hitbox1.refhitboxes = new List<Punto>
            {
                new Punto(0,0),new Punto(1,0),new Punto(2,0),new Punto(3,0)

            };
            hitbox2.refhitboxes = new List<Punto>
            {
                new Punto(0,0),new Punto(1,0),new Punto(2,0),new Punto(3,0)
            };
            hitbox3.refhitboxes = new List<Punto>
            {
               new Punto(12,0),new Punto(11,0),new Punto(10,0),new Punto(9,0),new Punto(8,0),new Punto(7,0),new Punto(6,0),new Punto(5,0)
            };

            this.hitboxes.Add(hitbox1);
            this.hitboxes.Add(hitbox2);
            this.hitboxes.Add(hitbox3);

        }
    }


}
