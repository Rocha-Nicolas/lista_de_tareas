using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lista_de_tareas
{
    internal class Tarea
    {
        private string Descripcion { get; set; }
        private bool Completada { get; set; }

        public Tarea(string descripcion)
        {
            Descripcion = descripcion;
            Completada = false;
        }

        public void MarcaCompletado()
        {
            Completada = true; 
        }

        public override string ToString()
        {
            string estado = Completada ? "Completada" : "Penditne";
            return $"{Descripcion} - {estado}";
        }

    }

    internal class Program
    {
        static List<Tarea> listaTarea = new List<Tarea>();

        static void Main(string[] args)
        {
            bool salir = false;
            string numero = null;

            while (!salir)
            {
                Console.WriteLine("----Menu de Tareas----");
                Console.WriteLine("1. Agregar tarea");
                Console.WriteLine("2. Marcar tarea como completada");
                Console.WriteLine("3. Mostrar lista de tareas");
                Console.WriteLine("4. Salir");
                Console.WriteLine("5. Seleccione una opción:");
                do{
                    numero = Console.ReadLine();
                    if (!validarNumero(numero))
                    {
                        Console.WriteLine("Error!, solo se admiten numeros");
                    }
                }while (!validarNumero(numero));

                int opcion = Convert.ToInt32(numero);

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese la descripción de la tarea: ");
                        string descripcion = Console.ReadLine();
                        agregarTarea(descripcion);
                        break;

                    case 2:
                        Console.WriteLine("Ingrese le Numero de la Tarea");
                        do{
                            numero = Console.ReadLine();
                            if (!validarNumero(numero))
                            {
                                Console.WriteLine("Error!, solo se admiten numeros");
                            }
                        }while (!validarNumero(numero));

                        int indice = Convert.ToInt32(numero);

                        marcarTareaComoCompletada(indice);
                        
                        break;

                    case 3:
                        mostarLista();
                        break;

                    case 4:
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no valida, Intente de nuevo ");
                        Console.WriteLine("");
                        break;
                }
            }



        }
        static bool validarNumero(string numero)
        {
            int resultado;
            return int.TryParse(numero, out resultado);

        }

        static void agregarTarea(string descripcion)
        {
            Tarea nuevaTarea = new Tarea(descripcion);
            listaTarea.Add(nuevaTarea);
            Console.WriteLine("Tarea agregada.");
            Console.WriteLine("");
        }

        static void marcarTareaComoCompletada(int indice)
        {
            if (indice >= 0 && indice < listaTarea.Count)
            {
                listaTarea[indice].MarcaCompletado();
                Console.WriteLine("Tarea marcada como completada.");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Numero de tarea invalido, intente de nuevo.");
                Console.WriteLine("");
            }
        }

        static void mostarLista()
        {
            Console.WriteLine("==== Lista de Tareas ====");
            for (int i = 0; i < listaTarea.Count; i++)
            {
                Console.WriteLine($"Numero: {i} -> {listaTarea[i]}");
            }
            Console.WriteLine("");
        }

    }

}
