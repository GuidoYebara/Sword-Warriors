using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace SwordWarriors
{
    static class OtrosMetodos
    {
        static readonly object _object = new object();

        static readonly object _object2 = new object();
        public static void pintar(int x, int y, ConsoleColor Color)
        {
            lock (_object)
            {
                Console.BackgroundColor = Color;
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
            }
            return;
        }

        public static void pintar(int x, int y, ConsoleColor ColorFondo, ConsoleColor ColorFrente,string texto)
        {
            lock (_object)
            {
                Console.BackgroundColor = ColorFondo;
                Console.ForegroundColor = ColorFrente;
                Console.SetCursorPosition(x, y);
                Console.Write(texto);
            }
            return;
        }

        public static void pintar(int x, int y)
        {
            lock (_object)
            {
                Console.SetCursorPosition(x, y);
            Console.Write(' ');
            }
            return;
        }
        

        public static bool TeclaPresionada(KeyCode key)
        {
            //Teclas https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes

            //Funcion GetAsyncKeyState, es una función importada de user32.dll, librería escrita en C
            //https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getasynckeystate

            //Se utilizó esta funcion porque Console.ReadKey no permite leer teclas simultaneamente para dos jugadores
            //lock(_object2)
           // { 
                return (GetKeyState((int)key) & 0x8000) != 0; //GetKeyState devuelve tipo de dato SHORT
            //}
        }
        [DllImport("user32.dll")]
        private static extern short GetKeyState(int key);
    }
}
