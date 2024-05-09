using MuaiApp.Pages;

namespace MuaiApp;

public partial class HomePage : ContentPage
{

	public HomePage()
	{
		InitializeComponent();
	}

    private void btnProdcutos_Clicked(object sender, EventArgs e)
    {
        lblText.Text = "Productos";

        Navigation.PushAsync(new ProductosPage());
    }

    private void btnClasificacion_Clicked(object sender, EventArgs e)
    {
        lblText.Text = "Clasificacion";

        Navigation.PushAsync(new CategoriaPage());

    }
}