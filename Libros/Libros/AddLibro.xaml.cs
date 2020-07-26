using Libros.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Libros
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLibro : ContentPage
    {
        private LibroManager manager;
        private Libro libro;

        public AddLibro(LibroManager manager, Libro libro= null)
        {
            InitializeComponent();

            this.libro= libro;
            this.manager = manager;
        }

        async public void OnSaveTarea(object sender, EventArgs e)
        {
            if (txtTitulo.Text.Length > 0 && txtDescripcion.Text.Length > 0 && txtAutor.Text.Length > 0 && txtGenero.Text.Length > 0)
            {
                await manager.Add(txtTitulo.Text, txtDescripcion.Text, txtAutor.Text, txtGenero.Text);
            }
        }




    }


    public class MultiTriggerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
       object parameter, CultureInfo culture)
        {
            if ((int)value > 0) // length > 0 ?
                return true;            // some data has been entered
            else
                return false;            // input is empty
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}