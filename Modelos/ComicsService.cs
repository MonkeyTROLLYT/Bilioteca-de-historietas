using System;
using System.Collections.Generic;
using BibliotecaHistorieta.Data;
using BibliotecaHistorieta.Models;
using System.Linq;

namespace BibliotecaHistorieta.Services;

public class ComicsService
{
    ComicsDAO dao;
    public ComicsService()
    {
        dao = new ComicsDAO();
    }
    // 1. AGREGAR (no exige Id previo porque la BD lo autogenera)
    public string Agregar(Comics comic)
    {
        var errores = new List<string>();

        if (comic is null)
            return "El cómic no puede ser nulo.";

        if (!comic.ValidarNombre())
            errores.Add("El nombre es obligatorio.");

        if (!comic.ValidarAutor())
            errores.Add("El autor es obligatorio.");
            int anio =comic.ValidarAnio(comic.Anio);
        if (anio==0)
            errores.Add("El año es obligatorio y debe ser un número válido.");


        // Si hay errores de validación, los devolvemos juntos sin tocar la BD
        if (errores.Count > 0)
            return string.Join("\n", errores);
        dao.Agregar(comic, anio);
        return string.Empty;
    }

    // 2. LISTAR
    public List<Comics> Listar()
    {
        return dao.Listar();
    }

    // 3. ACTUALIZAR (exige Id válido además de Nombre, Autor y Anio)
    public string ActualizarNombre(string? textoId, string? nombre)
    {
        if (string.IsNullOrWhiteSpace(textoId))
            return "El ID es obligatorio.";

        string idLimpio = textoId.Trim();
        if (!idLimpio.All(char.IsDigit) || !int.TryParse(idLimpio, out int id) || id <= 0)
            return "El ID debe ser un número válido mayor a 0.";

        if (string.IsNullOrWhiteSpace(nombre))
            return "El nombre es obligatorio.";

        int filasAfectadas = dao.ActualizarNombre(id, nombre);

        if (filasAfectadas == 0)
            return $"No se encontró ningún cómic con el ID {id}.";

        return string.Empty;
    }

    // 4. ELIMINAR
    public string EliminarPorId(string? textoId)
    {
        if (string.IsNullOrWhiteSpace(textoId))
            return "El ID es obligatorio.";

        string idLimpio = textoId.Trim();
        foreach (char c in idLimpio)
        {
            if (!char.IsDigit(c))
                return "El ID debe contener solo números.";
        }

        if (!int.TryParse(idLimpio, out int id) || id <= 0)
            return "El ID debe ser un número válido mayor a 0.";

        int filasEliminadas = dao.EliminarPorId(id);

        if (filasEliminadas == 0)
            return $"No se encontró ningún cómic con el ID {id}.";

        return string.Empty;
    }
}

