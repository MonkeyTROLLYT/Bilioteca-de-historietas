using Avalonia.Controls;//Avalonia
using Avalonia.Interactivity;//controle, botone, etc.

namespace BibliotecaHistorieta;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void Agregar(object sender, RoutedEventArgs e)
    {

            var ventanaEmergente = new Agregar();

            // Mostramos la ventana emergente
            ventanaEmergente.Show(); 
        
    }

    private void Listar(object sender, RoutedEventArgs e)
    {

            var ventanaEmergente = new Listar();

            // Mostramos la ventana emergente
            ventanaEmergente.Show(); 
        
    }

    private void Actualizar(object sender, RoutedEventArgs e)
    {

            var ventanaEmergente = new Actualizar();

            // Mostramos la ventana emergente
            ventanaEmergente.Show(); 
        
    }

    private void Eliminar(object sender, RoutedEventArgs e)
    {

            var ventanaEmergente = new Eliminar();

            // Mostramos la ventana emergente
            ventanaEmergente.Show(); 
        
    }
}