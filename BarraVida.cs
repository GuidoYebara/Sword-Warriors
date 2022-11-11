using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SwordWarriors
{
    public class BarraVida
    {
        public List<Punto> puntosvida { get; set; }
        public ConsoleColor colordelfondo { get; set; }
        public int vida { get; set; }

        public BarraVida(int posx, int posy, ConsoleColor colordelfondo)
        {
            this.colordelfondo = colordelfondo;

            this.vida = 100;

            int i = 0;

            this.puntosvida = new List<Punto>();

            for (i = 0; i < 10; i++)
                this.puntosvida.Add(new Punto(posx + i, posy, colordelfondo));

            OtrosMetodos.pintar(posx - 5, posy, colordelfondo, ConsoleColor.White, "Vida");

            this.Dibujar();
 
        }

        public void Dibujar()
        {
            foreach (Punto p in this.puntosvida)
            {
                OtrosMetodos.pintar(p.x, p.y, p.color);
            }

        }

        public void Actualizar(int quitarvida)
        {
            int aux = 0,i = 0;

            foreach (Punto p in this.puntosvida)
                OtrosMetodos.pintar(p.x, p.y, ConsoleColor.White);

            if (quitarvida == 5)
            {
                this.vida = this.vida - 5;

                if (this.vida % 2 == 0)
                {
                    aux = 100 - this.vida;
                    aux = aux / 10;
                    if (this.puntosvida.Count > 0)
                    {
                        this.puntosvida.RemoveAt(this.puntosvida.Count - 1);
                    }
                }
            }
            else if(quitarvida == 10)
            {
                this.vida = this.vida - 10;

                if (this.puntosvida.Count > 0)
                {
                    this.puntosvida.RemoveAt(this.puntosvida.Count - 1);
                }
            }
            else if (quitarvida == 30)
            {
                this.vida = this.vida - 30;

                for (i=0;i<3;i++)
                { 
                    if (this.puntosvida.Count > 0)
                    {
                        this.puntosvida.RemoveAt(this.puntosvida.Count - 1);
                    }
                }
            }

            this.Dibujar();
            return;
        }
    }
}
