using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Madplan.ClassLibrary.Models.UserData;
using System.Data.SqlClient;
using System.Data;

namespace Madplan.ClassLibrary.Services
{
    public class UserdataService : IUserdataService
    {

        private string _connectionString;

        public UserdataService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public UserdataService()
        {
        }

        public bool SetUserData(UserData data)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "SetUserData";
                        command.Parameters.AddWithValue("@id", data.Id);
                        command.Parameters.AddWithValue("@Age", data.Age);
                        command.Parameters.AddWithValue("@Weight", data.Weight);
                        command.Parameters.AddWithValue("@Height", data.Height);


                        connection.Open();

<<<<<<< master
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            result = command.ExecuteNonQuery() == 1;
                        }
=======

                        result = command.ExecuteNonQuery() == 1;

>>>>>>> local
                    }

                }

<<<<<<< master
                
=======

>>>>>>> local
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;

        }

        public UserData GetUserData(Guid id)
        {

            UserData data = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "GetUserData";
                        command.Parameters.AddWithValue("@id", id);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                data = new UserData();
                                data.Age = Convert.ToInt32(reader["Age"]);
                                data.Height = Convert.ToInt32(reader["Height"]);
                                data.Weight = Convert.ToInt32(reader["Weight"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return data;


        }


    }
}
