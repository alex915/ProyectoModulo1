using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Videoclub.Models;

namespace Videoclub
{
    class Service
    {
        public static Usuario User { get; set; }

        private static string ConnectionString = ConfigurationManager.ConnectionStrings["VideoClub"].ConnectionString;

        private static SqlConnection Conexion = new SqlConnection(ConnectionString);


        public static List<Pelicula> GetPeliculas()
        {
            string query = "Select * From Peliculas where edadRecomendada in (Select IdEdadRec from EdadesRecomendadas where anios <= @edad)";
            List<Pelicula> peliculas = new List<Pelicula>();
            Conexion.Open();
            SqlCommand cmd =
            new SqlCommand(query, Conexion);
            cmd.Parameters.Add(new SqlParameter("@edad", User.Edad()));
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Pelicula p = ExtractPelicula(reader);

                peliculas.Add(p);
            }
            Conexion.Close();
            peliculas.ForEach(x =>
            {
                x.Genero = GetGenero(x.GeneroId);
                x.EdadRecomen = GetEdadRecomendada(x.EdadRecomendada);
            });

            return peliculas;

        }
        public static List<Genero> GetGeneros()
        {
            string query = "Select * From Generos";
            List<Genero> genero = new List<Genero>();
            Conexion.Open();
            SqlCommand cmd =
            new SqlCommand(query, Conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Genero g = new Genero();
                g.Id = Convert.ToInt32(reader[0].ToString());
                g.Area = reader[1].ToString();

                genero.Add(g);
            }

            Conexion.Close();
            return genero;

        }

        public static List<TiempoPrestamo> GetTiempoPrestamos()
        {
            string query = "Select * From TiemposReservas";
            List<TiempoPrestamo> tp = new List<TiempoPrestamo>();
            Conexion.Open();
            SqlCommand cmd =
            new SqlCommand(query, Conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TiempoPrestamo t = new TiempoPrestamo();
                t.idTiempo = Convert.ToInt32(reader[0].ToString());
                t.Titulo = reader[1].ToString();
                t.Dias = Convert.ToInt32(reader[2].ToString());

                tp.Add(t);
            }

            Conexion.Close();
            return tp;

        }

        public static TiempoPrestamo GetTiempoPrestamo(int id)
        {
            string query = $"Select * From TiemposReservas where idTiempo = {id}";
            TiempoPrestamo tp = null;
            Conexion.Open();
            SqlCommand cmd =
            new SqlCommand(query, Conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tp = new TiempoPrestamo();
                tp.idTiempo = Convert.ToInt32(reader[0].ToString());
                tp.Titulo = reader[1].ToString();
                tp.Dias = Convert.ToInt32(reader[2].ToString());
            }

            Conexion.Close();
            return tp;

        }

        public static Genero GetGenero(int id)
        {
            string query = $"Select * From Generos where idgenero = {id}";
            Conexion.Open();
            SqlCommand cmd =
            new SqlCommand(query, Conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            Genero g = null;
            if (reader.Read())
            {
                g = new Genero();
                g.Id = Convert.ToInt32(reader[0].ToString());
                g.Area = reader[1].ToString();

            }

            Conexion.Close();
            return g;

        }
        public static List<EdadRecomendada> GetEdadesRecomendadas()
        {
            string query = "Select * From EdadesRecomendadas where Anios <= @anios";
            List<EdadRecomendada> edadRec = new List<EdadRecomendada>();
            Conexion.Open();
            SqlCommand cmd =
            new SqlCommand(query, Conexion);
            cmd.Parameters.Add(new SqlParameter("@anios", User.Edad()));
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                EdadRecomendada e = new EdadRecomendada();
                e.Id = Convert.ToInt32(reader[0].ToString());
                e.Titulo = reader[1].ToString();
                e.Anios = Convert.ToInt32(reader[2].ToString());

                edadRec.Add(e);
            }

            Conexion.Close();
            return edadRec;

        }

        public static EdadRecomendada GetEdadRecomendada(int id)
        {
            string query = $"Select * From EdadesRecomendadas where IdEdadRec={id}";
            Conexion.Open();
            SqlCommand cmd =
            new SqlCommand(query, Conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            EdadRecomendada e = null;
            if (reader.Read())
            {
                e = new EdadRecomendada();
                e.Id = Convert.ToInt32(reader[0].ToString());
                e.Titulo = reader[1].ToString();
                e.Anios = Convert.ToInt32(reader[2].ToString());

            }

            Conexion.Close();
            return e;

        }
        public static List<Alquiler> GetPeliculasAlquiladas()
        {
            List<Alquiler> reserva = new List<Alquiler>();
            string query = $"Select * from Alquileres where Usuario = {User.IdUsuario}";
            Conexion.Open();
            SqlCommand cmd = new SqlCommand(query, Conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Alquiler r = ExtractAlquiler(reader);
                reserva.Add(r);
            }

            Conexion.Close();
            reserva.ForEach(x =>
            {
                if (x != null)
                {
                    x.Pelicula = GetPelicula(x.PeliculaId);
                    x.TiempoPrestamo = GetTiempoPrestamo(x.TiempoReserva);
                }

            });
            return reserva;



        }


        public static List<Pelicula> BuscarPelicula(string titulo)
        {
            return GetPeliculas().Where(x => x.Titulo.ToLower().Contains(titulo)).ToList();

        }
        public static Pelicula GetPelicula(int id)
        {
            string query = $"Select * From Peliculas where IdPelicula = {id}";
            Pelicula p = null;
            Conexion.Open();
            SqlCommand cmd =
            new SqlCommand(query, Conexion);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                p = ExtractPelicula(reader);

            }

            Conexion.Close();
            if (p != null)
            {
                p.Genero = GetGenero(p.GeneroId);
                p.EdadRecomen = GetEdadRecomendada(p.EdadRecomendada);
            }

            return p;

        }


