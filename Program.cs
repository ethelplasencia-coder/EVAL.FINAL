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
                if (opcion == 1)
                    MostrarMenu();
                else if (opcion == 2)
                    RegistrarReserva();
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
    }
}
