using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using BibliotecaHistorieta.Services; // pon aquí el namespace real de ComicsService si es distinto

namespace BibliotecaHistorieta;

public partial class Listar : Window
{
    private ComicsService serv;

    public Listar()
    {
        InitializeComponent();
        serv = new ComicsService();
        Loaded += OnLoaded;
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        try
        {
            var comics = serv.Listar();
            ListaComics.ItemsSource = comics;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al listar: {ex.Message}");
        }
    }
}