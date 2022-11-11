using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Media;

namespace SwordWarriors
{
    public class Juego
    {
        public Jugador1 jugador1 { get; set; }
        public Jugador2 jugador2 { get; set; }
        public ContadorDuelo conduel { get; set; }
        public Luna luna { get; set; }
        public Thread tjug1_a { get; set; }
        public Thread tjug1_b { get; set; }
        public Thread tjug2_c { get; set; }
        public Thread tjug2_d { get; set; }
        public ConsoleColor colordelfondo { get; set; }
        bool muerte { get; set; }
        public Puntaje puntaje1 { get; set; }
        public Puntaje puntaje2{ get; set; }

        public Juego()
        {
            this.puntaje1 = new Puntaje(ConsoleColor.DarkYellow);
            this.puntaje2 = new Puntaje(ConsoleColor.DarkYellow);
        }

        public void Jugar()
        {
            int i;
            //TODO EL FONDO
            this.colordelfondo = ConsoleColor.DarkBlue;

            Console.BackgroundColor = this.colordelfondo;

            Console.Clear();

            //CARGAR TODOS LOS RECURSOS
            this.CargarRecursos();

            //Dibujar controles

            OtrosMetodos.pintar(20, 38, ConsoleColor.DarkBlue, ConsoleColor.White, "Jugador 1:");
            OtrosMetodos.pintar(20, 40, ConsoleColor.DarkBlue, ConsoleColor.White, "Moverse der.  -  E");
            OtrosMetodos.pintar(20, 41, ConsoleColor.DarkBlue, ConsoleColor.White, "Moverse izq.  -  Q");
            OtrosMetodos.pintar(20, 42, ConsoleColor.DarkBlue, ConsoleColor.White, "Ataque  -  C");
            OtrosMetodos.pintar(20, 43, ConsoleColor.DarkBlue, ConsoleColor.White, "Golpe Fuerte  -  V");
            OtrosMetodos.pintar(20, 44, ConsoleColor.DarkBlue, ConsoleColor.White, "Defensa  -  B");

            OtrosMetodos.pintar(85, 38, ConsoleColor.DarkBlue, ConsoleColor.White, "Jugador 2:");
            OtrosMetodos.pintar(85, 40, ConsoleColor.DarkBlue, ConsoleColor.White, "Moverse der.  -  Flecha D");
            OtrosMetodos.pintar(85, 41, ConsoleColor.DarkBlue, ConsoleColor.White, "Moverse izq.  -  Flecha I");
            OtrosMetodos.pintar(85, 42, ConsoleColor.DarkBlue, ConsoleColor.White, "Ataque  -  I");
            OtrosMetodos.pintar(85, 43, ConsoleColor.DarkBlue, ConsoleColor.White, "Golpe Fuerte  -  O");
            OtrosMetodos.pintar(85, 44, ConsoleColor.DarkBlue, ConsoleColor.White, "Defensa  -  P");
            

            this.DibujarInicio();

            //Inicializa los threads donde se ejecuta toda la lógica de los jugadores y los controles
            this.IniciarActualizar();


            MusicalizarInicio();

            //Countdown and start
            conduel = new ContadorDuelo(ConsoleColor.Red);

            for (i = 1; i < 5; i++)
            {
                conduel.Dibujar(new Punto(60, 17), i);
                Thread.Sleep(1100);
                conduel.BorrarDibujo(new Punto(60, 17), i, this.colordelfondo);
            }

            conduel = null;

            //QUE EMPIECE EL DUELO!
            jugador1.inputEvent.Set();
            jugador2.inputEvent.Set();

            //Main thread va a esperar a que terminen los 4 threads
            tjug1_a.Join();
            tjug1_b.Join();
            tjug2_c.Join();
            tjug2_d.Join();

            //Dibujar score final

            DibujarPuntaje();

            if (this.puntaje1.numero == 3)
            {
                MusicalizarFinal(true);

                OtrosMetodos.pintar(35, 11, ConsoleColor.DarkBlue, ConsoleColor.DarkYellow, "JUGADOR 1 HA GANADO !!!!! ");

                this.puntaje1 = null;
                this.puntaje2 = null;
                this.puntaje1 = new Puntaje(ConsoleColor.DarkYellow);
                this.puntaje2 = new Puntaje(ConsoleColor.DarkYellow);

                Thread.Sleep(5500);
                //DESCARGAR TODOS LOS RECURSOS
                this.DescargarRecursos();   
            }
            else if (this.puntaje2.numero == 3)
            {
                MusicalizarFinal(true);

                OtrosMetodos.pintar(35, 11, ConsoleColor.DarkBlue, ConsoleColor.DarkYellow, "JUGADOR 2 HA GANADO !!!!! ");

                this.puntaje1 = null;
                this.puntaje2 = null;
                this.puntaje1 = new Puntaje(ConsoleColor.DarkYellow);
                this.puntaje2 = new Puntaje(ConsoleColor.DarkYellow);

                Thread.Sleep(5500);
                //DESCARGAR TODOS LOS RECURSOS
                this.DescargarRecursos();
            }
            else
            {
                MusicalizarFinal(false);

                this.puntaje1.numeroanterior = this.puntaje1.numero;
                this.puntaje2.numeroanterior = this.puntaje2.numero;

                Thread.Sleep(5500);
                //DESCARGAR TODOS LOS RECURSOS
                this.DescargarRecursos();

                this.Jugar();
            }
                
        }

