using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Media;

namespace SwordWarriors
{
    public enum KeyCode : int
    {
        /// http://msdn.microsoft.com/en-us/library/dd375731%28v=VS.85%29.aspx
        Left = 0x25,
        Right = 0x27,
        Space = 0x20,
        LControl = 0xA2,
        RShift = 0xA1,
        RControl = 0xA3,
        Q = 0x51,
        E = 0x45,
        C = 0x43,
        V = 0x56,
        B = 0x42,
        I = 0x49,
        O = 0x4F,
        P = 0x50,
        A = 0x41,
        D = 0x44,
        S = 0x53,
        Numpad0 = 0x60,
        Numpad1 = 0x61,
        Numpad2 = 0x62,
        LShift = 0x10
    }

    public enum estados : int
    {
        reposo = 0,
        movimiento = 1,
        ataque = 2,
        defensa = 3,
        muerte = 4,
        herido = 5,
        inicio = 6,
        ataquefuerte= 7
    }
    public enum direcciones : int
    {
        derecha = 1,
        izquierda = -1
    }
    public abstract class Jugador
    {
        public Reposo reposo { get; set; }
        public Movimiento movimiento { get; set; }
        public Ataque ataque { get; set; }
        public Defensa defensa { get; set; }
        public Muerte muerte { get; set; }
        public Herido herido { get; set; }
        public AtaqueFuerte ataquefuerte { get; set; }
        public Punto centro { get; set; }
        public Punto centroanterior { get; set; }
        public Punto centro2 { get; set; }
        public Punto centroanterior2 { get; set; }
        public bool centrocambio { get; set; }

        public estados estado { get; set; }
        public estados estadoanterior { get; set; }
        public estados estadonuevo { get; set; }
        public direcciones direccion { get; set; }
        public int paso { get; set; }
        public int pasoanterior { get; set; }
        public int vida { get; set; }
        public KeyCode izq { get; set; }
        public KeyCode der { get; set; }
        public KeyCode atac { get; set; }

        public KeyCode atacf { get; set; }
        public KeyCode def { get; set; }
        public bool dibujando { get; set; }
        public bool actualizando { get; set; }

        //update
        public bool estadocambio { get; set; }

        public bool terminarjuego { get; set; }
        public AutoResetEvent accionesEvent { get; set; }
        public AutoResetEvent movimientoEvent { get; set; }
        public ManualResetEvent inputEvent { get; set; }

        public direcciones movdir { get; set; }
        public ConsoleColor colorescudo { get; set; }
        public ConsoleColor colorespada { get; set; }
        public ConsoleColor colorcuerpo { get; set; }
        public BarraVida barravida { get; set; }

        public ConsoleColor colordelfondo { get; set; }
        public Jugador otrojug { get; set; }

        //Efectos de sonido

        public List<SoundPlayer> sonido_choqueespadas { get; set; }

        public List<SoundPlayer> sonido_atacar { get; set; }

        public List<SoundPlayer> sonido_heridogritos { get; set; }

        public List<SoundPlayer> sonido_muertegritos { get; set; }

        public List<SoundPlayer> sonido_choqueescudo { get; set; }

        public List<SoundPlayer> sonido_escudo { get; set; }

        public SoundPlayer sonido_atacarfuerte { get; set; }

        //public List<SoundPlayer> desenvainar { get; set; }
        public Puntaje puntaje { get; set; }

