using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Taller 1
 * Nombre: Marco Reyes Torres
 * */

namespace Taller1
{
    class Program
    {
        public static string RUTA_RESULTADO = "c:\\paso\\taller1\\resumen.txt";
        static void Main(string[] args)
        {
            Ventas V = new Ventas();
            char op;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(5, 5);
                Console.Write("[1]  Cargar ventas");
                Console.SetCursorPosition(5, 6);
                Console.Write("[2]  Imprimir Resumen");
                Console.SetCursorPosition(5, 7);
                Console.Write("[3]  Guardar Resumen");
                Console.SetCursorPosition(5, 8);
                Console.Write("[0]  Salir");
                Console.SetCursorPosition(5, 9);
                Console.Write("Ingrese Opcion       [ ]");
                do
                {
                    Console.SetCursorPosition(27, 9);
                    op = Console.ReadKey().KeyChar;
                } while (op != '1' && op != '2' && op != '3' && op != '0');
                switch (op)
                {
                    case '1':
                        V.CargarVentas();
                        break;
                    case '2':
                        V.ImprimirResumen();
                        break;
                    case '3':
                        V.GuardarVentasEnArchivo(RUTA_RESULTADO, "El resumen ha sido guardado");
                        break;
                    case '0':
                        Console.Clear();
                        Console.WriteLine("FIN");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            } while (op != '0');
        }
    }
}
