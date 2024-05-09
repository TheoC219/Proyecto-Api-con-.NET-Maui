
using MuaiApp.Models;

namespace MuaiApp.Pages;


public partial class CategoriaPage : ContentPage
{
    private string urlApiClasificacion = "https://cloudcomputingapi2.azurewebsites.net/api/Clasificaciones";

    public CategoriaPage()
    {
        InitializeComponent();
    }

    private void btnCreateCategory_Clicked(object sender, EventArgs e)
    {
        try
        {
            var resultado = ApiConsumer.Crud<Clasificacion>.Create(urlApiClasificacion, new Clasificacion
            {
                Id = 0,
                Descripcion = txtClasificacion.Text
            });

            if (resultado != null)
            {
                txtId.Text = resultado.Id.ToString();
                DisplayAlert("Mensaje", "Registro creado:"+txtId.Text+" - "+txtClasificacion.Text, "OK");
            }
            else
            {
                DisplayAlert("Mensaje", "Error al crear", "OK");
            }
        }
        catch
        {
            DisplayAlert("Mensaje", "Error al crear", "OK");
        }

    }

    private void btnReadCategory_Clicked(object sender, EventArgs e)
    {
        try
        {
            var resultado = ApiConsumer.Crud<Clasificacion>.Read_ById(urlApiClasificacion, int.Parse(txtId.Text));
            if (resultado != null)

                txtClasificacion.Text = resultado.Descripcion;

            else

                DisplayAlert("Mensaje", "Registro no encontrado", "OK");

        }
        catch
        {
            DisplayAlert("Mensaje", "Error al buscar", "OK");
        }
    }

    private void btnUpdateCategory_Clicked(object sender, EventArgs e)
    {
        try
        {
            ApiConsumer.Crud<Clasificacion>.Update(urlApiClasificacion, int.Parse(txtId.Text), new Clasificacion
            {
                Id = int.Parse(txtId.Text),
                Descripcion = txtClasificacion.Text
            });
            DisplayAlert("Mensaje", "Registro actualizado", "OK");
        }
        catch
        {
            DisplayAlert("Mensaje", "Error al actualizar", "OK");
        }

    }


    private void btnDeleteCategory_Clicked(object sender, EventArgs e)
    {
        try
        {
            ApiConsumer.Crud<Clasificacion>.Delete(urlApiClasificacion, int.Parse(txtId.Text));
            txtClasificacion.Text = "";
            txtId.Text = "";
            DisplayAlert("Mensaje", "Registro eliminado", "OK");
        }
        catch
        {
            DisplayAlert("Mensaje", "Error al eliminar", "OK");
        }

    }

}