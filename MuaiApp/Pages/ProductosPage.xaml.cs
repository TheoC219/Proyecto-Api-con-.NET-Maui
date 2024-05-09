using MuaiApp.Models;

namespace MuaiApp.Pages;

public partial class ProductosPage : ContentPage
{
    private string urlApiProducto = "https://cloudcomputingapi2.azurewebsites.net/api/Productos";

    public ProductosPage()
    {
        InitializeComponent();
    }

    private void btnCreateProduct_Clicked(object sender, EventArgs e)
    {
        try
        {
            var resultado = ApiConsumer.Crud<Producto>.Create(urlApiProducto, new Producto
            {

                Id = 0,
                Nombre = txtNombreProducto.Text,
                Existencia = double.Parse(txtExistencia.Text),
                PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
                IVA = double.Parse(txtIVA.Text),
                ClasificacionId = int.Parse(txtClasificacionId.Text)
            });

            if (resultado != null)
            {
                txtIdProducto.Text = resultado.Id.ToString();
                DisplayAlert("Mensaje", "Registro creado:" + txtIdProducto.Text + " - " + txtNombreProducto.Text, "OK");
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

    private void btnReadProduct_Clicked(object sender, EventArgs e)
    {
        try
        {
            var resultado = ApiConsumer.Crud<Producto>.Read_ById(urlApiProducto, int.Parse(txtIdProducto.Text));
            if (resultado != null)
            {
                txtNombreProducto.Text = resultado.Nombre;
                txtExistencia.Text = resultado.Existencia.ToString();
                txtPrecioUnitario.Text = resultado.PrecioUnitario.ToString();
                txtIVA.Text = resultado.IVA.ToString();
                txtClasificacionId.Text = resultado.ClasificacionId.ToString();
            }
            else

                DisplayAlert("Mensaje", "Registro no encontrado", "OK");

        }
        catch
        {
            DisplayAlert("Mensaje", "Error al buscar", "OK");
        }
    }

    private void btnUpdateProduct_Clicked(object sender, EventArgs e)
    {
        try
        {
            ApiConsumer.Crud<Producto>.Update(urlApiProducto, int.Parse(txtIdProducto.Text), new Producto
            {
                Id = int.Parse(txtIdProducto.Text),
                Nombre = txtNombreProducto.Text,
                Existencia = double.Parse(txtExistencia.Text),
                PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
                IVA = double.Parse(txtIVA.Text),
                ClasificacionId = int.Parse(txtClasificacionId.Text)

            }); 
            DisplayAlert("Mensaje", "Registro actualizado", "OK");
        }
        catch
        {
            DisplayAlert("Mensaje", "Error al actualizar", "OK");
        }

    }

    private void btnDeleteProduct_Clicked(object sender, EventArgs e)
    {
        try
        {
            ApiConsumer.Crud<Producto>.Delete(urlApiProducto, int.Parse(txtIdProducto.Text));
            txtIdProducto.Text = "";
            txtNombreProducto.Text = "";
            txtExistencia.Text = "";
            txtPrecioUnitario.Text = "";
            txtIVA.Text = "";
            txtClasificacionId.Text = "";


            DisplayAlert("Mensaje", "Registro eliminado", "OK");
        }
        catch
        {
            DisplayAlert("Mensaje", "Error al eliminar", "OK");
        }

    }

}