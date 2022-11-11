using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace SwordWarriors
{
    //Female character
    public class Jugador2 : Jugador
    {

        public Jugador2() : base(direcciones.izquierda, 1, 100, 124, 19, KeyCode.Left, KeyCode.Right, KeyCode.I, KeyCode.O,
            KeyCode.P, ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.DarkGray, 90, 30)
        {
            this.sonido_heridogritos = new List<SoundPlayer>
            {
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\herido5.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\herido6.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\herido8.wav")
            };

            this.sonido_muertegritos = new List<SoundPlayer>
            {
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\gritomuerte3.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\gritomuerte4.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\gritomuerte5.wav")
            };
        }
    }
}

