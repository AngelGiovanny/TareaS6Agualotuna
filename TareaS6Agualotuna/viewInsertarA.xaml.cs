using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

namespace TareaS6Agualotuna
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewInsertarA : ContentPage
    {
        public viewInsertarA()
        {
            InitializeComponent();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                cliente.UploadValues("http://192.168.1.5/moviles/post.php", "POST", parametros);

                DisplayAlert("Mensaje", "Ingreso correcto", "OK");

            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje de alerta", ex.Message, "OK");
            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}