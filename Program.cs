using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFETERÌA
{
    internal class Program
    {
        static string[,] nombres = new string[2, 20];
        static int[,] combos = new int[2, 20];
        static string[] nombreCombos = { "Combo 1: Café + Pan", "Combo 2: Jugo + Sandwich", "Combo 3: Té + Galletas" };
        static double[] precioCombos = { 3.50, 5.00, 4.00 };

        static void Main()
        {
            InicializarMatrices();
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("====== SISTEMA DE RESERVAS ======");
                Console.WriteLine("1. Ver menú de combos");
                Console.WriteLine("2. Registrar reserva");
                Console.WriteLine("3. Cancelar reserva");
                Console.WriteLine("4. Mostrar reservas por turno");
                Console.WriteLine("5. Reporte de ingresos");
                Console.WriteLine("6. Buscar reserva por nombre");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");
                int.TryParse(Console.ReadLine(), out opcion);
                switch (opcion)
                {
                    case 1: MostrarMenu(); break;
                    case 2: RegistrarReserva(); break;
                    case 3: CancelarReserva(); break;
                    case 7: Console.WriteLine("Saliendo..."); break;
                    case 4: MostrarReservas(); break;
                    case 5: ReporteIngresos(); break;
                    case 6: BuscarPorNombre(); break;
                    default: Console.WriteLine("Opción inválida."); break;
                }
                Console.WriteLine("Presione ENTER para continuar...");
                Console.ReadLine();

            } while (opcion != 7);
        }
        static void InicializarMatrices()
        {
            for (int t = 0; t < 2; t++)
            {
                for (int i = 0; i < 20; i++)
                {
                    nombres[t, i] = "";
                    combos[t, i] = -1;
                }
            }
        }
        static void MostrarMenu()
        {
            Console.WriteLine("\n--- MENÚ DE COMBOS ---");
            for (int i = 0; i < nombreCombos.Length; i++)
                Console.WriteLine($"{i + 1}. {nombreCombos[i]} - S/ {precioCombos[i]}");
        }
        static int PedirTurno()
        {
            Console.WriteLine("\nSeleccione turno:");
            Console.WriteLine("1. Mañana");
            Console.WriteLine("2. Tarde");
            Console.Write("Opción: ");
            int turno;
            int.TryParse(Console.ReadLine(), out turno);
            return turno - 1;
        }

        static int BuscarEspacio(int turno)
        {
            for (int i = 0; i < 20; i++)
                if (combos[turno, i] == -1)
                    return i;

            return -1;
        }

        static void RegistrarReserva()
        {
            int turno = PedirTurno();
            if (turno < 0 || turno > 1)
            {
                Console.WriteLine("Turno inválido.");
                return;
            }

            int pos = BuscarEspacio(turno);
            if (pos == -1)
            {
                Console.WriteLine("Turno lleno.");
                return;
            }

            Console.Write("Nombre del estudiante: ");
            string nombre = Console.ReadLine();

            MostrarMenu();
            Console.Write("Seleccione combo: ");
            int combo;
            int.TryParse(Console.ReadLine(), out combo);
            combo--;

            if (combo < 0 || combo >= nombreCombos.Length)
            {
                Console.WriteLine("Combo inválido.");
                return;
            }

            nombres[turno, pos] = nombre;
            combos[turno, pos] = combo;

            Console.WriteLine("Reserva registrada.");
        }
        static void CancelarReserva()
        {
            int turno = PedirTurno();
            Console.Write("Ingrese nombre a cancelar: ");
            string nombre = Console.ReadLine();

            for (int i = 0; i < 20; i++)
            {
                if (nombres[turno, i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    nombres[turno, i] = "";
                    combos[turno, i] = -1;
                    Console.WriteLine("Reserva cancelada.");
                    return;
                }
            }

            Console.WriteLine("No se encontró la reserva.");
        }
        static void MostrarReservas()
        {
            for (int t = 0; t < 2; t++)
            {
                Console.WriteLine($"\n--- Turno {(t == 0 ? "Mañana" : "Tarde")} ---");

                bool hay = false;

                for (int i = 0; i < 20; i++)
                {
                    if (combos[t, i] != -1)
                    {
                        hay = true;
                        Console.WriteLine($"{nombres[t, i]} - {nombreCombos[combos[t, i]]}");
                    }
                }

                if (!hay)
                    Console.WriteLine("No hay reservas en este turno.");
            }
        }
        static double CalcularIngresoTurno(int turno)
        {
            double total = 0;

            for (int i = 0; i < 20; i++)
            {
                if (combos[turno, i] != -1)
                {
                    total += precioCombos[combos[turno, i]];
                }
            }
            return total;
        }

        static void ReporteIngresos()
        {
            double mañana = CalcularIngresoTurno(0);
            double tarde = CalcularIngresoTurno(1);

            Console.WriteLine("\n--- REPORTE DE INGRESOS ---");
            Console.WriteLine($"Mañana: S/ {mañana}");
            Console.WriteLine($"Tarde: S/ {tarde}");
            Console.WriteLine($"TOTAL: S/ {mañana + tarde}");
        }    
        static void BuscarPorNombre()
        {
            Console.Write("Ingrese nombre a buscar: ");
            string nombre = Console.ReadLine();
            bool encontrado = false;


            for (int t = 0; t < 2; t++)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (nombres[t, i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Encontrado en turno {(t == 0 ? "Mañana" : "Tarde")}");
                        Console.WriteLine($"Combo: {nombreCombos[combos[t, i]]}");
                        encontrado = true;
                    }
                }
            }
             if (!encontrado)
                Console.WriteLine("No se encontró ninguna reserva con ese nombre.");  
              
        }
    }
   
}
    

