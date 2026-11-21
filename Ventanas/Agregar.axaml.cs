using Avalonia.Controls;
using Avalonia.Interactivity;
using BibliotecaHistorieta.Models;
using BibliotecaHistorieta.Services;
using Avalonia.Media;

namespace BibliotecaHistorieta;

public partial class Agregar : Window
{
    private ComicsService serv;
    public Agregar()
    {
        InitializeComponent();
        serv = new ComicsService();
    }
    private void OnLimpiarClick(object? sender, RoutedEventArgs e)
    {
        TxtNombre.Text = string.Empty;
        TxtAutor.Text = string.Empty;
        TxtAnio.Text = string.Empty;
        TxtNombre.Focus();
    }

    private void OnGuardarClick(object? sender, RoutedEventArgs e)
    {
        string nombre =TxtNombre.Text;
        string autor = TxtAutor.Text;
        string anio=TxtAnio.Text;
        Comics comic = new Comics(null, nombre, autor, anio);
        string respuesta = serv.Agregar(comic);
        if (string.IsNullOrEmpty(respuesta))
            {
                LblMensaje.Text = "Cómic registrado correctamente.";
                LblMensaje.Foreground = Brushes.Green;
                OnLimpiarClick();
            }
            else
            {
                LblMensaje.Text = respuesta;
                LblMensaje.Foreground = Brushes.Red;
            }
    }

    private void OnLimpiarClick()
    {
        TxtNombre.Text = string.Empty;
        TxtAutor.Text = string.Empty;
        TxtAnio.Text = string.Empty;
        TxtNombre.Focus();
    }
}