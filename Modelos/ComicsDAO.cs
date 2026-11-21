using System;
using System.IO;
using BibliotecaHistorieta.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace BibliotecaHistorieta.Data;

public class ComicsDAO
{
    public string ConnectionString => $"Data Source={ObtenerRutaDb()}";

    public string ObtenerRutaDb(string nombreArchivo = "biblioteca.db")
    {
        var carpetaBase = AppContext.BaseDirectory;
        Directory.CreateDirectory(carpetaBase);
        return Path.Combine(carpetaBase, nombreArchivo);
    }

    public void Inicializar()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        const string sql = """
            PRAGMA foreign_keys = ON;

            CREATE TABLE IF NOT EXISTS Comics (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL,
                Autor TEXT NOT NULL,
                Anio INTEGER NOT NULL
            );
            """;

        using var command = new SqliteCommand(sql, connection);
        command.ExecuteNonQuery();
    }

    public void Agregar(Comics comic, int anio)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        const string sql = """
            INSERT INTO Comics (Nombre, Autor, Anio)
            VALUES (@Nombre, @Autor, @Anio);
            """;

        using var command = new SqliteCommand(sql, connection);
        command.Parameters.AddWithValue("@Nombre", comic.Nombre?.Trim() ?? string.Empty);
        command.Parameters.AddWithValue("@Autor", comic.Autor?.Trim() ?? string.Empty);
        command.Parameters.AddWithValue("@Anio", anio);

        command.ExecuteNonQuery();
    }

    public List<Comics> Listar()
    {
        var lista = new List<Comics>();

        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        const string sql = """
            SELECT Id, Nombre, Autor, Anio
            FROM Comics
            ORDER BY Id DESC;
            """;

        using var command = new SqliteCommand(sql, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string nombre = reader.GetString(1);
            string autor = reader.GetString(2);
            int anio = reader.GetInt32(3);

            lista.Add(new Comics(id, nombre, autor, anio.ToString()));
        }

        return lista;
    }

    public int ActualizarNombre(int id, string nombre)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        const string sql = """
            UPDATE Comics
            SET Nombre = @Nombre
            WHERE Id = @Id;
            """;

        using var command = new SqliteCommand(sql, connection);
        command.Parameters.AddWithValue("@Nombre", nombre.Trim());
        command.Parameters.AddWithValue("@Id", id);

        // Devuelve cuántas filas se actualizaron (0 si no existía ese Id)
        return command.ExecuteNonQuery();
    }

    public int EliminarPorId(int id)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        const string sql = """
            DELETE FROM Comics
            WHERE Id = @Id;
            """;

        using var command = new SqliteCommand(sql, connection);
        command.Parameters.AddWithValue("@Id", id);

        return command.ExecuteNonQuery();
    }
}