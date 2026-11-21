using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using BibliotecaHistorieta.Services; // ajusta al namespace de tu Service si aplica

namespace BibliotecaHistorieta;

public partial class Eliminar : Window
{
    private readonly ComicsService serv = new();

    public Eliminar()
    {
        InitializeComponent();
    }

    private void OnEliminarClick(object? sender, RoutedEventArgs e)
    {
        string respuesta = serv.EliminarPorId(TxtId.Text);

        if (string.IsNullOrEmpty(respuesta))
        {
            LblMensaje.Text = "Cómic eliminado correctamente.";
            LblMensaje.Foreground = Brushes.Green;
            TxtId.Text = string.Empty;
            TxtId.Focus();
        }
        else
        {
            LblMensaje.Text = respuesta;
            LblMensaje.Foreground = Brushes.Red;
        }
    }
}