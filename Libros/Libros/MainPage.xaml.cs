using Libros.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Libros
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        private IList<Libro> libros = new ObservableCollection<Libro>();
        private LibroManager manager = new LibroManager();

        public MainPage()
        {
            BindingContext = libros; 

            InitializeComponent();
        }

        public void OnRefresh(object sender, EventArgs e)
        {
            GetData();
        }

        async public void OnAddTarea(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddLibro(manager));
        }

        async public void OnDeleteLibro(object sender, EventArgs e)
        {
            // The sender is the menuItem
            MenuItem menuItem = sender as MenuItem;

            var l = menuItem.CommandParameter as Libro;

            await manager.Delete(l.Id);
            libros.Remove(l);
            GetData();
        }

        async public void GetData()
        {
            var librosCollection = await manager.GetAll();
            foreach (Libro libro in librosCollection)
            {
                if (libros.All(l => l.Id != libro.Id))
                {
                    libros.Add(libro);
                }
            }
        }
    }
}
