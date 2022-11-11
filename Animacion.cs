using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SwordWarriors
{
    public abstract class Animacion
    {
        public List<Sprite> sprites { get; set; }
        public List<Hitbox> hitboxes { get; set; }

        public void Dibujar(Punto centro, int paso, direcciones direccion)
        {
            foreach (Punto p in this.sprites[paso - 1].refpuntos)
            {
                OtrosMetodos.pintar(centro.x + p.x*(int)direccion, centro.y + p.y, p.color);
            }

        }

        public void BorrarDibujo(Punto centro, int paso, direcciones direccion,ConsoleColor colorfondo)
        {
            foreach (Punto p in this.sprites[paso - 1].refpuntos)
            {
                OtrosMetodos.pintar(centro.x + p.x*(int)direccion, centro.y + p.y, colorfondo);
            }
        }

        public void Dibujar(Punto centro, int paso)
        {
            foreach (Punto p in this.sprites[paso - 1].refpuntos)
            {
                OtrosMetodos.pintar(centro.x + p.x , centro.y + p.y, p.color);
            }

        }

        public void BorrarDibujo(Punto centro, int paso, ConsoleColor colorfondo)
        {
            foreach (Punto p in this.sprites[paso - 1].refpuntos)
            {
                OtrosMetodos.pintar(centro.x + p.x, centro.y + p.y, colorfondo);
            }
        }
    }
}
