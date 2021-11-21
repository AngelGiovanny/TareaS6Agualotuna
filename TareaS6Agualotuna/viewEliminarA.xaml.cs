using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaS6Agualotuna
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewEliminarA : ContentPage
    {
        public viewEliminarA(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();

            //Llenar los campos con los valores actuales
            txtCodigo.Text = codigo.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad.ToString();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();

                //Eliminar por ID
                var response = client.DeleteAsync(String.Format("http://192.168.1.5/moviles/post.php?codigo={0}", txtCodigo.Text)).Result;

                if (response.IsSuccessStatusCode)
                {
                    var resultString = response.Content.ReadAsStringAsync().Result;

                    // Utilizar TOAST
                    var mensaje = "Eliminado correctamente";
                    DependencyService.Get<MensajeA>().longAlert(mensaje);

                    // Poner en blanco los campos
                    txtCodigo.Text = "";
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtEdad.Text = "";
                }
                else
                {
                    await DisplayAlert("Mensaje de alerta", "Error al eliminar", "OK");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Mensaje de alerta", ex.Message, "OK");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            //Regresar a la pantalla principal MainPage
            await Navigation.PushAsync(new MainPage());
        }
    }
}