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
    public partial class DetailsLibro : ContentPage
    {
        private Libro libro;
        public DetailsLibro(Libro libro = null)
        {
            InitializeComponent();

            this.libro = libro;
            libroTituloLabel.Text = this.libro.Titulo;
            libroDescripcionLabel.Text = this.libro.Descripcion;
            libroAutorLabel.Text = this.libro.Autor;
            libroGeneroLabel.Text = this.libro.Genero;
        }

        private async void OnBackHome(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}