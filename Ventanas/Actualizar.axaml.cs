using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using BibliotecaHistorieta.Services; // ajusta al namespace de tu Service si aplica

namespace BibliotecaHistorieta;

public partial class Actualizar : Window
{
    private readonly ComicsService serv = new();

    public Actualizar()
    {
        InitializeComponent();
    }

    private void OnActualizarClick(object? sender, RoutedEventArgs e)
    {
        string respuesta = serv.ActualizarNombre(TxtId.Text, TxtNombre.Text);

        if (string.IsNullOrEmpty(respuesta))
        {
            LblMensaje.Text = "Nombre actualizado correctamente.";
            LblMensaje.Foreground = Brushes.Green;
            TxtId.Text = string.Empty;
            TxtNombre.Text = string.Empty;
            TxtId.Focus();
        }
        else
        {
            LblMensaje.Text = respuesta;
            LblMensaje.Foreground = Brushes.Red;
        }
    }
}