        public void CargarRecursos()
        {
            this.jugador1 = new Jugador1();
            this.jugador2 = new Jugador2();

            this.jugador1.otrojug = jugador2;
            this.jugador2.otrojug = jugador1;

            this.jugador1.puntaje = this.puntaje1;
            this.jugador2.puntaje = this.puntaje2;

            this.jugador1.colordelfondo = colordelfondo;
            this.jugador2.colordelfondo = colordelfondo;

        }

        public void DibujarInicio()
        {
            int i = 0;

            this.luna = new Luna();

            for (i = 10; i < 110; i++)
            {
                OtrosMetodos.pintar(i, 27, ConsoleColor.DarkGreen);
            }

            DibujarPuntaje();

        }

        public void IniciarActualizar()
        {


            tjug1_a = new Thread(() => jugador1.Actualizar());

            tjug1_b = new Thread(() => jugador1.LeerInput());

            tjug2_c = new Thread(() => jugador2.Actualizar());

            tjug2_d = new Thread(() => jugador2.LeerInput());

            tjug1_a.Start();
            tjug1_b.Start();
            tjug2_c.Start();
            tjug2_d.Start();

        }

        public void DescargarRecursos()
        {
            this.jugador1 = null;
            this.jugador2 = null;
            this.luna = null;

            this.tjug1_a = null;
            this.tjug1_b = null;
            this.tjug2_c = null;
            this.tjug2_d = null;

        }


        public void MusicalizarInicio()
        {
            Random rnd = new Random();
            int r = 0;

            List<SoundPlayer> musica = new List<SoundPlayer>
            {
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\musicainicio1.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\musicainicio2.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\musicainicio3.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\musicainicio4.wav")

            };

            r = rnd.Next(musica.Count);
            musica[r].Play();

            rnd = null;
            musica = null;
        }

        private void MusicalizarFinal(bool final)
        {
            Random rnd = new Random();
            int r = 0;

            if(final == true)
            {
                SoundPlayer musica2 = new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\musicafinal4.wav");
                musica2.Play();
                musica2 = null;
            }
            else
            {
                List<SoundPlayer> musica = new List<SoundPlayer>
                {
                    new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\musicafinal1.wav"),
                    new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\musicafinal2.wav"),
                    new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\musicafinal3.wav"),
                    new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\musicafinal4.wav")

                };

                r = rnd.Next(musica.Count);
                musica[r].Play();
                musica = null;

            }
            
            rnd = null;

        }

        private void DibujarPuntaje()
        {
            this.puntaje1.BorrarDibujo(new Punto(24, 5), this.puntaje1.numeroanterior + 1,this.colordelfondo);
            this.puntaje2.BorrarDibujo(new Punto(95, 5), this.puntaje2.numeroanterior + 1, this.colordelfondo);

            this.puntaje1.Dibujar(new Punto(24, 5), this.puntaje1.numero + 1);
            this.puntaje2.Dibujar(new Punto(95, 5), this.puntaje2.numero + 1);
        }
    }
}
