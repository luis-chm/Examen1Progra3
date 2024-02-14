using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Examen1___Progra3
{
    internal class Biblioteca
    {
        private static List<ClassLibro> libros = new List<ClassLibro>();

        public static void agregarLibro()
        {
            Console.Write("Ingrese el código del libro: ");
            string codigo = Console.ReadLine();
            Console.Write("Ingrese el título del libro: ");
            string titulo = Console.ReadLine();
            Console.Write("Ingrese el autor del libro: ");
            string autor = Console.ReadLine();
            Console.Write("Ingrese la fecha de publicación del libro (YYYY-MM-DD): ");
            DateTime fechaPublicacion = DateTime.Parse(Console.ReadLine());
            Console.Write("Ingrese el precio del libro: ");
            float precio = float.Parse(Console.ReadLine());

            ClassLibro nuevoLibro = new ClassLibro(codigo, titulo, autor, fechaPublicacion, precio);
            libros.Add(nuevoLibro);
            Console.WriteLine("Libro agregado a la biblioteca.");
        }
        public static void eliminarLibro()
        {
            Console.Write("Ingrese el código del libro a eliminar: ");
            string codigoEliminar = Console.ReadLine();

            ClassLibro libroAEliminar = libros.FirstOrDefault(libro => libro.codigo == codigoEliminar);
            if (libroAEliminar != null)
            {
                libros.Remove(libroAEliminar);
                Console.WriteLine("Libro eliminado de la biblioteca.");
            }
            else
            {
                Console.WriteLine("El libro no está en la biblioteca.");
            }
        }//fin metodo eliminar libro
        #region BUSCAR LIBROS
        public static void buscarLibro()
        {
            Console.Write("Ingrese el código del libro a buscar: ");
            string codigoBuscar = Console.ReadLine();

            bool libroEncontrado = false;
            foreach (var libro in libros)
            {
                if (libro.codigo == codigoBuscar)
                {
                    Console.WriteLine("Libro encontrado:");
                    Console.WriteLine($"- Código: {libro.codigo}");
                    Console.WriteLine($"- Título: {libro.titulo}");
                    Console.WriteLine($"- Autor: {libro.autor}");
                    Console.WriteLine($"- Fecha de publicación: {libro.fecha.ToString("yyyy-MM-dd")}");
                    Console.WriteLine($"- Precio: {libro.precio}");
                    libroEncontrado = true;
                    break;
                }
            }
            if (!libroEncontrado)
            {
                Console.WriteLine("No se encontró ningún libro con ese código.");
            }
        }//fin metodo buscar por codigo 
        public static void mostrarLibros()
        {
            Console.WriteLine("Libros en la biblioteca:");

            if (libros.Count == 0)
            {
                Console.WriteLine("La biblioteca está vacia. Agregue libros.");
            }
            else
            {
                foreach (var libro in libros)
                {
                    Console.WriteLine($"Codigo: {libro.codigo} ");
                    Console.WriteLine($"- {libro.titulo} de {libro.autor}");
                }
            }
        }//fin metodo mostrar todos los libros
        public static void mostrarMaxPrecio()
        {
            if (libros.Count == 0)
            {
                Console.WriteLine("La biblioteca está vacia. Agregue libros.");
            }
            else
            {
                //Inicializar el libro de mayor precio con el primer libro de la lista
                ClassLibro libroMaxPrecio = libros[0];

                // Iterar sobre los libros restantes para encontrar el libro con el precio más alto
                foreach (var libro in libros)
                {
                    if (libro.precio > libroMaxPrecio.precio)
                    {
                        libroMaxPrecio = libro;
                    }
                }
                Console.WriteLine("Libro con el precio mas alto:");
                Console.WriteLine($"- Código: {libroMaxPrecio.codigo}, Título: {libroMaxPrecio.titulo}, Autor: {libroMaxPrecio.autor}, Precio: {libroMaxPrecio.precio}");
            }
        }//fin mostrar por max precio
        public static void mostrarBaratos()
        {
            if (libros.Count == 0)
            {
                Console.WriteLine("La biblioteca está vacía.");
            }
            else
            {
                //Ordena precios de libros en forma ascendente
                //REFERENCIA DE BUSQUEDA: https://stackoverflow.com/questions/3925258/c-sharp-list-orderby-descending
                List<ClassLibro> librosOrdenadosAscen = libros.OrderBy(libro => libro.precio).ToList();

                //Take(3) toma los primeros tres elementos de la lista reconfigurada en rango menor a mayor
                Console.WriteLine("Los tres libros más baratos:");
                foreach (var libro in librosOrdenadosAscen.Take(3))
                {
                    Console.WriteLine($"- Código: {libro.codigo}");
                    Console.WriteLine($"Título: {libro.titulo}");
                    Console.WriteLine($" Autor: {libro.autor}");
                    Console.WriteLine($"Precio: {libro.precio}");
                }
            }
        }//fin mostrar 3 mas baratos
        public static void BuscarPorInicioAutor()
        {
            Console.Write("Ingrese las iniciales del autor a buscar: ");
            string inicioAutor = Console.ReadLine();

            bool librosEncontrados = false;

            foreach (var libro in libros)
            {
                if (libro.autor.StartsWith(inicioAutor, StringComparison.OrdinalIgnoreCase))
                {
                    if (!librosEncontrados)
                    {
                        Console.WriteLine($"Libros cuyo autor comienza con '{inicioAutor}':");
                        librosEncontrados = true;
                    }
                    Console.WriteLine($"- Código: {libro.codigo}");
                    Console.WriteLine($"Título: {libro.titulo}");
                    Console.WriteLine($" Autor: {libro.autor}");
                    Console.WriteLine($"Precio: {libro.precio}");
                }
            }

            if (!librosEncontrados)
            {
                Console.WriteLine("No se encontraron libros con ese inicio de autor.");
            }
        }
        #endregion

        static public void Menu()
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("\t    Examen 1 \t\n");
                Console.WriteLine("-------------Menu Principal-------------");
                Console.WriteLine("Opcion 1:  Agregar un libro a la biblioteca");
                Console.WriteLine("Opcion 2:  Eliminar un libro de la biblioteca");
                Console.WriteLine("Opcion 3:  Mostrar todos los libros de la biblioteca.");
                Console.WriteLine("Opcion 4:  Mostrar libro de mayor precio.");
                Console.WriteLine("Opcion 5:  Mostrar los tres libros más baratos.");
                Console.WriteLine("Opcion 6:  Buscar libros por inicio del nombre del autor");
                Console.WriteLine("Opcion 7:  Buscar libros por numero de codigo");
                Console.WriteLine("Opcion 8:  Salir");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Seleccione su opcion: ");
                int.TryParse(Console.ReadLine(), out opcion);// si ingresa una letra no va a dejar continuar
                switch (opcion)
                {
                    case 1: agregarLibro();
                        break;
                    case 2: eliminarLibro();
                        break;
                    case 3:
                        mostrarLibros();
                        break;
                    case 4:
                        mostrarMaxPrecio();
                        break;
                    case 5:
                        mostrarBaratos();
                        break;
                    case 6:
                        BuscarPorInicioAutor();
                        break;
                    case 7:
                        buscarLibro();
                        break;
                    case 8:
                        Console.WriteLine("¡Hasta pronto! Gracias");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("+------------------------------------------+\r\n| ¡Opcion no valida! Elige una entre 1 y 8 |\r\n+------------------------------------------+");
                        break;
                }// fin switch
            } while (opcion != 9);
        }// fin metodo menu*/


    }//fin clase
}//fin namespace
