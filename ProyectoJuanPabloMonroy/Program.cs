using System;
using System.IO;

namespace ProyectoJuanPabloMonroy
{
    class Program
    {
        static int maxVotos;
        static int cantVotantes = 0;
        static Partido[] partidos = new Partido[4];
        static Voto[] Votos = new Voto[5000];
        static string[,] congreso = new string[8, 20];
        static string[,] graficaBarras = new string[20, 4];
        static string usuario;
        static bool configuracion = false;

        static void VaciarCongreso()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    congreso[i, j] = "|   |";
                }
            }
        }

        static void VaciarGrafica()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    graficaBarras[i, j] = "|   |";
                }
            }
        }

        static void ImportarVotos()
        {
            bool continuar = true;
            string presidente;
            string alcalde;
            string diputadosNac;
            string diputadosDist;
            string ruta;
            Console.Write("Ingrese la ruta donde se encuentra el archivo: ");
            ruta = Console.ReadLine();
            StreamReader str = new StreamReader(ruta);

            try
            {
                string linea = "";
                while ((linea = str.ReadLine()) != null && continuar == true)
                {
                    if (cantVotantes < maxVotos)
                    {
                        Voto voto = new Voto();
                        presidente = linea.Split(',')[0];
                        alcalde = linea.Split(',')[1];
                        diputadosNac = linea.Split(',')[2];
                        diputadosDist = linea.Split(',')[3];

                        switch (presidente)
                        {
                            case "A":
                                presidente = "azul";
                                break;
                            case "B":
                                presidente = "verde";
                                break;
                            case "C":
                                presidente = "rojo";
                                break;
                            case "D":
                                presidente = "naranja";
                                break;
                        }

                        switch (alcalde)
                        {
                            case "A":
                                alcalde = "azul";
                                break;
                            case "B":
                                alcalde = "verde";
                                break;
                            case "C":
                                alcalde = "rojo";
                                break;
                            case "D":
                                alcalde = "naranja";
                                break;
                        }

                        switch (diputadosNac)
                        {
                            case "A":
                                diputadosNac = "azul";
                                break;
                            case "B":
                                diputadosNac = "verde";
                                break;
                            case "C":
                                diputadosNac = "rojo";
                                break;
                            case "D":
                                diputadosNac = "naranja";
                                break;
                        }

                        switch (diputadosDist)
                        {
                            case "A":
                                diputadosDist = "azul";
                                break;
                            case "B":
                                diputadosDist = "verde";
                                break;
                            case "C":
                                diputadosDist = "rojo";
                                break;
                            case "D":
                                diputadosDist = "naranja";
                                break;
                        }

                        SumarVotosPresidente(presidente);
                        SumarVotosAlcalde(alcalde);
                        SumarVotosDiputadoNac(diputadosNac);
                        SumarVotosDiputadoDist(diputadosDist);

                        voto.Presidente = presidente;
                        voto.Alcalde = alcalde;
                        voto.DiputadoNac = diputadosNac;
                        voto.DiputadoDist = diputadosDist;
                        Votos[cantVotantes] = voto;
                        cantVotantes++;
                    }
                    else
                    {
                        continuar = false;
                    }
                }
                if (continuar == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("VOTOS INGRESADOS CORRECTAMENTE");
                    Console.WriteLine("------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("YA NO SE PERMITEN MAS VOTANTES");
                    Console.WriteLine("------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                }

            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-------------------------------");
                Console.WriteLine("NO SE PUDIERON CARGAR LOS VOTOS");
                Console.WriteLine("-------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
            }
        }

        static void ExportarVotos()
        {
            string ruta;
            string presidente;
            string alcalde;
            string diputadosNac;
            string diputadosDist;
            Console.Write("Ingrese la ruta donde desea guardar el archivo: ");
            ruta = Console.ReadLine();
            try
            {
                FileStream stream = new FileStream(ruta + @"\votaciones.csv", FileMode.CreateNew);
                StreamWriter sw = new StreamWriter(stream);

                for (int i = 0; i < cantVotantes; i++)
                {
                    presidente = Votos[i].Presidente;
                    alcalde = Votos[i].Alcalde;
                    diputadosNac = Votos[i].DiputadoNac;
                    diputadosDist = Votos[i].DiputadoDist;

                    switch (presidente)
                    {
                        case "azul":
                            presidente = "A";
                            break;
                        case "verde":
                            presidente = "B";
                            break;
                        case "rojo":
                            presidente = "C";
                            break;
                        case "naranja":
                            presidente = "D";
                            break;
                    }

                    switch (alcalde)
                    {
                        case "azul":
                            alcalde = "A";
                            break;
                        case "verde":
                            alcalde = "B";
                            break;
                        case "rojo":
                            alcalde = "C";
                            break;
                        case "naranja":
                            alcalde = "D";
                            break;
                    }

                    switch (diputadosNac)
                    {
                        case "azul":
                            diputadosNac = "A";
                            break;
                        case "verde":
                            diputadosNac = "B";
                            break;
                        case "rojo":
                            diputadosNac = "C";
                            break;
                        case "naranja":
                            diputadosNac = "D";
                            break;
                    }

                    switch (diputadosDist)
                    {
                        case "azul":
                            diputadosDist = "A";
                            break;
                        case "verde":
                            diputadosDist = "B";
                            break;
                        case "rojo":
                            diputadosDist = "C";
                            break;
                        case "naranja":
                            diputadosDist = "D";
                            break;
                    }
                    sw.WriteLine(presidente + "," + alcalde + "," + diputadosNac + "," + diputadosDist);
                }

                sw.Close();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------------------------");
                Console.WriteLine("VOTOS EXPORTADOS CORRECTAMENTE");
                Console.WriteLine("------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                System.Threading.Thread.Sleep(1500);
                Console.Clear();

            }
            catch (Exception exp)
            {
                Console.WriteLine("NO SE PUDIERON EXPORTAR LOS VOTOS");
            }
        }

        static void CantidadPartidos()
        {
            string colorPartido;
            Console.WriteLine("--------------------------------");
            Console.WriteLine("   CONFIGURACION DE ELECCIONES  ");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("");

            Partido PartidoAzul = new Partido();
            colorPartido = "azul";
            PartidoAzul.ColorPartido = colorPartido;
            partidos[0] = PartidoAzul;

            Partido PartidoVerde = new Partido();
            colorPartido = "verde";
            PartidoVerde.ColorPartido = colorPartido;
            partidos[1] = PartidoVerde;

            Partido PartidoRojo = new Partido();
            colorPartido = "rojo";
            PartidoRojo.ColorPartido = colorPartido;
            partidos[2] = PartidoRojo;

            Partido PartidoNaranja = new Partido();
            colorPartido = "naranja";
            PartidoNaranja.ColorPartido = colorPartido;
            partidos[3] = PartidoNaranja;

            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("PARTIDOS PARTICIPANTES");
            Console.WriteLine("----------------------");
            Console.WriteLine("");


            for (int j = 0; j < 4; j++)
            {
                Console.Write("Partido ");
                switch (partidos[j].ColorPartido.ToString())
                {
                    case "azul":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "rojo":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "verde":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "naranja":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                }
                Console.WriteLine(partidos[j].ColorPartido.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PRESIONE UNA TECLA PARA CONTINUAR");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        static void Login()
        {
            usuario = "";
            string password = "";
            Console.WriteLine("");
            Console.WriteLine("        LOGIN        ");
            Console.WriteLine("");
            Console.Write("Usuario: ");
            usuario = Console.ReadLine();
            Console.Write("Contraseña: ");
            password = Console.ReadLine();
            Console.Clear();

            if (usuario == "admin" && password == "123")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------------------");
                Console.WriteLine("ADMIN LOGUEADO CON EXITO");
                Console.WriteLine("------------------------");
                System.Threading.Thread.Sleep(1500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                if (configuracion == false)
                {
                    CantidadPartidos();
                    VaciarCongreso();
                    VaciarGrafica();
                    maxVotos = 5000;
                    Console.Clear();
                    configuracion = true;
                }
                MenuAdmin();
            }
            else if (usuario == "votante" && password == "123" && configuracion == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--------------------------");
                Console.WriteLine("VOTANTE LOGUEADO CON EXITO");
                Console.WriteLine("--------------------------");
                System.Threading.Thread.Sleep(1500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                MenuVotante();
            }else if (usuario == "JRV" && password == "123" && configuracion == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------");
                Console.WriteLine("JRV LOGUEADO CON EXITO");
                Console.WriteLine("----------------------");
                System.Threading.Thread.Sleep(1500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                MenuJRV();
            }
            else if (usuario == "JRV" && password == "123" && configuracion == false)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("EL ADMINISTRADOR AUN NO HA CONFIGURADO LAS ELECCIONES");
                Console.WriteLine("-----------------------------------------------------");
                System.Threading.Thread.Sleep(2000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Login();
            }
            else if (usuario == "votante" && password == "123" && configuracion == false)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("EL ADMINISTRADOR AUN NO HA CONFIGURADO LAS ELECCIONES");
                Console.WriteLine("-----------------------------------------------------");
                System.Threading.Thread.Sleep(2000);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Login();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------------------------------");
                Console.WriteLine("USUARIO / PASSWORD INCORRECTOS");
                Console.WriteLine("------------------------------");
                System.Threading.Thread.Sleep(1500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Login();
            }
        }

        static void MenuJRV()
        {
            int opcion;
            Console.WriteLine("");
            Console.WriteLine("ELECCIONES GENERALES 2019");
            Console.WriteLine("");
            Console.WriteLine("1.Obtener Ganador Parcial");
            Console.WriteLine("2.Grafica del Congreso");
            Console.WriteLine("3.Reporte con graficos");
            Console.WriteLine("4.Exportar Votos");
            Console.WriteLine("5.Cerrar Sesion");
            Console.WriteLine("");
            try
            {
                Console.Write("Ingrese una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            catch (Exception exception)
            {
                opcion = 10;
            }

            switch (opcion)
            {
                case 1:
                    if (cantVotantes > 0)
                    {
                        ObtenerGanadorParcial();
                        MenuAdmin();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("AUN NO SE HAN REGISTRADO VOTOS");
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuAdmin();
                    }
                    break;
                case 2:
                    if (cantVotantes > 0)
                    {
                        VaciarCongreso();
                        LlenarCongreso();
                        GraficarDistribucionCongreso();
                        MenuAdmin();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("AUN NO SE HAN REGISTRADO VOTOS");
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuAdmin();
                    }
                    break;
                case 3:
                    if (cantVotantes > 0)
                    {
                        MenuGraficaBarras();
                        MenuAdmin();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("AUN NO SE HAN REGISTRADO VOTOS");
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuAdmin();
                    }
                    break;
                case 4:
                    if (cantVotantes > 0)
                    {
                        ExportarVotos();
                        MenuAdmin();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("AUN NO SE HAN REGISTRADO VOTOS");
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuAdmin();
                    }
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("------------------");
                    Console.WriteLine("CERRANDO SESION...");
                    Console.WriteLine("------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    Login();
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Opcion Incorrecta");
                    Console.WriteLine("-----------------");
                    System.Threading.Thread.Sleep(1500);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    MenuAdmin();
                    break;
            }
        }

        static void MenuAdmin()
        {
            int opcion;
            Console.WriteLine("");
            Console.WriteLine("ELECCIONES GENERALES 2019");
            Console.WriteLine("");
            Console.WriteLine("1.Ingresar Cantidad Votos");
            Console.WriteLine("2.Nuevas Votaciones");
            Console.WriteLine("3.Importar Votos");
            Console.WriteLine("4.Obtener Ganador Parcial");
            Console.WriteLine("5.Grafica del Congreso");
            Console.WriteLine("6.Anular Elecciones");
            Console.WriteLine("7.Reporte con graficos");
            Console.WriteLine("8.Exportar Votos");
            Console.WriteLine("9.Cerrar Sesion");
            Console.WriteLine("");
            try
            {
                Console.Write("Ingrese una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            catch (Exception exception)
            {
                opcion = 10;
            }

            switch (opcion)
            {
                case 1:
                    IngresarCantidadVotos();
                    MenuAdmin();
                    break;
                case 2:
                    Votaciones();
                    MenuAdmin();
                    break;
                case 3:
                    ImportarVotos();
                    MenuAdmin();
                    break;
                case 4:
                    if (cantVotantes > 0)
                    {
                        ObtenerGanadorParcial();
                        MenuAdmin();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("AUN NO SE HAN REGISTRADO VOTOS");
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuAdmin();
                    }
                    break;
                case 5:
                    if (cantVotantes > 0)
                    {
                        VaciarCongreso();
                        LlenarCongreso();
                        GraficarDistribucionCongreso();
                        MenuAdmin();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("AUN NO SE HAN REGISTRADO VOTOS");
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuAdmin();
                    }
                    break;
                case 6:
                    if (cantVotantes > 0)
                    {
                        AnularElecciones();
                        MenuAdmin();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("AUN NO SE HAN REGISTRADO VOTOS");
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuAdmin();
                    }
                    break;
                case 7:
                    if (cantVotantes > 0)
                    {
                        MenuGraficaBarras();
                        MenuAdmin();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("AUN NO SE HAN REGISTRADO VOTOS");
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuAdmin();
                    }
                    break;
                case 8:
                    if (cantVotantes > 0)
                    {
                        ExportarVotos();
                        MenuAdmin();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("AUN NO SE HAN REGISTRADO VOTOS");
                        Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        MenuAdmin();
                    }
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("------------------");
                    Console.WriteLine("CERRANDO SESION...");
                    Console.WriteLine("------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    Login();
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Opcion Incorrecta");
                    Console.WriteLine("-----------------");
                    System.Threading.Thread.Sleep(1500);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    MenuAdmin();
                    break;
            }
        }

        static void MenuVotante()
        {
            int opcion;
            Console.WriteLine("");
            Console.WriteLine("ELECCIONES GENERALES 2019");
            Console.WriteLine("");
            Console.WriteLine("1.Ingresar Voto");
            Console.WriteLine("2.Cerrar Sesion");
            Console.WriteLine("");
            Console.Write("Ingrese una opcion: ");
            opcion = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (opcion)
            {
                case 1:
                    Votaciones();
                    MenuVotante();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("------------------");
                    Console.WriteLine("CERRANDO SESION...");
                    Console.WriteLine("------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    Login();
                    break;
                default:
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Opcion Incorrecta");
                    Console.WriteLine("-----------------");
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    MenuVotante();
                    break;
            }
        }

        static void IngresarCantidadVotos()
        {
            try
            {
                do
                {
                    Console.Write("Ingrese la cantidad maxima de votos: ");
                    maxVotos = int.Parse(Console.ReadLine());
                    if (maxVotos <= 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Cantidad Incorrecta");
                        Console.WriteLine("-------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                    }
                    Console.Clear();
                } while (maxVotos <= 0);
                Array.Resize<Voto>(ref Votos, maxVotos);
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-------------------");
                Console.WriteLine("Cantidad Incorrecta");
                Console.WriteLine("-------------------");
                Console.ForegroundColor = ConsoleColor.White;
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                IngresarCantidadVotos();
            }
        }

        static void ImprimirPartidos()
        {
            int op = 1;
            for (int i = 0; i < partidos.Length; i++)
            {
                switch (partidos[i].ColorPartido)
                {
                    case "azul":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(op + ". " + partidos[i].ColorPartido);
                        break;
                    case "verde":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(op + ". " + partidos[i].ColorPartido);
                        break;
                    case "rojo":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(op + ". " + partidos[i].ColorPartido);
                        break;
                    case "naranja":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(op + ". " + partidos[i].ColorPartido);
                        break;
                }
                op++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Votaciones()
        {
            if (cantVotantes < maxVotos)
            {
                string presidente;
                string alcade;
                string diputadosNac;
                string diputadosDist;

                Console.WriteLine("-------------------------------");
                Console.WriteLine("           VOTACIONES          ");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("");
                do
                {
                    Console.WriteLine("Presidente / Vicepresidente");
                    ImprimirPartidos();
                    Console.Write("Ingrese el nombre del Partido: ");
                    presidente = Console.ReadLine().ToLower().Trim();
                    Console.Clear();
                } while (presidente == "");
                do
                {
                    Console.WriteLine("Alcalde Municipal");
                    ImprimirPartidos();
                    Console.Write("Ingrese el nombre del Partido: ");
                    alcade = Console.ReadLine().ToLower().Trim();
                    Console.Clear();
                } while (alcade == "");
                do
                {
                    Console.WriteLine("Diputados Listado Nacional");
                    ImprimirPartidos();
                    Console.Write("Ingrese el nombre del Partido: ");
                    diputadosNac = Console.ReadLine().ToLower();
                    Console.Clear();
                } while (diputadosNac == "");
                do
                {
                    Console.WriteLine("Diputados Listado Distrital");
                    ImprimirPartidos();
                    Console.Write("Ingrese el nombre del Partido: ");
                    diputadosDist = Console.ReadLine().ToLower();
                    Console.Clear();
                } while (diputadosDist == "");

                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("PRESIONE UNA TECLA PARA CONTINUAR");
                Console.WriteLine("");
                Console.ReadKey();
                SumarVotosPresidente(presidente);
                SumarVotosAlcalde(alcade);
                SumarVotosDiputadoNac(diputadosNac);
                SumarVotosDiputadoDist(diputadosDist);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--------------------------");
                Console.WriteLine("VOTO EMITIDO CORRECTAMENTE");
                Console.WriteLine("--------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                cantVotantes++;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------------------------------");
                Console.WriteLine("YA NO SE PERMITEN MAS VOTANTES");
                Console.WriteLine("------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                if (usuario == "admin")
                {
                    MenuAdmin();
                }
                else if (usuario == "votante")
                {
                    MenuVotante();
                }
            }
        }

        static void ObtenerGanadorParcial()
        {
            Partido auxiliar = new Partido();
            int opcion;
            Console.WriteLine("---------------------------------");
            Console.WriteLine("         GANADOR PARCIAL         ");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("");
            Console.WriteLine("1.Presidente/VicePresidente");
            Console.WriteLine("2.Alcalde");
            Console.WriteLine("3.Diputados en listado nacional");
            Console.WriteLine("4.Diputados en listado distrital.");
            Console.WriteLine("5.Regresar");
            Console.WriteLine("");
            try
            {
                Console.Write("Ingrese una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            catch (Exception exception)
            {
                opcion = 7;
            }

            switch (opcion)
            {
                case 1:
                    int votosPresidente = 0;
                    for (int i = 0; i < partidos.Length; i++)
                    {
                        if (partidos[i].VotosPresidente > votosPresidente)
                        {
                            votosPresidente = partidos[i].VotosPresidente;
                            auxiliar = partidos[i];
                        }
                    }
                    Console.WriteLine("-------------------------------------");
                    Console.Write("PRESIDENTE GANADOR PARCIAL: ");
                    switch (auxiliar.ColorPartido)
                    {
                        case "azul":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case "rojo":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case "verde":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case "naranja":
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                    }
                    Console.WriteLine(auxiliar.ColorPartido);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("VOTOS: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(auxiliar.VotosPresidente);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("PRESIONE UNA TECLA PARA CONTINUAR");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                    ObtenerGanadorParcial();
                    break;
                case 2:
                    int votosAlcalde = 0;
                    for (int i = 0; i < partidos.Length; i++)
                    {
                        if (partidos[i].VotosAlcalde > votosAlcalde)
                        {
                            votosAlcalde = partidos[i].VotosAlcalde;
                            auxiliar = partidos[i];
                        }
                    }
                    Console.WriteLine("-------------------------------------");
                    Console.Write("ALCALDE GANADOR PARCIAL: ");
                    switch (auxiliar.ColorPartido)
                    {
                        case "azul":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case "rojo":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case "verde":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case "naranja":
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                    }
                    Console.WriteLine(auxiliar.ColorPartido);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("VOTOS: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(auxiliar.VotosAlcalde);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("PRESIONE UNA TECLA PARA CONTINUAR");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                    ObtenerGanadorParcial();
                    break;
                case 3:
                    int votosDipNac = 0;
                    for (int i = 0; i < partidos.Length; i++)
                    {
                        if (partidos[i].VotosDiputadoNac > votosDipNac)
                        {
                            votosDipNac = partidos[i].VotosDiputadoNac;
                            auxiliar = partidos[i];
                        }
                    }
                    Console.WriteLine("--------------------------------------------------------");
                    Console.Write("DIPUTADOS LISTADO NACIONAL GANADOR PARCIAL: ");
                    switch (auxiliar.ColorPartido)
                    {
                        case "azul":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case "rojo":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case "verde":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case "naranja":
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                    }
                    Console.WriteLine(auxiliar.ColorPartido);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("VOTOS: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(auxiliar.VotosDiputadoNac);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("PRESIONE UNA TECLA PARA CONTINUAR");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                    ObtenerGanadorParcial();
                    break;
                case 4:
                    int votosDipDist = 0;
                    for (int i = 0; i < partidos.Length; i++)
                    {
                        if (partidos[i].VotosDiputadoDistrital > votosDipDist)
                        {
                            votosDipDist = partidos[i].VotosDiputadoDistrital;
                            auxiliar = partidos[i];
                        }
                    }
                    Console.WriteLine("---------------------------------------------------------");
                    Console.Write("DIPUTADOS LISTADO DISTRITAL GANADOR PARCIAL: ");
                    switch (auxiliar.ColorPartido)
                    {
                        case "azul":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case "rojo":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case "verde":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case "naranja":
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                    }
                    Console.WriteLine(auxiliar.ColorPartido);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("VOTOS: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(auxiliar.VotosDiputadoDistrital);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("PRESIONE UNA TECLA PARA CONTINUAR");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                    ObtenerGanadorParcial();
                    break;
                case 5:
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Opcion Incorrecta");
                    Console.WriteLine("-----------------");
                    System.Threading.Thread.Sleep(1500);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    ObtenerGanadorParcial();
                    break;
            }

        }

        static void LlenarCongreso()
        {
            double porcentaje = 0;
            double cantCurules = 0;
            double votosObtenidos;

            //ASIGNACION DE CURULES DIPUTADOS LISTADO NACIONAL
            for (int i = 0; i < partidos.Length; i++)
            {
                votosObtenidos = partidos[i].VotosDiputadoNac;
                porcentaje = votosObtenidos / cantVotantes;
                cantCurules = Math.Round(porcentaje * 63, 0, MidpointRounding.ToEven);
                partidos[i].DiputadosTotales += cantCurules;
                partidos[i].CurulesNac = cantCurules;
                do
                {
                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 20; y++)
                        {
                            if (congreso[x, y] == "|   |" && partidos[i].CurulesNac > 0)
                            {
                                switch (partidos[i].ColorPartido)
                                {
                                    case "azul":
                                        congreso[x, y] = "|LNA|";
                                        break;
                                    case "verde":
                                        congreso[x, y] = "|LNV|";
                                        break;
                                    case "naranja":
                                        congreso[x, y] = "|LNN|";
                                        break;
                                    case "rojo":
                                        congreso[x, y] = "|LNR|";
                                        break;
                                }
                                partidos[i].CurulesNac--;
                            }
                        }
                    }
                } while (partidos[i].CurulesNac > 0);
            }

            //ASIGNACION DE CURULES DIPUTADOS LISTADO DISTRITAL
            for (int i = 0; i < partidos.Length; i++)
            {
                votosObtenidos = partidos[i].VotosDiputadoDistrital;
                porcentaje = votosObtenidos / cantVotantes;
                cantCurules = Math.Round(porcentaje * 47, 0, MidpointRounding.ToEven);
                partidos[i].DiputadosTotales += cantCurules;
                partidos[i].CurulesDist = cantCurules;
                do
                {
                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 20; y++)
                        {
                            if (congreso[x, y] == "|   |" && partidos[i].CurulesDist > 0)
                            {
                                switch (partidos[i].ColorPartido)
                                {
                                    case "azul":
                                        congreso[x, y] = "|LDA|";
                                        break;
                                    case "verde":
                                        congreso[x, y] = "|LDV|";
                                        break;
                                    case "naranja":
                                        congreso[x, y] = "|LDN|";
                                        break;
                                    case "rojo":
                                        congreso[x, y] = "|LDR|";
                                        break;
                                }
                                partidos[i].CurulesDist--;
                            }
                        }
                    }
                } while (partidos[i].CurulesDist > 0);
            }
        }

        static void GraficarDistribucionCongreso()
        {
            for (int j = 0; j < 4; j++)
            {
                switch (partidos[j].ColorPartido.ToString())
                {
                    case "azul":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "rojo":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "verde":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "naranja":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                }
                Console.WriteLine("Partido: " + partidos[j].ColorPartido.ToString() + " Cantidad de Curules: " + partidos[j].DiputadosTotales);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("");
            Console.WriteLine("                                             CONGRESO                                     ");
            Console.WriteLine("");

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (congreso[i, j] == "|LNA|" || congreso[i, j] == "|LDA|")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(congreso[i, j]);
                    }
                    else if (congreso[i, j] == "|LNV|" || congreso[i, j] == "|LDV|")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(congreso[i, j]);
                    }
                    else if (congreso[i, j] == "|LNR|" || congreso[i, j] == "|LDR|")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(congreso[i, j]);
                    }
                    else if (congreso[i, j] == "|LNN|" || congreso[i, j] == "|LDN|")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(congreso[i, j]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(congreso[i, j]);
                    }
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("                                 PRESIONE UNA TECLA PARA CONTINUAR...                 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        static void AnularElecciones()
        {
            double votosObtenidos;
            double porcentaje;
            string justificacion;
            do
            {
                Console.Write("Ingrese Su Justificacion Para Anular las Elecciones: ");
                justificacion = Console.ReadLine().Trim();
                Console.Clear();
            } while (justificacion == "");

            Console.WriteLine("                                              JUSTIFICACION                                                      ");
            Console.WriteLine("");
            Console.WriteLine(justificacion);
            Console.WriteLine("");

            Console.WriteLine("                                        RESUMEN DE LAS VOTACIONES                                                ");
            Console.WriteLine("");
            for (int i = 0; i < partidos.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write("                     |        ");
                    switch (partidos[i].ColorPartido.ToString())
                    {
                        case "azul":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case "rojo":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case "verde":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case "naranja":
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                    }
                    Console.Write(partidos[i].ColorPartido);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("        |        ");
                }
                else
                {
                    switch (partidos[i].ColorPartido.ToString())
                    {
                        case "azul":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case "rojo":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case "verde":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case "naranja":
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                    }
                    Console.Write(partidos[i].ColorPartido);
                    Console.Write("        |        ");
                }

            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("___________________________________________________________________________________________________________________");
            Console.WriteLine();
            Console.Write("Presidente           |");
            for (int i = 0; i < partidos.Length; i++)
            {
                votosObtenidos = partidos[i].VotosPresidente;
                porcentaje = Math.Round((votosObtenidos / cantVotantes) * 100, 0, MidpointRounding.ToEven);
                Console.Write("    " + partidos[i].VotosPresidente + " = " + porcentaje + "%" + "           |");
            }
            Console.WriteLine();
            Console.Write("Alcalde              |");
            for (int i = 0; i < partidos.Length; i++)
            {
                votosObtenidos = partidos[i].VotosAlcalde;
                porcentaje = Math.Round((votosObtenidos / cantVotantes) * 100, 0, MidpointRounding.ToEven);
                Console.Write("    " + partidos[i].VotosAlcalde + " = " + porcentaje + "%" + "           |");
            }
            Console.WriteLine();
            Console.Write("Diputado Nacional    |");
            for (int i = 0; i < partidos.Length; i++)
            {
                votosObtenidos = partidos[i].VotosDiputadoNac;
                porcentaje = Math.Round((votosObtenidos / cantVotantes) * 100, 0, MidpointRounding.ToEven);
                Console.Write("    " + partidos[i].VotosDiputadoNac + " = " + porcentaje + "%" + "           |");
            }
            Console.WriteLine();
            Console.Write("Diputado Distrital   |");
            for (int i = 0; i < partidos.Length; i++)
            {
                votosObtenidos = partidos[i].VotosDiputadoDistrital;
                porcentaje = Math.Round((votosObtenidos / cantVotantes) * 100, 0, MidpointRounding.ToEven);
                Console.Write("    " + partidos[i].VotosDiputadoDistrital + " = " + porcentaje + "%" + "           |");
            }
            Console.WriteLine();
            Console.Write("Votos Totales        |");
            for (int i = 0; i < partidos.Length; i++)
            {
                votosObtenidos = partidos[i].VotosPresidente + partidos[i].VotosAlcalde + partidos[i].VotosDiputadoNac + partidos[i].VotosDiputadoDistrital;
                porcentaje = Math.Round((votosObtenidos / (cantVotantes * 4)) * 100, 0, MidpointRounding.ToEven);
                Console.Write("    " + votosObtenidos + " = " + porcentaje + "%" + "          |");
            }
            Console.WriteLine();
            Console.WriteLine("___________________________________________________________________________________________________________________");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                      PRESIONE UNA TECLA PARA CONTINUAR                                            ");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            cantVotantes = 0;
            Votos = new Voto[5000];
            maxVotos = 5000;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------------------");
            Console.WriteLine("VOTACIONES ANULADAS CORRECTAMENTE");
            Console.WriteLine("---------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(1500);
            Console.Clear();
        }

        static void MenuGraficaBarras()
        {
            int opcion;
            Console.WriteLine("");
            Console.WriteLine("      GRAFICA DE BARRAS     ");
            Console.WriteLine("");
            Console.WriteLine("1.Presidente/Vicepresidente");
            Console.WriteLine("2.Alcalde");
            Console.WriteLine("3.Diputado Listado Nacional");
            Console.WriteLine("4.Diputado Listado Distrital");
            Console.WriteLine("5.Regresar");
            Console.WriteLine("");
            Console.WriteLine("Ingresar opcion: ");
            opcion = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("PRESIDENTES");
                    VaciarGrafica();
                    LlenarGrafica("presidente");
                    GraficarBarras();
                    MenuGraficaBarras();
                    break;
                case 2:
                    Console.WriteLine("ALCALDES");
                    VaciarGrafica();
                    LlenarGrafica("alcalde");
                    GraficarBarras();
                    MenuGraficaBarras();
                    break;
                case 3:
                    Console.WriteLine("DIPUTADOS LISTADO NACIONAL");
                    VaciarGrafica();
                    LlenarGrafica("diputadoNac");
                    GraficarBarras();
                    MenuGraficaBarras();
                    break;
                case 4:
                    Console.WriteLine("DIPUTADOS LISTADO DISTRITAL");
                    VaciarGrafica();
                    LlenarGrafica("diputadoDist");
                    GraficarBarras();
                    MenuGraficaBarras();
                    break;
                case 5:
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Opcion Incorrecta");
                    Console.WriteLine("-----------------");
                    System.Threading.Thread.Sleep(1500);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    MenuGraficaBarras();
                    break;
            }
        }

        static void LlenarGrafica(string puesto)
        {
            double porcentaje = 0;
            double cantidad = 0;
            double votosObtenidos;
            switch (puesto)
            {
                case "presidente":
                    //LLENAR GRAFICA PRESIDENTES
                    for (int i = 0; i < 4; i++)
                    {
                        votosObtenidos = partidos[i].VotosPresidente;
                        porcentaje = votosObtenidos / cantVotantes;
                        cantidad = Math.Round(porcentaje * 20, 0, MidpointRounding.ToEven);
                        partidos[i].PorcentajeGrafica = cantidad;
                        do
                        {
                            for (int y = i; y < 4; y++)
                            {
                                for (int x = 0; x < 20; x++)
                                {
                                    if (graficaBarras[x, y] == "|   |" && partidos[i].PorcentajeGrafica > 0)
                                    {
                                        switch (partidos[i].ColorPartido)
                                        {
                                            case "azul":
                                                graficaBarras[x, y] = "| * |";
                                                break;
                                            case "verde":
                                                graficaBarras[x, y] = "| + |";
                                                break;
                                            case "naranja":
                                                graficaBarras[x, y] = "| ? |";
                                                break;
                                            case "rojo":
                                                graficaBarras[x, y] = "| $ |";
                                                break;
                                        }
                                        partidos[i].PorcentajeGrafica--;
                                    }
                                }
                            }
                        } while (partidos[i].PorcentajeGrafica > 0);
                    }
                    break;
                case "alcalde":
                    //LLENAR GRAFICA ALCALDE
                    for (int i = 0; i < 4; i++)
                    {
                        votosObtenidos = partidos[i].VotosAlcalde;
                        porcentaje = votosObtenidos / cantVotantes;
                        cantidad = Math.Round(porcentaje * 20, 0, MidpointRounding.ToEven);
                        partidos[i].PorcentajeGrafica = cantidad;
                        do
                        {
                            for (int y = i; y < 4; y++)
                            {
                                for (int x = 0; x < 20; x++)
                                {
                                    if (graficaBarras[x, y] == "|   |" && partidos[i].PorcentajeGrafica > 0)
                                    {
                                        switch (partidos[i].ColorPartido)
                                        {
                                            case "azul":
                                                graficaBarras[x, y] = "| * |";
                                                break;
                                            case "verde":
                                                graficaBarras[x, y] = "| + |";
                                                break;
                                            case "naranja":
                                                graficaBarras[x, y] = "| ? |";
                                                break;
                                            case "rojo":
                                                graficaBarras[x, y] = "| $ |";
                                                break;
                                        }
                                        partidos[i].PorcentajeGrafica--;
                                    }
                                }
                            }
                        } while (partidos[i].PorcentajeGrafica > 0);
                    }
                    break;
                case "diputadoNac":
                    //LLENAR GRAFICA DIPUTADOS LISTADO NACIONAL
                    for (int i = 0; i < 4; i++)
                    {
                        votosObtenidos = partidos[i].VotosDiputadoNac;
                        porcentaje = votosObtenidos / cantVotantes;
                        cantidad = Math.Round(porcentaje * 20, 0, MidpointRounding.ToEven);
                        partidos[i].PorcentajeGrafica = cantidad;
                        do
                        {
                            for (int y = i; y < 4; y++)
                            {
                                for (int x = 0; x < 20; x++)
                                {
                                    if (graficaBarras[x, y] == "|   |" && partidos[i].PorcentajeGrafica > 0)
                                    {
                                        switch (partidos[i].ColorPartido)
                                        {
                                            case "azul":
                                                graficaBarras[x, y] = "| * |";
                                                break;
                                            case "verde":
                                                graficaBarras[x, y] = "| + |";
                                                break;
                                            case "naranja":
                                                graficaBarras[x, y] = "| ? |";
                                                break;
                                            case "rojo":
                                                graficaBarras[x, y] = "| $ |";
                                                break;
                                        }
                                        partidos[i].PorcentajeGrafica--;
                                    }
                                }
                            }
                        } while (partidos[i].PorcentajeGrafica > 0);
                    }
                    break;
                case "diputadoDist":
                    //LLENAR GRAFICA DIPUTADO LISTADO DISTRITAL
                    for (int i = 0; i < 4; i++)
                    {
                        votosObtenidos = partidos[i].VotosDiputadoDistrital;
                        porcentaje = votosObtenidos / cantVotantes;
                        cantidad = Math.Round(porcentaje * 20, 0, MidpointRounding.ToEven);
                        partidos[i].PorcentajeGrafica = cantidad;
                        do
                        {
                            for (int y = i; y < 4; y++)
                            {
                                for (int x = 0; x < 20; x++)
                                {
                                    if (graficaBarras[x, y] == "|   |" && partidos[i].PorcentajeGrafica > 0)
                                    {
                                        switch (partidos[i].ColorPartido)
                                        {
                                            case "azul":
                                                graficaBarras[x, y] = "| * |";
                                                break;
                                            case "verde":
                                                graficaBarras[x, y] = "| + |";
                                                break;
                                            case "naranja":
                                                graficaBarras[x, y] = "| ? |";
                                                break;
                                            case "rojo":
                                                graficaBarras[x, y] = "| $ |";
                                                break;
                                        }
                                        partidos[i].PorcentajeGrafica--;
                                    }
                                }
                            }
                        } while (partidos[i].PorcentajeGrafica > 0);
                    }
                    break;
            }
        }

        static void GraficarBarras()
        {
            Console.WriteLine("");
            Console.WriteLine("                                         GRAFICA DE BARRAS                                     ");
            Console.WriteLine("");

            for (int i = 19; i >= 0; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (graficaBarras[i, j] == "| * |")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(graficaBarras[i, j]);
                    }
                    else if (graficaBarras[i, j] == "| + |")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(graficaBarras[i, j]);
                    }
                    else if (graficaBarras[i, j] == "| ? |")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(graficaBarras[i, j]);
                    }
                    else if (graficaBarras[i, j] == "| $ |")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(graficaBarras[i, j]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(graficaBarras[i, j]);
                    }
                }
                Console.WriteLine();
            }

            for (int j = 0; j < 4; j++)
            {
                switch (partidos[j].ColorPartido.ToString())
                {
                    case "azul":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("| A |");
                        break;
                    case "rojo":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("| R |");
                        break;
                    case "verde":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("| V |");
                        break;
                    case "naranja":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("| N |");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("                                 PRESIONE UNA TECLA PARA CONTINUAR...                 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        static void SumarVotosPresidente(string presidente)
        {
            for (int i = 0; i < partidos.Length; i++)
            {
                if (partidos[i].ColorPartido == presidente)
                {
                    partidos[i].VotosPresidente++;
                }
            }
        }

        static void SumarVotosAlcalde(string alcalde)
        {
            for (int i = 0; i < partidos.Length; i++)
            {
                if (partidos[i].ColorPartido == alcalde)
                {
                    partidos[i].VotosAlcalde++;
                }
            }
        }

        static void SumarVotosDiputadoNac(string diputadoNac)
        {
            for (int i = 0; i < partidos.Length; i++)
            {
                if (partidos[i].ColorPartido == diputadoNac)
                {
                    partidos[i].VotosDiputadoNac++;
                }
            }
        }

        static void SumarVotosDiputadoDist(string diputadoDist)
        {
            for (int i = 0; i < partidos.Length; i++)
            {
                if (partidos[i].ColorPartido == diputadoDist)
                {
                    partidos[i].VotosDiputadoDistrital++;
                }
            }
        }

        static void Main(string[] args)
        {
            Login();
        }
    }
}
