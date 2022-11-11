using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace SwordWarriors
{
    public class Jugador1 : Jugador
    {
        public Jugador1() : base(direcciones.derecha, 1, 100, 15, 19, KeyCode.Q,
            KeyCode.E, KeyCode.C, KeyCode.V,KeyCode.B, ConsoleColor.Red, ConsoleColor.DarkGray, ConsoleColor.Black, 25, 30)
        {
            this.sonido_heridogritos = new List<SoundPlayer>
            {
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\herido9.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\herido2.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\herido10.wav")
            };

            this.sonido_muertegritos = new List<SoundPlayer>
            {
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\gritomuerte1.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\gritomuerte2.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\gritomuerte6.wav")
            };

        }
    }
}   