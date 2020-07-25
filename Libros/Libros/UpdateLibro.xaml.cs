using Libros.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Libros
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateLibro : ContentPage
    {
        private LibroManager manager;
        private Libro libro;

        public UpdateLibro(LibroManager manager, Libro libro = null)
        {
            InitializeComponent();

            this.libro = libro;
            this.manager = manager;

            PopulateDetails(this.libro);
        }


        private void PopulateDetails(Libro libro)
        {
            txtTitulo.Text = libro.Titulo;
            txtDescripcion.Text = libro.Descripcion;
            txtAutor.Text = libro.Autor;
            txtGenero.Text = libro.Genero; 
        }

        async public void OnUpdateLibro(object sender, EventArgs e)
        {
            if (txtTitulo.Text.Length > 0 && txtDescripcion.Text.Length > 0 && txtAutor.Text.Length > 0 && txtGenero.Text.Length > 0)
            {
                await manager.Update(this.libro.Id ,txtTitulo.Text, txtDescripcion.Text, txtAutor.Text, txtGenero.Text);
            }
        }
    }
}