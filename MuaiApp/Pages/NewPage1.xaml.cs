using ApiConsumer;
using MuaiApp.Models;
using MuaiApp.Pages;

namespace MuaiApp;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}
    private string ApiUrl = "https://663833064253a866a24d0414.mockapi.io/Login";

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        try
        {
            // Realiza la llamada a la API para obtener los datos de login
            var resultado = ApiConsumer.Crud<Login>.Read(ApiUrl);

            if (resultado != null)
            {
                foreach (var item in resultado)
                {
                    // Compara el nombre de usuario y la contraseña ingresados con los datos obtenidos de la API
                    if (item.Usuario == UsernameEntry.Text && item.Contrasenia == PasswordEntry.Text)
                    {
                        // Si las credenciales son válidas, redirige a la siguiente página
                        await Navigation.PushAsync(new HomePage());
                        return; // Sale del método después de la redirección
                    }
                }
            }

            // Si las credenciales no coinciden con ninguna entrada de la API, muestra un mensaje de error
            await DisplayAlert("Error", "Credenciales inválidas", "OK");
        }
        catch (Exception ex)
        {
            // Maneja cualquier excepción que pueda ocurrir durante la llamada a la API
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
    }
}

