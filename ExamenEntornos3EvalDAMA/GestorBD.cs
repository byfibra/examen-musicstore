using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenEntornos3EvalDAMA
{
    using MySql.Data.MySqlClient;
    using ExamenEntornos3EvalDAMA;

    public class GestorBD
    {
        private MySqlConnection conexion;

        public GestorBD()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "musicstore";

            conexion = new MySqlConnection(builder.ToString());
        }

        public void Insertar(Album p)
        {
            string query = "INSERT INTO album (titulo, artista, anyo, disponible) VALUES (@titulo, @artista, @anyo, @disponible)";
            MySqlCommand cmd = new MySqlCommand(query, conexion);

            cmd.Parameters.AddWithValue("@titulo", p.GetTitulo());
            cmd.Parameters.AddWithValue("@artista", p.GetArtista());
            cmd.Parameters.AddWithValue("@anyo", p.GetAnyo());
            cmd.Parameters.AddWithValue("@disponible", p.IsDisponible());

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public List<Album> ObtenerTodos()
        {
            List<Album> lista = new List<Album>();
            string query = "SELECT titulo, artista, anyo, disponible FROM album";
            MySqlCommand cmd = new MySqlCommand(query, conexion);

            conexion.Open();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Album a = new Album(
                        reader.GetString("titulo"),
                        reader.GetString("artista"),
                        reader.GetInt32("anyo"),
                        reader.GetBoolean("disponible")
                    );
                    lista.Add(a);
                }
            }
            conexion.Close();
            return lista;
        }
    }
}
