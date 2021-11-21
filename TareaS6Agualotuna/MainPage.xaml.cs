using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace TareaS6Agualotuna
{
    public partial class MainPage : ContentPage
    {
        private const string Uri = "http://192.168.1.5/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<TareaS6Agualotuna.Ws.Datos> _post;

        public MainPage()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Uri);
                List<TareaS6Agualotuna.Ws.Datos> posts = JsonConvert.DeserializeObject<List<TareaS6Agualotuna.Ws.Datos>>(content);
                _post = new ObservableCollection<TareaS6Agualotuna.Ws.Datos>(posts);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje de alerta", ex.Message, "OK");
            }
        }

        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new viewInsertarA());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            var datos = MyListView.SelectedItem as TareaS6Agualotuna.Ws.Datos;

            await Navigation.PushAsync(new viewActualizaA(datos.codigo, datos.nombre, datos.apellido, datos.edad));
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var datos = MyListView.SelectedItem as TareaS6Agualotuna.Ws.Datos;

            await Navigation.PushAsync(new viewEliminarA(datos.codigo, datos.nombre, datos.apellido, datos.edad));
        }

        /*private async void btnGet_Clicked(object sender, EventArgs e)
        {
            try
            {
                var content = await client.GetStringAsync(Uri);
                List<TareaS6Agualotuna.Ws.Datos> posts = JsonConvert.DeserializeObject<List<TareaS6Agualotuna.Ws.Datos>>(content);
                _post = new ObservableCollection<TareaS6Agualotuna.Ws.Datos>(posts);

                MyListView.ItemsSource = _post;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje de alerta", ex.Message, "OK");
            }

            //await Navigation.PushAsync(new viewInsertarA());
        }*/
    }
}
