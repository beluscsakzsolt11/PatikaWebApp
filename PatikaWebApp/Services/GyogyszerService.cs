namespace PatikaWebApp.Services;
using MySql.Data.MySqlClient;
using PatikaWebApp.Models;

public class GyogyszerService
    {
        //GetAll
        public List<Gyogyszer> GetAllGyogyszer()
        {
            List<Gyogyszer> gyogyszerek = new List<Gyogyszer>();
            string? connectionString = "SERVER = localhost;" +
                          "DATABASE= patika;" +
                          "UID = root;" +
                          "PASSWORD =;";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
            string sql = "SELECT * FROM gyogyszer";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //A beolvasott adatok feldolgozása
                Gyogyszer gyogyszer = new Gyogyszer();
                gyogyszer.Id = reader.GetInt32("Id");
                gyogyszer.Nev = reader.GetString("Nev");
                gyogyszer.Hatoanyag = reader.GetString("Hatoanyag");
                gyogyszer.Venykoteles = reader.GetBoolean("Venykoteles");
                gyogyszer.kepnev = reader.GetString("kepnev");
                gyogyszerek.Add(gyogyszer);

            }
            conn.Close();
            return gyogyszerek;
        }

        //GetById
        public Gyogyszer GetById(int id)
        {
            Gyogyszer result = new Gyogyszer();
            try
            {
                List<Gyogyszer> gyogyszerek = new List<Gyogyszer>();
                string? connectionString = "SERVER = localhost;" +
                              "DATABASE= patika" +
                              "UID = root;" +
                              "PASSWORD =;";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                string sql = "SELECT * FROM gyogyszer WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    result.Id = reader.GetInt32("Id");
                    result.Nev = reader.GetString("Nev");
                    result.Hatoanyag = reader.GetString("Hatoanyag");
                    result.Venykoteles = reader.GetBoolean("Venykoteles");
                    result.kepnev = reader.GetString("kepnev");
                }
                else
                {
                    Console.WriteLine("Nincs ilyen gyógyszer");
                }
                conn.Close();
                return result;
            }

            catch (Exception)
            {
                Console.WriteLine("Hiba");
                return result;
            }
    }
}

