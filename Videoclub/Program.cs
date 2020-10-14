
using DustInTheWind.ConsoleTools;
using DustInTheWind.ConsoleTools.Menues;
using DustInTheWind.ConsoleTools.Menues.MenuItems;
using DustInTheWind.ConsoleTools.TabularData;
using PanoramicData.ConsoleExtensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Videoclub.Models;

namespace Videoclub
{
    class Program
    {
        public static bool Salir { get; set; }
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Salir = false;
                do
                {
                    string[] menu = new string[2];
                    menu[0] = "1.Login";
                    menu[1] = "2.Registro";
                    MenuOne(menu);

                } while (Service.User == null);

                do
                {
                    string[] menu = new string[4];
                    menu[0] = "1.Ver Peliculas";
                    menu[1] = "2.Ver Alquileres";
                    menu[2] = "3.Modificar perfil";
                    menu[3] = "4.Salir";

                    MenuTwo(menu, 0);

                } while (!Salir);

            } while (true);
        }


        public static void MenuRegistro()
        {
            Console.Clear();
            string print = "\n\n\t\tREGISTRO\n\n\t\tIntroduzca su nombre\n\n\t\t";
            Console.Write(print);
            string nombre = Console.ReadLine();
            print += nombre;
            print += "\n\t\tIntroduzca su primer apellido\n\n\t\t";
            Console.Clear();
            Console.Write(print);
            string primera = Console.ReadLine();
            print += primera + "\n\t\tIntroduzca su segundo apellido\n\n\t\t";
            Console.Clear();
            Console.Write(print);
            string segundo = Console.ReadLine();
            print += segundo + "\n\t\tIntroduzca su fecha de nacimiento (dd/mm/aaaa)\n\n\t\t";
            bool dateok;
            DateTime fnac = DateTime.Now;
            do
            {
                Console.Clear();
                Console.Write(print);
                try
                {
                    fnac = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.CurrentCulture);
                    print += fnac;
                    dateok = true;
                }
                catch (Exception)
                {
                    dateok = false;
                    Console.Write("\n\n\n\t\tIntroduzca una fecha valida!");
                    Console.Write("\n\n\n\t\tPulse una tecla para volver a intentar...");
                    Console.ReadKey();


                }
            } while (!dateok);
            print += "\n\t\tIntroduzca su email\n\n\t\t";
            Console.Clear();
            Console.Write(print);
            string email = Console.ReadLine();
            print += email;

            bool passEq = false;
            do
            {
                Console.Clear();
                string printp = "\n\t\tIntroduzca una contraseña\n\n\t\t";
                Console.Write(print);
                Console.Write(printp);
                string password = ConsolePlus.ReadPassword();
                string passwordM = "";
                for (int i = 0; i < password.Length; i++)
                {
                    passwordM += "*";
                }
                printp += passwordM + "\n\t\tVuelva a introducir la misma contraseña\n\n\t\t";
                Console.Clear();
                Console.Write(print);
                Console.Write(printp);
                string password2 = ConsolePlus.ReadPassword();


                if (password.Equals(password2))
                {
                    Usuario reg = new Usuario(nombre, primera, segundo, fnac, email, password);
                    Service.User = Service.Register(reg);
                    passEq = true;
                }

            } while (!passEq);
        }

        public static void MenuLogin()
        {

            Console.Clear();
            Console.WriteLine("\n\n\t\tINICIO DE SESION");
            Console.WriteLine("\n\n\n\n\t\tIntroduzca email");
            Console.Write("\n\t\t");
            string email = Console.ReadLine();
            Console.WriteLine("\n\n\t\tIntroduzca contraseña");
            Console.Write("\n\t\t");
            string password = ConsolePlus.ReadPassword();

            Usuario log = Service.Login(email, password);
            if (log != null)
            {
                Service.User = log;

            }
            else
            {
                Console.WriteLine("\n\n\t\tUsuario no encontrado. Asegurese de introducir correctamente el email y la contraseña. \n\t\tSi no está registrado pulse 2\n\n\t\tPulse una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }


        public static void TablaPelicula(string titulo, List<Pelicula> pelicula)
        {

            DataGrid dataGrid = new DataGrid(titulo);

            dataGrid.Columns.Add("ID ");
            dataGrid.Columns.Add("TITULO");
            dataGrid.Columns.Add("GENERO");
            dataGrid.Columns.Add("EDAD RECOMENDADA");
            pelicula.ForEach(x =>
            {
                dataGrid.Rows.Add(x.Id, x.Titulo, x.Genero.Area, x.EdadRecomen.Titulo);
            });
            dataGrid.DisplayBorderBetweenRows = true;
            dataGrid.DisplayColumnHeaders = true;
            dataGrid.BackgroundColor = ConsoleColor.Blue;
            dataGrid.Margin = new Thickness(2, 0, 0, 0);
            dataGrid.PaddingLeft = 3;
            dataGrid.BorderTemplate = BorderTemplate.SingleLineBorderTemplate;
            dataGrid.Display();
        }
        public static void TablaAlquiler(string titulo, List<Alquiler> alquiler)
        {

            DataGrid dataGrid = new DataGrid(titulo);

            dataGrid.Columns.Add("ID");
            dataGrid.Columns.Add("TITULO");
            dataGrid.Columns.Add("FECHA ALQUILER");
            dataGrid.Columns.Add("FECHA DEVOLUCION");
            dataGrid.Columns.Add("TIEMPO DE ALQUILER");
            dataGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            alquiler.ForEach(x =>
            {
                dataGrid.Rows.Add(x.Pelicula.Id, x.Pelicula.Titulo, x.FechaAlquiler, x.FechaDevolucion.ToString(), x.TiempoPrestamo.Titulo);
                dataGrid.BackgroundColor = ConsoleColor.Red;
            });
            dataGrid.DisplayBorderBetweenRows = true;
            dataGrid.DisplayColumnHeaders = true;
            dataGrid.BackgroundColor = ConsoleColor.Blue;
            dataGrid.Margin = new Thickness(1, 1, 0, 1);
            dataGrid.PaddingLeft = 2;
            dataGrid.BorderTemplate = BorderTemplate.SingleLineBorderTemplate;
            dataGrid.Display();
        }

        public static void MenuOne(string[] options)
        {
            ScrollMenu scrollMenu = new ScrollMenu();
            scrollMenu.HorizontalAlignment = HorizontalAlignment.Left;
            Console.WriteLine("\n\n\n\n\t BIENVENIDO AL VIDEOCLUB\n");
            for (int i = 0; i < options.Length; i++)
            {
                scrollMenu.AddItem(new LabelMenuItem()
                {
                    IsEnabled = true,
                    IsVisible = true,
                    Text = options[i],
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    PaddingLeft = 9,
                    PaddingRight = 30 - options[i].Length,
                    ShortcutKey = ShortCut(i),
                    Command = new Opcion1Command(i)
                });
            }
            scrollMenu.Display();
        }

        public static void MenuTwo(string[] menu, int j)
        {
            Console.Clear();
            ScrollMenu scrollMenu = new ScrollMenu();
            scrollMenu.HorizontalAlignment = HorizontalAlignment.Left;
            Console.WriteLine($"\n\n\n\n\t BIENVENIDO AL VIDEOCLUB {Service.User.Nombre}\n");
            for (int i = 0; i < menu.Length; i++)
            {
                if (j == 0)
                {
                    scrollMenu.AddItem(new LabelMenuItem()
                    {
                        IsEnabled = true,
                        IsVisible = true,
                        Text = menu[i],
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        PaddingLeft = 9,
                        PaddingRight = 30 - menu[i].Length,
                        ShortcutKey = ShortCut(i),
                        Command = new Opcion2Command(i)

                    });
                }
                else if (j == 1)
                {
                    scrollMenu.AddItem(new LabelMenuItem()
                    {
                        IsEnabled = true,
                        IsVisible = true,
                        Text = menu[i],
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        PaddingLeft = 9,
                        PaddingRight = 30 - menu[i].Length,
                        ShortcutKey = ShortCut(i),
                        Command = new Opcion3Command(i)

                    });
                }
                else if (j == 2)
                {
                    scrollMenu.AddItem(new LabelMenuItem()
                    {
                        IsEnabled = true,
                        IsVisible = true,
                        Text = menu[i],
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        PaddingLeft = 9,
                        PaddingRight = 30 - menu[i].Length,
                        ShortcutKey = ShortCut(i),
                        Command = new Opcion4Command(i)

                    });
                }
                else if (j == 3)
                {
                    scrollMenu.AddItem(new LabelMenuItem()
                    {
                        IsEnabled = true,
                        IsVisible = true,
                        Text = menu[i],
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        PaddingLeft = 9,
                        PaddingRight = 30 - menu[i].Length,
                        ShortcutKey = ShortCut(i),
                        Command = new Opcion5Command(i)

                    });
                }
            }

            scrollMenu.Display();
        }
        private static ConsoleKey? ShortCut(int i)
        {
            switch (i + 1)
            {
                case 1:
                    return ConsoleKey.D1;
                case 2:
                    return ConsoleKey.D2;
                case 3:
                    return ConsoleKey.D3;
                case 4:
                    return ConsoleKey.D4;
                case 5:
                    return ConsoleKey.D5;
                case 6:
                    return ConsoleKey.D6;
                case 7:
                    return ConsoleKey.D7;
                case 8:
                    return ConsoleKey.D8;
                case 9:
                    return ConsoleKey.D9;
                case 10:
                    return ConsoleKey.D0;
            }
            return null;
        }
    }

    internal class Opcion4Command : ICommand
    {
        private int i;

        public Opcion4Command(int i)
        {
            this.i = i;
        }

        public bool IsActive => true;

        public void Execute()
        {

            switch (i + 1)
            {
                case 1:
                    //pendiente de devolver
                    Console.Clear();
                    Program.TablaAlquiler("PENDIENTE DE DEVOLVER",
                    Service.GetPeliculasAlquiladas().Where(x => x.FechaDevolucion == null).ToList());
                    Console.WriteLine("\n\t\t1.DEVOLVER\t\t\t\t\t\t\t2.VOLVER");
                    Console.Write("\n\t\tEleccion: ");
                    char respde = Console.ReadKey().KeyChar;
                    if (respde.Equals('1'))
                    {
                        Console.Write("\n\n\t\tIntroduzca el ID de la pelicula a devolver:...");
                        string id2 = Console.ReadLine();
                        if (Service.Devolver(id2))
                        {
                            Console.WriteLine($"\n\n\t\tPELICULA {id2} DEVUELTA");
                        }
                        else
                        {
                            Console.WriteLine($"\n\n\t\tERROR AL DEVOLVER LA PELICULA {id2}.");
                        }
                        Console.WriteLine($"\n\n\t\tPulse cualquier tecla para volver...");
                        Console.ReadKey();

                    }
                    else if (respde.Equals('2'))
                    {
                        new Opcion2Command(1).Execute();
                    }
                    else { 
                    
                    }
                    break;
                case 2:
                    //ver historico
                    Console.Clear();
                    Program.TablaAlquiler("HISTORICO ALQUILADAS",
                                   Service.GetPeliculasAlquiladas().OrderByDescending(x => x.FechaDevolucion).ToList());
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t1.VOLVER");
                    Console.Write("\n\t\tEleccion: ");
                    char resp = Console.ReadKey().KeyChar;
                    if (resp.Equals('1'))
                    {
                        new Opcion2Command(1).Execute();
                    }
                    else { 
                    
                    }
                    break;
                case 3:
                    //devolucion rapida

                    Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\tIntroduzca el ID de la pelicula a devolver:...");
                    string id1 = Console.ReadLine();

                    if (Service.Devolver(id1))
                    {
                        Console.WriteLine($"\n\n\t\tPELICULA {id1} DEVUELTA");
                    }
                    else
                    {
                        Console.WriteLine($"\n\n\t\tERROR AL DEVOLVER LA PELICULA {id1}.");
                    }
                    Console.WriteLine($"\n\n\t\tPulse cualquier tecla para volver...");
                    Console.ReadKey();
                    break;
                case 4:
                    //volver
                    string[] menu = new string[4];
                    menu[0] = "1.Ver Peliculas";
                    menu[1] = "2.Ver Alquileres";
                    menu[2] = "3.Modificar perfil";
                    menu[3] = "4.Salir";
                    Program.MenuTwo(menu, 0);
                    break;

                default:
                    Console.Write("\n\n\t\tOPCION INCORRECTA! Pulse un tecla y vuelva a intentarlo...");
                    Console.ReadKey();

                    menu = new string[4];
                    menu[0] = "1.Pendientes de Devolver";
                    menu[1] = "2.Ver Histórico";
                    menu[2] = "3.Devolución Rápida";
                    menu[3] = "4.Volver";
                    Program.MenuTwo(menu, 2);
                    break;
            }
        }
    }

    internal class Opcion5Command : ICommand
    {
        private int i;

        public Opcion5Command(int i)
        {
            this.i = i;
        }

        public bool IsActive => true;

        public void Execute()
        {
            switch (i + 1)
            {
                case 1:
                    //modificar
                    Console.Clear();
                    string printp = "\n\t\tIntroduzca una contraseña\n\n\t\t";
                    Console.Write(printp);
                    string password = ConsolePlus.ReadPassword();
                    string passwordM = "";
                    for (int i = 0; i < password.Length; i++)
                    {
                        passwordM += "*";
                    }
                    printp += passwordM + "\n\t\tVuelva a introducir la misma contraseña\n\n\t\t";
                    Console.Clear();
                    Console.Write(printp);
                    string password2 = ConsolePlus.ReadPassword();
                    string error = "La contraseña no se ha podido cambiar";

                    if (password.Equals(password2))
                    {

                        Service.ChangePassword(password);
                        error = "Contraseña cambiada";
                    }
                    Console.WriteLine($"\n\n\n\n\n\n\n\t\t{error}\n\n\t\tPulse una tecla para continuar...");
                    Console.ReadKey();
                    new Opcion2Command(2).Execute();

                    break;
                case 2:
                    //dar de baja
                    Console.Clear();
                    Console.Write("\n\n\t\tESTA SEGURO DE PROCEDER A LA BAJA??\n\n\t\tPulse s para si, cualquier otra tecla para cancelar.");
                    if (Console.ReadKey().KeyChar.ToString().ToLower() == "s")
                    {
                        if (Service.GetPeliculasAlquiladas().Where(x => x.FechaDevolucion == null).Count() == 0)
                        {
                            Service.DarDeBaja();
                            Console.Write("\n\n\t\tESPERAMOS VOLVERTE A VER PRONTO");
                            Program.Salir = true;
                        }
                        else
                        {
                            Console.Write("\n\n\t\tPrimero tienes que devolver todas las peliculas");

                        }

                        Console.Write("\n\n\t\tPulse una tecla para finalizar...");
                        Console.ReadKey();

                    }


                    break;
                case 3:
                    //volver
                    string[] menu = new string[4];
                    menu[0] = "1.Ver Peliculas";
                    menu[1] = "2.Ver Alquileres";
                    menu[2] = "3.Modificar perfil";
                    menu[3] = "4.Salir";
                    Program.MenuTwo(menu, 0);
                    break;
                default:
                    Console.Write("\n\n\t\tOPCION INCORRECTA! Pulse un tecla y vuelva a intentarlo...");
                    Console.ReadKey();

                    menu = new string[3];
                    menu[0] = "1.Cambiar Contraseña";
                    menu[1] = "2.Darse de baja";
                    menu[2] = "3.Volver";
                    Program.MenuTwo(menu, 3);
                    break;
            }
        }
    }

    internal class Opcion3Command : ICommand
    {
        private int i;
        private string[] menu;

        public Opcion3Command(int i)
        {
            this.i = i;
        }

        public bool IsActive => true;

        public void Execute()
        {

            switch (i + 1)
            {
                case 1:
                    //ver todas
                    Console.WriteLine("\n\n\t\tTODAS LAS PELICULA\n\n");

                    MostrarPeliculas("TODA LAS PELICULAS", Service.GetPeliculas(), 0);

                    break;
                case 2:
                    //ver por genero
                    bool oke = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\t\tGENEROS\n\n");
                        Service.GetGeneros().ForEach(x =>
                        Console.WriteLine($"\t\t{x.Id}.{x.Area}"));
                        Console.Write("\n\n\t\tEleccion:");
                        int idGenero;
                        bool ok = Int32.TryParse(Console.ReadLine(), out idGenero);
                        if (ok)
                        {
                            Genero g = Service.GetGenero(idGenero);
                            if (g != null)
                            {
                                MostrarPeliculas($"PELICULAS DE {Service.GetGenero(idGenero).Area.ToUpper()}", Service.GetPeliculas().Where(x => x.GeneroId == idGenero).ToList(), 1);
                                oke = true;
                            }
                        }
                        if (!oke)
                        {

                            Console.Write("\n\n\t\tOPCION ERRONEA. Pulse una tecla y vuelva a intentarlo...");
                            Console.ReadKey();
                        }

                    } while (!oke);
                    break;
                case 3:
                    //ver por edad recomendada
                    bool okey = false;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n\t\tEDADES RECOMENDADAS\n\n");
                        Service.GetEdadesRecomendadas().ForEach(x =>
                        Console.WriteLine($"\t\t{x.Id}.{x.Titulo}"));
                        Console.Write("\n\n\t\tEleccion:");
                        int idEdad;
                        bool ok1 = Int32.TryParse(Console.ReadLine(), out idEdad);
                        if (ok1)
                        {
                            EdadRecomendada er = Service.GetEdadRecomendada(idEdad);
                            if (er != null)
                            {
                                MostrarPeliculas($"PELICULAS PARA {er.Titulo.ToUpper()}", Service.GetPeliculas().Where(x => x.EdadRecomendada == idEdad).ToList(), 2);
                                okey = true;
                            }
                        }

                        if (!okey)
                        {
                            Console.Write("\n\n\t\tOPCION ERRONEA. Pulse una tecla y vuelva a intentarlo...");
                            Console.ReadKey();
                        }

                    } while (!okey);

                    break;
                case 4:
                    //buscar pelicula
                    Console.Clear();
                    Console.Write("\n\n\t\tIntroduzca el título a buscar: ");
                    string t = Console.ReadLine();
                    List<Pelicula> search = Service.BuscarPelicula(t.ToLower());

                    if (search.Count > 0)
                    {
                        MostrarPeliculas($"BUSQUEDA:{t.ToUpper()}", search, 3);

                    }
                    else
                    {
                        Console.Write("\n\n\t\tNo hay resultados...\n\n\t\tPulse una tecla para volver... ");
                        Console.ReadKey();
                        new Opcion2Command(0).Execute();
                    }

                    break;
                case 5:
                    //volver
                    menu = new string[4];
                    menu[0] = "1.Ver Peliculas";
                    menu[1] = "2.Ver Alquileres";
                    menu[2] = "3.Modificar perfil";
                    menu[3] = "4.Salir";
                    Program.MenuTwo(menu, 0);

                    break;
                default:
                    Console.Write("\n\n\t\tOPCION INCORRECTA! Pulse un tecla y vuelva a intentarlo...");
                    Console.ReadKey();

                    menu = new string[5];
                    menu[0] = "1.Ver todas";
                    menu[1] = "2.Ver por Genero";
                    menu[2] = "3.Ver por Edad Recomendada";
                    menu[3] = "4.Buscar Pelicula";
                    menu[4] = "5.Volver";
                    Program.MenuTwo(menu, 1);
                    break;
            }
        }

        private void MostrarPeliculas(string tittle, List<Pelicula> peliculas, int opt)
        {
            bool volver = false;
            do
            {
                Console.Clear();
                Program.TablaPelicula(tittle, peliculas);
                Console.WriteLine("\n\t\t1.VER DETALLES\t\t\t2.ALQUILAR\t\t\t3.VOLVER");
                Console.Write("\n\t\tEleccion: ");
                char resp = Console.ReadKey().KeyChar;
                switch (resp)
                {
                    case '1':
                        Console.Write("\n\n\t\tIntroduzca el ID de la pelicula para ver detalles:...");
                        int id1;
                        bool ok = Int32.TryParse(Console.ReadLine(), out id1);
                        if (ok)
                        {
                            Pelicula p = Service.GetPelicula(id1);
                            if (p != null)
                            {
                                VerDetalle(p);
                                volver = true;

                            }
                            else

                            {
                                Console.Write("\n\n\t\tERROR AL BUSCAR LA PELICULA");
                                Console.WriteLine($"\n\n\t\tPulse cualquier tecla para volver a intentarlo...");
                                Console.ReadKey();
                                volver = false;
                            }

                        }
                        else
                        {
                            Console.Write("\n\n\t\tID DE LA PELICULA INCORRECTO");
                            Console.WriteLine($"\n\n\t\tPulse cualquier tecla para volver a intentarlo...");
                            Console.ReadKey();
                            volver = false;
                        }
                        break;
                    case '2':
                        Console.Write("\n\n\t\tIntroduzca el ID de la pelicula a alquilar:...");


                        int id2;
                        bool ok1 = Int32.TryParse(Console.ReadLine(), out id2);
                        if (ok1)
                        {
                            Console.WriteLine("\n\t\tTiempo de alquiler\n");
                            Service.GetTiempoPrestamos().ForEach(x =>
                            {
                                Console.WriteLine($"\t\t{x.idTiempo}.{x.Titulo}");
                            });
                            Console.Write("\t\tElija una opcion...");
                            int tp;

                            bool ok2;
                            do
                            {
                                ok2 = Int32.TryParse(Console.ReadLine(), out tp);

                                if (ok2)
                                {
                                    Pelicula pa = Service.GetPelicula(id2);
                                    if (pa != null)
                                    {
                                        bool finish = Service.Alquilar(pa.Id, tp);

                                        if (finish)
                                        {
                                            Console.WriteLine($"\n\n\t\tLA PELICULA {pa.Id} ({pa.Titulo}) HA SIDO ALQUILADA.\n\n\t\t Pulse cualquier tecla para volver...");
                                            volver = true;
                                            Console.ReadKey();
                                            menu = new string[5];
                                            menu[0] = "1.Ver todas";
                                            menu[1] = "2.Ver por Genero";
                                            menu[2] = "3.Ver por Edad Recomendada";
                                            menu[3] = "4.Buscar Pelicula";
                                            menu[4] = "5.Volver";
                                            Program.MenuTwo(menu, 1);
                                        }
                                        else
                                        {

                                            Console.WriteLine($"\n\n\t\tYA HA ALQUILADO UN MAXIMO DE 4 PELICULAS.\n\n\t\t Pulse cualquier tecla para volver...");
                                            volver = false;
                                            Console.ReadKey();
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine($"\n\n\t\tID DE LA PELICULA INCORRECTO\n\n\t\t Pulse cualquier tecla para volver...");
                                        Console.ReadKey();
                                        volver = false;
                                    }
                                }
                                else
                                {
                                    Console.Write("\n\n\t\tOPCION ERRONEA. Elija una opción y vuelva a intentarlo...");
                                    Console.ReadKey();
                                    volver = false;
                                }
                            } while (!ok2);
                        }
                        else
                        {
                            Console.Write("\n\n\t\tERROR AL ALQUILAR LA PELICULA");
                            Console.WriteLine($"\n\n\t\tPulse cualquier tecla para volver a intentarlo...");
                            Console.ReadKey();
                            volver = false;
                        }

                        break;
                    case '3':
                        volver = true;
                        if (opt == 0)
                        {
                            menu = new string[5];
                            menu[0] = "1.Ver todas";
                            menu[1] = "2.Ver por Genero";
                            menu[2] = "3.Ver por Edad Recomendada";
                            menu[3] = "4.Buscar Pelicula";
                            menu[4] = "5.Volver";
                            Program.MenuTwo(menu, 1);
                        }
                        else if (opt > 0)
                        {
                            Console.WriteLine("\n\n\t\tPulse enter para volver al menu o escape para volver al inicio");
                            if (Console.ReadKey().Key == ConsoleKey.Escape)
                            {
                                menu = new string[5];
                                menu[0] = "1.Ver todas";
                                menu[1] = "2.Ver por Genero";
                                menu[2] = "3.Ver por Edad Recomendada";
                                menu[3] = "4.Buscar Pelicula";
                                menu[4] = "5.Volver";
                                Program.MenuTwo(menu, 1);
                            }
                            else
                            {
                                MostrarPeliculas(tittle, peliculas, opt);
                            }

                        }
                        break;
                    default:
                        
                        Console.WriteLine("\n\n\t\tOPCION INCORRECTA!");
                        Console.Write("\n\n\t\tPulse una tecla para continuar...");
                        Console.ReadKey();
                        volver = false;

                        break;
                }
            } while (!volver);
        }

        private void VerDetalle(Pelicula pelicula)
        {
            bool salir = false;
            do
            {
                Console.Clear();
                Console.WriteLine($"\n\n\t\tDETALLE DE LA PELICULA CON ID {pelicula.Id}");
                Console.WriteLine($"\n\n\t\tTITULO {pelicula.Titulo}");
                Console.WriteLine($"\n\n\t\tGENERO {pelicula.GeneroId}");
                Console.WriteLine($"\n\n\t\tEDAD RECOMENDADA {pelicula.EdadRecomendada}");
                string sinopsis = pelicula.Sinopsis;
                for (int i = 60; i < pelicula.Sinopsis.Length; i += 60)
                {
                    sinopsis = sinopsis.Insert(i, "\n\t\t\t");
                }
                Console.WriteLine($"\n\n\t\tSINOPSIS {sinopsis}");
                Console.WriteLine("\n\t\t1.ALQUILAR\t\t\t2.VOLVER\n");
                Console.Write("\t\tLa opcion elegida es:...");
                string opc = Console.ReadLine();
                if (opc.Equals("1"))
                {
                    Console.WriteLine("\n\t\tTiempo de alquiler\n");
                    Service.GetTiempoPrestamos().ForEach(x =>
                    {
                        Console.WriteLine($"\t\t{x.idTiempo}.{x.Titulo}");
                    });
                    Console.Write("\t\tElija una opcion...");

                    int tp;
                    bool oki = false;
                    bool ok = Int32.TryParse(Console.ReadLine(), out tp);
                    string res = "";
                    if (ok)
                    {
                        TiempoPrestamo tm = Service.GetTiempoPrestamo(tp);
                        if (tm != null)
                        {
                            oki = Service.Alquilar(pelicula.Id, tm.idTiempo);
                            salir = false;
                            if (oki)
                            {
                                res = $"\n\t\tHAS ALQUILADO LA PELICULA {pelicula.Id}";

                            }
                            else
                            {
                                res = $"\n\t\tYA TIENES ALQUILADA ESTA PELICULA.";
                                salir = true;

                            }
                        }
                        else
                        {
                            res = $"\n\t\tSELECCIONE UNA DE LAS OPCIONES MOSTRADAS.";
                            salir = true;

                        }
                    }
                    else
                    {
                        res = $"\n\t\tINTRODUZCA UNA OPCION VALIDA.";
                        salir = true;

                    }

                    Console.WriteLine(res);
                    Console.WriteLine($"\n\n\t\tPulse cualquier tecla para volver...");
                    Console.ReadKey();

                }
                else if (opc.Equals("2"))
                {

                    new Opcion3Command(0).Execute();
                }
                else
                {
                    salir = true;
                    Console.WriteLine($"\n\n\t\tOPCION INCORRECTA!");
                    Console.WriteLine($"\n\n\t\tPulse cualquier tecla para volver a intentar...");
                    Console.ReadKey();
                }
            } while (salir);
        }
    }

    internal class Opcion2Command : ICommand
    {
        private int i;
        private string[] menu;

        public Opcion2Command(int i)
        {
            this.i = i;
        }

        public bool IsActive => true;

        public void Execute()
        {
            switch (i + 1)
            {
                case 1:
                    menu = new string[5];
                    menu[0] = "1.Ver todas";
                    menu[1] = "2.Ver por Genero";
                    menu[2] = "3.Ver por Edad Recomendada";
                    menu[3] = "4.Buscar Pelicula";
                    menu[4] = "5.Volver";
                    Program.MenuTwo(menu, 1);

                    break;
                case 2:
                    menu = new string[4];
                    menu[0] = "1.Pendientes de Devolver";
                    menu[1] = "2.Ver Histórico";
                    menu[2] = "3.Devolución Rápida";
                    menu[3] = "4.Volver";
                    Program.MenuTwo(menu, 2);

                    break;
                case 3:
                    menu = new string[3];
                    menu[0] = "1.Cambiar Contraseña";
                    menu[1] = "2.Darse de baja";
                    menu[2] = "3.Volver";
                    Program.MenuTwo(menu, 3);

                    break;
                case 4:
                    Console.Clear();
                    Program.Salir = true;
                    Console.Write($"\n\n\n\t\tHASTA PRONTO {Service.User.Nombre.ToUpper()}\n\n\t\tPulsa cualquier tecla para continuar...");
                    Console.ReadKey();
                    Service.User = null;
                    break;
                default:
                    menu = new string[4];
                    menu[0] = "1.Ver Peliculas";
                    menu[1] = "2.Ver Alquileres";
                    menu[2] = "3.Modificar perfil";
                    menu[3] = "4.Salir";
                    Program.MenuTwo(menu, 0);
                    break;
            }
        }
    }

    internal class Opcion1Command : ICommand
    {
        private int i;

        public Opcion1Command(int i)
        {
            this.i = i;
        }

        public bool IsActive => true;

        public void Execute()
        {
            switch (i + 1)
            {
                case 1:
                    Program.MenuLogin();
                    break;
                case 2:
                    Program.MenuRegistro();
                    break;
            }

        }
    }


}