        public static bool Alquilar(int idPelicula, int tp)
        {

            if (GetPeliculasAlquiladas().Where(x => x.FechaDevolucion == null).Count() < 4 &&
                    !GetPeliculasAlquiladas().Where(x => x.PeliculaId == idPelicula && x.FechaDevolucion == null).Any())
            {
                string insert = "INSERT INTO Alquileres (Usuario,Pelicula,FechaAlquiler,TiempoReserva)" +
                $"VALUES({User.IdUsuario} ,{idPelicula},GETDATE(), {tp})";
                //Cambiar el tiempo reserva.
                Conexion.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(insert, Conexion);
                    int i = cmd.ExecuteNonQuery();
                    Conexion.Close();
                    return i != 0;
                }
                catch (Exception)
                {
                    throw;
                }


            }
            return false;
        }
        public static bool Devolver(string idPelicula)
        {
            string query = $"UPDATE Alquileres SET FechaDevolucion = GETDATE() " +
                 $"WHERE Pelicula = {idPelicula} AND Usuario = {User.IdUsuario} AND FechaDevolucion IS NULL";

            Conexion.Open();
            int i;
            try
            {
                SqlCommand cmd = new SqlCommand(query, Conexion);
                i = cmd.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }


            return i != 0;
        }


        private static Pelicula ExtractPelicula(SqlDataReader reader)
        {
            Pelicula p = new Pelicula
            {
                Id = Convert.ToInt32(reader[0].ToString()),
                Titulo = reader[1].ToString(),
                Sinopsis = reader[2].ToString(),
                EdadRecomendada = Convert.ToInt32(reader[3].ToString()),
                GeneroId = Convert.ToInt32(reader[4].ToString()),
                Estado = Convert.ToBoolean(reader[5].ToString())
            };
            return p;
        }
        private static Alquiler ExtractAlquiler(SqlDataReader reader)
        {
            Alquiler r = new Alquiler();
            r.Id = Convert.ToInt32(reader[0].ToString());
            r.UsuarioId = Convert.ToInt32(reader[1].ToString());
            r.PeliculaId = Convert.ToInt32(reader[2].ToString());
            r.FechaAlquiler = Convert.ToDateTime(reader[3].ToString());
            r.TiempoReserva = Convert.ToInt32(reader[4].ToString());
            r.FechaDevolucion = reader[5] != DBNull.Value ? Convert.ToDateTime(reader[5]) : (DateTime?)null;
            return r;
        }


        public static Usuario Login(string email, string password)
        {
            string query = "Select * From Usuarios Where Email = @email and Password = @password and Estado = 1";
            Conexion.Open();
            SqlCommand cmd = new SqlCommand(query, Conexion);
            SqlParameter paramEmail = new SqlParameter("@email", email);
            SqlParameter paramPassword = new SqlParameter("@password", password);
            cmd.Parameters.Add(paramEmail);
            cmd.Parameters.Add(paramPassword);
            SqlDataReader reader = cmd.ExecuteReader();
            Usuario u = null;
            if (reader.Read())
            {
                u = new Usuario();
                u.IdUsuario = Convert.ToInt32(reader[0].ToString());
                u.Nombre = reader[1].ToString();
                u.PrimerApellido = reader[2].ToString();
                u.SegundoApellido = reader[3].ToString();
                u.FNac = Convert.ToDateTime(reader[4].ToString());
                u.Email = reader[5].ToString();
                u.Password = reader[6].ToString();
                u.FechaRegistro = Convert.ToDateTime(reader[7].ToString());
            }

            Conexion.Close();

            User = u;
            return u;

        }
        public static Usuario Register(Usuario u)
        {

            string query = "INSERT INTO Usuarios " +
                "(Nombre,PrimerApellido,SegundoApellido,FechaNac,Email,Password,FechaReg,Estado)" +
                "VALUES (@nombre, @apellido1, @apellido2, @fnac, @email, @password, GETDATE(), 1)";

            Conexion.Open();
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand(query, Conexion);
                cmd.Parameters.Add(new SqlParameter("@nombre", u.Nombre));
                cmd.Parameters.Add(new SqlParameter("@apellido1", u.PrimerApellido));
                cmd.Parameters.Add(new SqlParameter("@apellido2", u.SegundoApellido));
                cmd.Parameters.Add(new SqlParameter("@fnac", u.FNac));
                cmd.Parameters.Add(new SqlParameter("@email", u.Email));
                cmd.Parameters.Add(new SqlParameter("@password", u.Password));
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            Conexion.Close();

            if (result != 0)
            {
                return Login(u.Email, u.Password);
            }

            return null;

        }

        internal static bool ChangePassword(string password)
        {
            string update = $"Update Usuarios Set Password = {password} where idUsuario = {User.IdUsuario}";
            Conexion.Open();
            bool i;
            try
            {
                SqlCommand cmd = new SqlCommand(update, Conexion);
                i = cmd.ExecuteNonQuery() == 1;
                User.Password = password;
                Conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            return i;
        }
        public static bool DarDeBaja()
        {
            string update = $"Update Usuarios Set Estado={0} where idUsuario = {User.IdUsuario}";
            Conexion.Open();
            bool i;
            try
            {
                SqlCommand cmd = new SqlCommand(update, Conexion);
                i = cmd.ExecuteNonQuery() == 1;
                Conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }

            User = null;
            return i;
        }
    }
}