        public Jugador(direcciones direccion, int paso, int vida, int x, int y, KeyCode izq, KeyCode der,
            KeyCode atac, KeyCode atacf, KeyCode def, ConsoleColor colorescudo, ConsoleColor colorespada, ConsoleColor colorcuerpo, int vidaposx, int vidaposy)
        {
            this.centro = new Punto(x, y);
            this.centroanterior = new Punto(x, y);

            //para knockback ocasionado por otro jugador
            this.centro2 = new Punto(x, y);
            this.centroanterior2 = new Punto(x, y);
            this.centrocambio = false;

            this.estado = estados.reposo;
            this.estadoanterior = estados.inicio;

            this.direccion = direccion;

            this.paso = paso;
            this.vida = vida;
            this.pasoanterior = 1;

            this.izq = izq;
            this.der = der;
            this.atac = atac;
            this.atacf = atacf;
            this.def = def;

            this.colorescudo = colorescudo;
            this.colorespada = colorespada;
            this.colorcuerpo = colorcuerpo;

            this.reposo = new Reposo(colorescudo, colorespada, colorcuerpo);
            this.movimiento = new Movimiento(colorescudo, colorespada, colorcuerpo);
            this.ataque = new Ataque(colorescudo, colorespada, colorcuerpo);
            this.defensa = new Defensa(colorescudo, colorespada, colorcuerpo);
            this.muerte = new Muerte(colorescudo, colorespada, colorcuerpo);
            this.herido = new Herido(colorescudo, colorespada, colorcuerpo);
            this.ataquefuerte = new AtaqueFuerte(colorescudo, colorespada, colorcuerpo);

            /*this.dibujando = false;
            this.actualizando = false;*/

            this.terminarjuego = false;
            this.estadocambio = false;

            this.accionesEvent = new AutoResetEvent(false);
            this.movimientoEvent = new AutoResetEvent(false);

            this.inputEvent = new ManualResetEvent(false);


            this.barravida = new BarraVida(vidaposx, vidaposy, colorcuerpo);

            //SONIDOS INSTANCIADOS:

            this.sonido_atacar = new List<SoundPlayer>
            {
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\atacar1.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\atacar2.wav")
            };

            this.sonido_atacarfuerte = new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\atacarfuerte1.wav");

            this.sonido_choqueespadas = new List<SoundPlayer>
            {
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\choqueespadas1.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\choqueespadas2.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\choqueespadas3.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\choqueespadas4.wav")
            };

            this.sonido_choqueescudo = new List<SoundPlayer>
            {
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\espadaescudo1.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\espadaescudo2.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\espadaescudo3.wav"),
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\espadaescudo4.wav")
            };

            this.sonido_escudo = new List<SoundPlayer>
            {
                new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\escudo1.wav")
            };


        /*this.desenvainar = new List<SoundPlayer>
        {
            new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\desenvainar1.wav"),
            new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\desenvainar2.wav"),
            new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\desenvainar3.wav"),
            new SoundPlayer(Environment.CurrentDirectory + @"\Sonidos\desenvainar4.wav")
        };*/

    }
        public void Dibujar(estados _estadoanterior, estados _estadoactual)
        {
            Punto _centroactual = new Punto();
            Punto _centroanterior = new Punto();

            _centroactual.x = this.centro.x;
            _centroactual.y = this.centro.y;
            _centroanterior.x = this.centroanterior.x;
            _centroanterior.y = this.centroanterior.y;

            if (_estadoanterior != estados.inicio)
            {

                switch (_estadoanterior)
                {
                    case estados.reposo:
                        reposo.BorrarDibujo(_centroanterior, this.pasoanterior, this.direccion, this.colordelfondo);
                        break;
                    case estados.movimiento:
                        movimiento.BorrarDibujo(_centroanterior, this.pasoanterior, this.direccion, this.colordelfondo);
                        break;
                    case estados.ataque:
                        ataque.BorrarDibujo(_centroanterior, this.pasoanterior, this.direccion, this.colordelfondo);
                        break;
                    case estados.defensa:
                        defensa.BorrarDibujo(_centroanterior, this.pasoanterior, this.direccion, this.colordelfondo);
                        break;
                    case estados.muerte:
                        muerte.BorrarDibujo(_centroanterior, this.pasoanterior, this.direccion, this.colordelfondo);
                        break;
                    case estados.herido:
                        herido.BorrarDibujo(_centroanterior, this.pasoanterior, this.direccion, this.colordelfondo);
                        break;
                    case estados.ataquefuerte:
                        ataquefuerte.BorrarDibujo(_centroanterior, this.pasoanterior, this.direccion, this.colordelfondo);
                        break;
                }
            }
            switch (_estadoactual)
            {
                case estados.reposo:
                    reposo.Dibujar(_centroactual, this.paso, this.direccion);
                    break;
                case estados.movimiento:
                    movimiento.Dibujar(_centroactual, this.paso, this.direccion);
                    break;
                case estados.ataque:
                    ataque.Dibujar(_centroactual, this.paso, this.direccion);
                    break;
                case estados.defensa:
                    defensa.Dibujar(_centroactual, this.paso, this.direccion);
                    break;
                case estados.muerte:
                    muerte.Dibujar(_centroactual, this.paso, this.direccion);
                    break;
                case estados.herido:
                    herido.Dibujar(_centroactual, this.paso, this.direccion);
                    break;
                case estados.ataquefuerte:
                    ataquefuerte.Dibujar(_centroactual, this.paso, this.direccion);
                    break;
            }

            _centroactual = null;
            _centroanterior = null;
        }

