using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1___Progra3
{
    internal class ClassLibro : ILibro
    {
        #region GET AND SET 
        public string codigo { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public DateTime fecha { get; set; }
        public float precio { get; set; }
        public bool dispo { get; set; }
        #endregion  
        //Constructores de los atributos
        #region CONSTRUCTORES
        public ClassLibro(string Codigo, string Titulo, string Autor, DateTime Fecha, float Precio, bool Dispo)
        {
            codigo = Codigo;
            titulo = Titulo;
            autor = Autor;
            fecha = Fecha;
            precio = Precio;
            dispo = Dispo;
        }
        public ClassLibro(string Codigo, string Titulo, string Autor, DateTime Fecha, float Precio)
        {
            codigo = Codigo;
            titulo = Titulo;
            autor = Autor;
            fecha = Fecha;
            precio = Precio;
        }
        public ClassLibro(string Codigo, string Titulo, string Autor, DateTime Fecha)
        {
            codigo = Codigo;
            titulo = Titulo;
            autor = Autor;
            fecha = Fecha;
        }
        public ClassLibro(string Codigo, string Titulo, string Autor)
        {
            codigo = Codigo;
            titulo = Titulo;
            autor = Autor;
        }
        public ClassLibro(string Codigo, string Titulo)
        {
            codigo = Codigo;
            titulo = Titulo;
        }
        public ClassLibro(string Codigo)
        {
            codigo = Codigo;
        }
        public ClassLibro()
        {
            //CONSTRUCTOR VACIO
        }
        #endregion
        #region METODOS INTERFAZ
        public void prestar()
        {
            
        }

        public void devolver()
        {
            
        }

        public void consultar()
        {
            
        }
        #endregion








    }//FIN CLASE
}//FIN NAMESPACE