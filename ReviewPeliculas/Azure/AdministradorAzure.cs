using ReviewPeliculas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace ReviewPeliculas.Azure
{
    public class AdministradorAzure
    {
        static string connectionString = @"Server=DESKTOP-UJCISGT;Database=ApiReviewsPeli;Trusted_Connection=True;";

        private static List<Administrador> Admins;

        public static List<Administrador> ObtenerAdmins()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var dataTableAdmin = retornoDeAdminSQL(connection);
                return LlenadoAdmins(dataTableAdmin);
            }
        }

        public static Administrador ObtenerAdministradorPorId(int idAdministrador)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var comando = ConsultaAdminPorIdSql(connection, idAdministrador);

                var dataTable = LlenarDataTable(comando);

                return CreacionAdmin(dataTable);
            }
        }

        public static Administrador obtenerAdministradorPorNombres(string nombres)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var comando = ConsultaAdminPorNombresSql(connection, nombres);

                var dataTable = LlenarDataTable(comando);

                return CreacionAdmin(dataTable);

            }
        }

        private static SqlCommand ConsultaAdminPorNombresSql(SqlConnection connection, string nombres)
        {
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = $"select * from Administrador where nombres = '{nombres}'";
            connection.Open();
            return sqlCommand;
        }

        private static Administrador CreacionAdmin(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                Administrador Admin = new Administrador();
                Admin.idAdministrador = int.Parse(dataTable.Rows[0]["idAdministrador"].ToString());
                Admin.nombres = dataTable.Rows[0]["nombres"].ToString();
                Admin.apellidos = dataTable.Rows[0]["apellidos"].ToString();
                Admin.edad = int.Parse(dataTable.Rows[0]["edad"].ToString());
                Admin.genero = dataTable.Rows[0]["genero"].ToString();
                Admin.email = dataTable.Rows[0]["email"].ToString();
                return Admin;
            }
            else
            {
                return null;
            }
        }

        private static DataTable LlenarDataTable(SqlCommand comando)
        {
            //2. llenamos el dataTable(conversion)
            var dataTable = new DataTable();
            var dataAdapter = new SqlDataAdapter(comando);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        private static SqlCommand ConsultaAdminPorIdSql(SqlConnection connection, int idAdministrador)
        {
            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = $"select * from Administrador where idAdministrador = {idAdministrador}";
            connection.Open();
            return sqlCommand;
        }

        private static List<Administrador> LlenadoAdmins(DataTable dataTable)
        {
            Admins = new List<Administrador>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Administrador admin = new Administrador();
                admin.idAdministrador = int.Parse(dataTable.Rows[i]["idAdministrador"].ToString());
                admin.nombres = dataTable.Rows[i]["nombres"].ToString();
                admin.apellidos = dataTable.Rows[i]["apellidos"].ToString();
                admin.edad = int.Parse(dataTable.Rows[i]["edad"].ToString());
                admin.genero = dataTable.Rows[i]["genero"].ToString();
                admin.email = dataTable.Rows[i]["email"].ToString();
                Admins.Add(admin);
            }
            return Admins;
        }

        private static DataTable retornoDeAdminSQL(SqlConnection connection)
        {

            SqlCommand sqlCommand = new SqlCommand(null, connection);
            sqlCommand.CommandText = "select * from Administrador";
            connection.Open();

            return LlenarDataTable(sqlCommand);
        }

    }
}