        public void Actualizar()
        {
            bool adelante = false;

             Random rnd = new Random();
             int r = 0;

             //desenvainar la espada. Se podria agregar animación.
            /* r = rnd.Next(this.desenvainar.Count);
             this.desenvainar[r].Play();

             this.desenvainar = null;
             rnd = null;*/

            while (this.terminarjuego == false)
            {
                this.centroanterior.x = this.centro.x;

                if (this.centrocambio == true)
                {
                    this.centro.x = this.centro2.x;
                    this.centrocambio = false;
                }

                if (this.estadocambio == true)
                {
                    //this.estadoanterior = this.estado;
                    this.estado = this.estadonuevo;
                    this.estadocambio = false;
                    this.paso = 1;
                }

                if (this.estado == estados.reposo)
                {
                    this.Colision();

                    this.Dibujar(this.estadoanterior, this.estado);

                    this.pasoanterior = this.paso;
                    this.estadoanterior = estados.reposo;

                    this.accionesEvent.WaitOne(300);

                    if (this.paso == 3)
                    {
                        adelante = false;
                    }
                    else if (this.paso == 1)
                    {
                        adelante = true;
                    }

                    if (adelante == true)
                    {
                        this.paso++;
                    }
                    else
                    {
                        this.paso--;
                    }
                    
                }
                else if (this.estado == estados.ataque)
                {
                    //sonido de ataque
                    if (this.paso == 2)
                    {
                        r = rnd.Next(this.sonido_atacar.Count);
                        this.sonido_atacar[r].Play();
                    }

                    this.Colision();

                    this.Dibujar(this.estadoanterior, this.estado);

                    this.accionesEvent.WaitOne(170);

                    this.pasoanterior = this.paso;
                    this.estadoanterior = estados.ataque;

                    if (this.paso == 3)
                    {
                        this.paso = 1;
                        this.estadonuevo = estados.reposo;
                        this.estadocambio = true;

                        this.inputEvent.Set();
                    }
                    else
                        this.paso++;
                }
                else if (this.estado == estados.ataquefuerte)
                {
                    //sonido de ataque fuerte
                    if (this.paso == 2)
                    {
                        this.sonido_atacarfuerte.Play();
                    }

                    this.Colision();

                    this.Dibujar(this.estadoanterior, this.estado);

                    //El ataque fuerte se demora mas tiempo pero no se puede defender del mismo.
                    if (this.paso == 1)
                        this.accionesEvent.WaitOne(600);
                    else
                        this.accionesEvent.WaitOne(200);

                    this.pasoanterior = this.paso;
                    this.estadoanterior = estados.ataquefuerte;

                    if (this.paso == 3)
                    {
                        this.paso = 1;
                        this.estadonuevo = estados.reposo;
                        this.estadocambio = true;

                        this.inputEvent.Set();
                    }
                    else
                        this.paso++;

                }
                else if (this.estado == estados.defensa)
                {
                    //sonido de defensa
                    if (this.paso == 2)
                    {
                        r = rnd.Next(this.sonido_escudo.Count);
                        this.sonido_escudo[r].Play();
                    }

                    this.Colision();

                    this.Dibujar(this.estadoanterior, this.estado);

                    this.accionesEvent.WaitOne(150);

                    this.pasoanterior = this.paso;
                    this.estadoanterior = estados.defensa;

                    if (this.paso < 3)
                    {
                        this.paso++;
                    }
                }
                else if (this.estado == estados.movimiento)
                {
                    if (this.movdir == direcciones.derecha)
                    {
                        this.centro.x++;
                    }
                    else
                    {
                        this.centro.x--;
                    }

                    this.Colision();

                    this.Dibujar(this.estadoanterior, this.estado);

                    this.movimientoEvent.WaitOne(80);

                    this.pasoanterior = this.paso;
                    this.estadoanterior = estados.movimiento;

                    if (this.paso == 3)
                    {
                        this.paso = 1;
                    }
                    else
                        paso++;

                }
                else if (this.estado == estados.herido)
                {
                    //Sonido de herido
                    if (this.paso == 1)
                    {
                        r = rnd.Next(this.sonido_heridogritos.Count);
                        this.sonido_heridogritos[r].Play();
                    }

                    this.Colision();

                    this.Dibujar(this.estadoanterior, this.estado);

                    //this.accionesEvent.Reset();
                    this.accionesEvent.WaitOne(150);

                    this.pasoanterior = this.paso;
                    this.estadoanterior = estados.herido;

                    if (this.paso == 2)
                    {
                        this.paso = 1;
                        this.estadonuevo = estados.reposo;
                        this.estadocambio = true;
                        this.inputEvent.Set();
                    }
                    else
                        this.paso++;
                }
                else if (this.estado == estados.muerte)
                {
                    //Sonido de muerte
                    if (this.paso == 1)
                    {
                        r = rnd.Next(this.sonido_muertegritos.Count);
                        this.sonido_muertegritos[r].Play();
                    }

                    this.Colision();

                    this.Dibujar(this.estadoanterior, this.estado);

                    this.accionesEvent.WaitOne(400);

                    this.pasoanterior = this.paso;
                    this.estadoanterior = estados.muerte;

                    if (this.paso == 3)
                    {
                        this.terminarjuego = true;
                        this.otrojug.terminarjuego = true;

                        this.inputEvent.Set();
                        otrojug.inputEvent.Set();
                    }
                    else
                        this.paso++;

                }
                //this.estadoanterior = this.estado;
                //this.estado = estados.muerte;
                if (this.estadoanterior == estados.inicio)
                {
                    this.estadoanterior = estados.reposo;
                }

            }

            rnd = null;
        }
        

