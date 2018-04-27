using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Taller1
{
    class Ventas
    {
        public string DIRECTORIO = "c:\\paso\\taller1\\";
        int[,] VentasSucursales;
        string[] archivos = { "2013.txt", "2014.txt", "2015.txt", "2016.txt", "2017.txt" };
        double[] promedios;
        string[] nombreSucursal = null, lineas = null;

        public void CargarVentas()
        {
            StreamReader Lectura;
            string datos;
            string[] ventasSucursal;
            int i = 0;
            Console.Clear();
            for (int k = 0; k < archivos.Length; k++)
            {
                if (File.Exists(DIRECTORIO + archivos[k]))
                {
                    Lectura = new StreamReader(DIRECTORIO + archivos[k]);
                    datos = Lectura.ReadToEnd();
                    Lectura.Close();
                    lineas = datos.Split('\n');
                    if (VentasSucursales == null)
                    {
                        VentasSucursales = new int[lineas.Length - 1, 12];
                        nombreSucursal = new string[lineas.Length - 1];
                    }
                    foreach (string linea in lineas)
                    {
                        ventasSucursal = linea.Split(';');
                        if (ventasSucursal.Length == 13)
                        {
                            nombreSucursal[i] = ventasSucursal[0];
                            VentasSucursales[i, 0] += int.Parse(ventasSucursal[1]);
                            VentasSucursales[i, 1] += int.Parse(ventasSucursal[2]);
                            VentasSucursales[i, 2] += int.Parse(ventasSucursal[3]);
                            VentasSucursales[i, 3] += int.Parse(ventasSucursal[4]);
                            VentasSucursales[i, 4] += int.Parse(ventasSucursal[5]);
                            VentasSucursales[i, 5] += int.Parse(ventasSucursal[6]);
                            VentasSucursales[i, 6] += int.Parse(ventasSucursal[7]);
                            VentasSucursales[i, 7] += int.Parse(ventasSucursal[8]);
                            VentasSucursales[i, 8] += int.Parse(ventasSucursal[9]);
                            VentasSucursales[i, 9] += int.Parse(ventasSucursal[10]);
                            VentasSucursales[i, 10] += int.Parse(ventasSucursal[11]);
                            VentasSucursales[i, 11] += int.Parse(ventasSucursal[12]);
                            i++;
                        }
                    }
                    i = 0;
                }
                else
                {
                    Console.WriteLine("Archivo " + archivos[k] + " no encontrado");
                }
            }

            CalcularPromedios();



            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        public void CalcularPromedios()
        {
            int acumulador = 0;
            promedios = new double[lineas.Length - 1];
            for (int j = 0; j < promedios.Length; j++)
            {
                for (int p = 0; p < 12; p++)
                {
                    acumulador += VentasSucursales[j, p];
                }
                promedios[j] = acumulador / 12;
                acumulador = 0;
            }
        }

        public void ImprimirResumen()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Las ventas de las sucursales son:");
                Console.Write("Nombre\t\tEnero\tFeb.\tMarzo\tAbril\tMayo\tJunio\tJulio\tAgosto\tSept.\tOct.\tNov.\tDic.\t\tPromedio\n");
                for (int i = 0; i < VentasSucursales.Length; i++)
                {
                    Console.Write(nombreSucursal[i] + ":\t");
                    Console.Write(VentasSucursales[i, 0] + "\t");
                    Console.Write(VentasSucursales[i, 1] + "\t");
                    Console.Write(VentasSucursales[i, 2] + "\t");
                    Console.Write(VentasSucursales[i, 3] + "\t");
                    Console.Write(VentasSucursales[i, 4] + "\t");
                    Console.Write(VentasSucursales[i, 5] + "\t");
                    Console.Write(VentasSucursales[i, 6] + "\t");
                    Console.Write(VentasSucursales[i, 7] + "\t");
                    Console.Write(VentasSucursales[i, 8] + "\t");
                    Console.Write(VentasSucursales[i, 9] + "\t");
                    Console.Write(VentasSucursales[i, 10] + "\t");
                    Console.Write(VentasSucursales[i, 11] + "\t\t");
                    Console.WriteLine(promedios[i]);
                    /*if ((i + 1) % 20 == 0)
                    {
                        Console.WriteLine("Presione una tecla para mostrar más...");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("Las notas de la asignatura son:");
                    }*/
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Primero carge las ventas");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Presione una tecla para volver al menu...");
            Console.ReadKey();
        }

        public void GuardarVentasEnArchivo(string ruta, string mensaje)
        {
            string[,] resultado;
            StreamWriter Escritura;
            Console.Clear();
            try
            {
                resultado = new string[lineas.Length, 14];
                Escritura = new StreamWriter(ruta);
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    for (int j = 0; j < 14; j++)
                    {
                        if (j==0)
                        {
                            resultado[i, j] = nombreSucursal[i];
                            //Console.Write("j=0 ");
                        }
                        else if (j==13)
                        {
                            resultado[i, j] = promedios[i] + "";
                            //Console.Write("j=13 ");
                        }
                        else
                        {
                            resultado[i, j] = VentasSucursales[i, j-1] + "";
                            //Console.Write("j=" + j);
                        }
                    }

                    //Console.Write("reinicio " + i + "\r\n ");
                }
                
                for (int p = 0; p < resultado.GetLength(0) - 1; p++)
                {
                    for (int q = 0; q < resultado.GetLength(1); q++)
                    {
                        if (q == resultado.GetLength(1) - 1)
                        {
                            Escritura.Write(resultado[p, q]);
                        }
                        else
                        {
                            Escritura.Write(resultado[p, q] + ";");
                        }
                    }
                    Escritura.Write("\r\n");
                }
                Escritura.Close();
                Console.WriteLine(mensaje);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No fue posible crear el archivo, " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}
