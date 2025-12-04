using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFETERÌA
{
    internal class Program
    {
        static void Main()
        {
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

                Console.WriteLine("\n(Opciones aún no implementadas)");
                Console.WriteLine("Presione ENTER para continuar...");
                Console.ReadLine();

            } while (opcion != 7);
        }
    }
}