        public void LeerInput()
        {

            while (this.terminarjuego == false)
            {
                this.inputEvent.WaitOne();

                if (OtrosMetodos.TeclaPresionada(this.atac))
                {
                    this.inputEvent.Reset();

                    if (this.estado == estados.reposo)
                        this.accionesEvent.Set();
                    else if (this.estado == estados.movimiento)
                        this.movimientoEvent.Set();

                    this.estadonuevo = estados.ataque;
                    this.estadocambio = true;
                }
                else if (OtrosMetodos.TeclaPresionada(this.atacf))
                {
                    this.inputEvent.Reset();

                    if (this.estado == estados.reposo)
                        this.accionesEvent.Set();
                    else if (this.estado == estados.movimiento)
                        this.movimientoEvent.Set();

                    this.estadonuevo = estados.ataquefuerte;
                    this.estadocambio = true;
                }
                else if (OtrosMetodos.TeclaPresionada(this.def))
                {
                    //this.inputEvent.Reset();

                    if (this.estado == estados.reposo)
                        this.accionesEvent.Set();
                    else if (this.estado == estados.movimiento)
                        this.movimientoEvent.Set();

                    if (this.estado != estados.defensa)
                    {
                        this.estadonuevo = estados.defensa;
                        this.estadocambio = true;
                    }

                }
                else if (OtrosMetodos.TeclaPresionada(this.der))
                {
                    this.movdir = direcciones.derecha;

                    if (this.estado == estados.reposo)
                        this.accionesEvent.Set();
                    
                    if(this.estado != estados.movimiento || (this.estado ==estados.movimiento && this.movdir == direcciones.izquierda))
                    {
                        this.estadonuevo = estados.movimiento;
                        this.estadocambio = true;
                    }
                }
                else if (OtrosMetodos.TeclaPresionada(this.izq))
                {
                    this.movdir = direcciones.izquierda;

                    if (this.estado == estados.reposo)
                        this.accionesEvent.Set();

                    if (this.estado != estados.movimiento || (this.estado == estados.movimiento && this.movdir == direcciones.derecha))
                    {
                        this.estadonuevo = estados.movimiento;
                        this.estadocambio = true;
                    }
                }
                else if (OtrosMetodos.TeclaPresionada(this.izq) == false && OtrosMetodos.TeclaPresionada(this.der) == false && this.estado == estados.movimiento)
                {
                    this.movimientoEvent.Set();

                    this.estadonuevo = estados.reposo;
                    this.estadocambio = true;
                }
                else if (OtrosMetodos.TeclaPresionada(this.def) == false && this.estado == estados.defensa)
                {
                    this.accionesEvent.Set();

                    this.estadonuevo = estados.reposo;
                    this.estadocambio = true;
                }

                Thread.Sleep(30);
            }
        }

