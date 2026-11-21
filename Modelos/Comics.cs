using System.Linq;

namespace BibliotecaHistorieta.Models;

public class Comics
{
    private int? _id;
    private string? _nombre;
    private string? _autor;
    private string? _anio;
    
    public Comics(int? id = null, string? nombre = null, string? autor = null, string? anio = null)
    {
        _id = id;
        _nombre = nombre;
        _autor = autor;
        _anio = anio;
    }

    public int? Id
    {
        get => _id;
        set => _id = value;
    }

    public string? Nombre
    {
        get => _nombre;
        set => _nombre = value;
    }

    public string? Autor
    {
        get => _autor;
        set => _autor = value;
    }

    public string? Anio
    {
        get => _anio;
        set => _anio = value;
    }

    public bool ValidarId()
{
    return _id.HasValue && _id.Value > 0;
}

// Si tu Id fuera string? y no quieres que tenga dígitos:
// public bool ValidarId(string? idTexto) => !string.IsNullOrWhiteSpace(idTexto) && !idTexto.Any(char.IsDigit);

// 2. Nombre: no puede ser null ni vacío
public bool ValidarNombre()
{
    return !string.IsNullOrWhiteSpace(_nombre);
}

// 3. Autor: no puede ser null ni vacío
public bool ValidarAutor()
{
    return !string.IsNullOrWhiteSpace(_autor);
}

// 4. Anio (sobre objeto): valida que _anio tenga valor y sea mayor a 0

public int ValidarAnio(string? textoAnio)
{
    if (string.IsNullOrWhiteSpace(textoAnio))
        return 0;

    string limpio = textoAnio.Trim();

    // Si tiene letras o algo que no sea dígito, devolvemos 0
    if (!limpio.All(char.IsDigit))
        return 0;

    // Convierte a int de forma segura
    int.TryParse(limpio, out int anioConvertido);

    // El if trabaja ya con el valor int convertido
    if (anioConvertido <= 0)
        return 0;
    return anioConvertido;
}

// 5. Anio (desde string): revisa que no tenga letras y lo convierte a int sin explotar
    
}