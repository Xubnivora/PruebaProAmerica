using System.Data;
using System.Data.SqlClient;

namespace PruebaProAmerica.Pages
{
    public class ConnectorDataBase
    {


        public void Seleccionador_BaseDatos(String valor_seleccionado)
        {
            var conector = new SqlConnection("Server=LAPTOP-DIJC1E1E\\SQLEXPRESS;Database=PRUEBAREST;Integrated Security=SSPI;Trusted_Connection=True;");
            try
            {

                var select = "SELECT * FROM  [PRUEBAREST].[dbo].[USER_LOG] WHERE [id_user] = " + valor_seleccionado;
                var dataAdapter = new SqlDataAdapter(select, conector);

                if (valor_seleccionado.Length > 0)
                {

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);


                }

                conector.Close();

            }catch(Exception ex)
            {
                conector.Close();
                Console.WriteLine(ex.ToString());
            }

        }


        public void insertado_usuario(String id, String name, String email, String gender, String status)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection("Server=LAPTOP-DIJC1E1E\\SQLEXPRESS;Database=PRUEBAREST;Integrated Security=SSPI;Trusted_Connection=True;"))
                {
                    String query = "INSERT INTO [PRUEBAREST].[dbo].[USERLOG] ([id] ,[name_user],[email],[gender] ,[status_user]) VALUES  (@id,@name,@email, @gender,@status)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@status", status);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            Console.WriteLine("Error al insertar en la base de datos!");
                        }
                    }
                    connection.Close();
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        public void borrado_usuario(String id)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection("Server=LAPTOP-DIJC1E1E\\SQLEXPRESS;Database=PRUEBAREST;Integrated Security=SSPI;Trusted_Connection=True;"))
                {
                    String query = "DELETE FROM [PRUEBAREST].[dbo].[USERLOG] WHERE  [id] = @id;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            Console.WriteLine("Error al eliminar en la base de datos!");
                        }
                    }
                    connection.Close();
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        public void actuzalizado_usuario(String id, String name, String email, String gender, String status)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection("Server=LAPTOP-DIJC1E1E\\SQLEXPRESS;Database=PRUEBAREST;Integrated Security=SSPI;Trusted_Connection=True;"))
                {



                    String query = "UPDATE  [PRUEBAREST].[dbo].[USERLOG] SET  " +
                        "[name_user] = @name" +
                        ",[email] = @email" +
                        ",[gender] = @gender" +
                        ",[status_user] = @status WHERE  [id] = @id;";
                     
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@status", status);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            Console.WriteLine("Error al eliminar en la base de datos!");
                        }
                    }
                    connection.Close();
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }






    }



}
