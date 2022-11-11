using System;
using System.Threading.Tasks.Dataflow;
using System.IO;
using System.Threading;

namespace SwordWarriors
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            ConsoleKeyInfo input;

            Juego SwordWarriors = new Juego();

            Console.Title = "SWORD WARRIORS";
            Console.CursorVisible = false;


            try
            {
                Console.SetWindowSize(120, 50);
            }
            catch
            {
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            }

            while (salir == false)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();



                if (!File.Exists(Environment.CurrentDirectory + @"\Sonidos\atacarfuerte1.wav"))
                {
                    Console.WriteLine("You need folder sonidos with the game's wav files. Copy folder in game's directory \n \n Closing...");
                    Thread.Sleep(5000);
                    salir = true;
                }
                else
                {
                    //Bienvenido
                    Console.WriteLine("****************************************************************************************** \n");
                    Console.WriteLine(" - SWORD WARRIORS - \n");
                    Console.WriteLine(" - videojuego de combate para 2 jugadores desarrollado por: \n \n Maira Marinelli (maimari2000@gmail.com) y Guido Yebara (guido.e.yebara@gmail.com) - \n");
                    Console.WriteLine("****************************************************************************************** \n \n");
                    Console.WriteLine(" - Controles - \n \n");
                    Console.WriteLine("Jugador 1: \n Caminar hacia la der.  -  E\n Caminar hacia la izq.  -  Q\n Ataque  -  C\n Golpe Fuerte  -  V\n Defensa  -  B\n\n");
                    Console.WriteLine("Jugador 2: \n Caminar hacia la der.  -  Flecha der.\n Caminar hacia la izq.  -  Flecha izq.\n Ataque  -  I\n Defensa  -  O\n Golpe Fuerte  -  P");
                    Console.WriteLine("\n\nIMPORTANTE: \n \n 1) El juego tiene sonido. Por favor, sea tan amable de subir el volumen \n");
                    Console.WriteLine(" 2) Cuando abra el juego por primera vez, haga click derecho en la ventana, 'propiedades', \n vaya a la solapa 'fuente' y elija 'fuente de mapa de bits', como fuente. Tamaño, 8x8\n");
                    Console.WriteLine("Comenzar juego o Salir? (C o S)");

                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    input = Console.ReadKey();

                    if (input.Key == ConsoleKey.C)
                    {
                        SwordWarriors.Jugar();
                    }
                    else if (input.Key == ConsoleKey.S)
                    {
                        salir = true;
                    }
                }
            }
            return;
        }
    }
}
