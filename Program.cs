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
    }    
}
