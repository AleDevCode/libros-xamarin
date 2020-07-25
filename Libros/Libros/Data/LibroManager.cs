using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Data
{
    public class LibroManager
    {
        // OJO: Importante actualizar la dirección IP por la tuya, igualmente el puerto en caso de que lo cambies
        // Igualemente agregar tu IP en Android/Resources/xml/network_security_config.xml
        const string url = "http://192.168.0.10:3000/libros/";

        public async Task<IEnumerable<Libro>> GetAll()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Libro>>(result);
        }

        public async Task<Libro> Add(string titulo, string descripcion, string autor, string genero)
        {
            Libro libro= new Libro()
            {
                Titulo = titulo,
                Descripcion = descripcion,
                Autor = autor,
                Genero = genero
            };

            HttpClient client = new HttpClient();
            var response = await client.PostAsync(url,
                new StringContent(
                    JsonConvert.SerializeObject(libro),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Libro>(
                await response.Content.ReadAsStringAsync());

        }


        public async Task<Libro> Update(long id, string titulo, string descripcion, string autor, string genero)
        {
            Libro libro = new Libro()
            {
                Titulo = titulo,
                Descripcion = descripcion,
                Autor = autor,
                Genero = genero
            };

            HttpClient client = new HttpClient();
            var response = await client.PutAsync($"{url}/{id}",
                new StringContent(
                    JsonConvert.SerializeObject(libro),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Libro>(
                await response.Content.ReadAsStringAsync());

        }

        public async Task<int> Delete(long Id)
        {
            HttpClient client = new HttpClient();

            var response = await client.DeleteAsync($"{url}/{Id}");

            return JsonConvert.DeserializeObject<int>(
                await response.Content.ReadAsStringAsync());
        }
    }
}