        private void Colision()
        {
            Animacion anithisjug = null;
            Animacion aniotrojug = null;

            Random rnd = new Random();
            int r = 0;

            bool salir = false;

            estados _estadoanterior = this.estadoanterior;
            estados _estadoactual = this.estado;

            //Guardo paso del otro jugador

            int _pasoOtrojug = otrojug.paso;
            estados _estadoOtrojug = otrojug.estado;

            switch (_estadoactual)
            {
                case estados.reposo:
                    anithisjug = this.reposo;
                    break;
                case estados.ataque:
                    anithisjug = this.ataque;
                    break;
                case estados.defensa:
                    anithisjug = this.defensa;
                    break;
                case estados.movimiento:
                    anithisjug = this.movimiento;
                    break;
                case estados.herido:
                    anithisjug = this.herido;
                    break;
                case estados.muerte:
                    anithisjug = this.muerte;
                    break;
                case estados.ataquefuerte:
                    anithisjug = this.ataquefuerte;
                    break;
            }

            switch (_estadoOtrojug)
            {
                case estados.reposo:
                    aniotrojug = otrojug.reposo;
                    break;
                case estados.ataque:
                    aniotrojug = otrojug.ataque;
                    break;
                case estados.defensa:
                    aniotrojug = otrojug.defensa;
                    break;
                case estados.movimiento:
                    aniotrojug = otrojug.movimiento;
                    break;
                case estados.herido:
                    aniotrojug = otrojug.herido;
                    break;
                case estados.muerte:
                    aniotrojug = otrojug.muerte;
                    break;
                case estados.ataquefuerte:
                    aniotrojug = otrojug.ataquefuerte;
                    break;
            }

            foreach (Punto p in anithisjug.hitboxes[this.paso - 1].refhitboxes)
            {
                //Evaluar colision con ambiente
                if ((p.x * (int)this.direccion + this.centro.x) <= 11)
                {

                    this.centro.x = this.centro.x + 1;
                    this.Colision();

                    //Evaluar de sacar this collision y que sume por cada punto igualado
                }
                if ((p.x * (int)this.direccion + this.centro.x) >= 108)
                {
                    this.centro.x = this.centro.x - 1;
                    this.Colision();

                    //Evaluar de sacar this collision y que sume por cada punto igualado
                }

                if(this.estado != estados.muerte)
                {
                    //Evaluar Colision con jugador
                    foreach (Punto q in aniotrojug.hitboxes[_pasoOtrojug - 1].refhitboxes)
                    {
                        if ((p.x * (int)this.direccion + this.centro.x) == (q.x * (int)otrojug.direccion + otrojug.centro.x) && otrojug.estado != estados.muerte) //Hubo colision?
                        {
                            if (_estadoactual == estados.ataque && this.paso == 3) //Estoy atacando o es otro tipo de colision?
                            {
                                if (_estadoOtrojug == estados.defensa && _pasoOtrojug == 3) //Mi ataque fue repelido?
                                {
                                    //El otro jugador detectará la colision, no tengo que quitarle vida.
                                }
                                else if (_estadoOtrojug == estados.ataque && (_pasoOtrojug == 2 || _pasoOtrojug == 3)) //Nos atacamos al mismo tiempo?
                                {
                                    //Knockback
                                    this.centroanterior2.x = this.centro.x;
                                    this.centro2.x = this.centro.x - 3 * (int)this.direccion;
                                    this.centrocambio = true;

                                    otrojug.centroanterior2.x = otrojug.centro.x;
                                    otrojug.centro2.x = otrojug.centro.x - 3 * (int)otrojug.direccion;
                                    otrojug.centrocambio = true;

                                    r = rnd.Next(this.sonido_choqueespadas.Count);
                                    this.sonido_choqueespadas[r].Play();

                                }
                                else //Mi ataque logró acertar
                                {
                                    herir(10, otrojug, 10);
                                }

                                //doble break
                                salir = true;
                                break;

                            }
                            else if (_estadoactual == estados.defensa && this.paso == 3 && otrojug.estado == estados.ataque && otrojug.paso == 3) //Me defendi con mi escudo
                            {
                                r = rnd.Next(this.sonido_choqueescudo.Count);
                                this.sonido_choqueescudo[r].Play();

                                herir(5, otrojug, 20);

                                //doble break
                                salir = true;
                                break;
                            }
                            else if (_estadoactual == estados.ataquefuerte && this.paso == 3) //Estoy atacando o es otro tipo de colision?
                            {
                                herir(30, otrojug, 20);

                                //doble break
                                salir = true;
                                break;
                            }
                            else if (otrojug.estado != estados.ataque) //Es otro tipo de colision, no hubo ataque
                            {
                                otrojug.centroanterior2.x = otrojug.centro.x;
                                otrojug.centro2.x = otrojug.centro.x - 5 * (int)otrojug.direccion;
                                otrojug.centrocambio = true;
                                otrojug.accionesEvent.Set();

                                //doble break
                                salir = true;
                                break;
                            }

                        }

                    }
                    if (salir == true)
                        break;
                }

            }
             
            rnd = null;

        }

        private void SuspenderInput()
        {
            this.accionesEvent.Set();
            //this.movimientoEvent.Set();
            this.inputEvent.Reset();
        }

        private void herir(int vida, Jugador otrojug,int knockback)
        {
            //quito vida
            otrojug.barravida.Actualizar(vida);

            //Knockback
           // otrojug.centroanterior2.x = otrojug.centro.x;
            otrojug.centro2.x = otrojug.centro.x - knockback * (int)otrojug.direccion;
            otrojug.centrocambio = true;

            //Le suspendo el input para cambiar el estado. Ademas, suspender cualquier otra cosa que este haciendo. Animacion herido o muerte tiene prioridad.
            otrojug.SuspenderInput();

            //Herido o muerte?
            if (otrojug.barravida.vida <= 0 && otrojug.estado != estados.muerte)
            {
                //Victoria, score
                this.puntaje.numero++;

                otrojug.estadonuevo = estados.muerte;

                //Victoria, no necesito hacer algo mas
                this.SuspenderInput();
            }
            else
            { 
                otrojug.estadonuevo = estados.herido;
            }

            //cambio de estado
            otrojug.estadocambio = true;
        }
    }

}          
