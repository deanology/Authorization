using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication.Models
{
    public class UserDBHandler
    {
        private SqlConnection connect;
        private void Connection()
        {
            string connection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString.ToString();
            connect = new SqlConnection(connection);
        }
        public bool Login(User user)
        {
            Connection();
            try
            {
                //always parametirized queries
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email =@email AND Password =@password", connect);
                cmd.Parameters.AddWithValue("@email", user.Email.Trim());
                cmd.Parameters.AddWithValue("@password", user.Password.Trim());

                //create a sql data adapter
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                //create a datatable
                DataTable dataTable = new DataTable();

                //open connection
                connect.Open();

                //fill data table with data
                data.Fill(dataTable);

                //close connection
                connect.Close();
                if (dataTable.Rows.Count >= 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
        public bool RegisterUser(User user)
        {
            Connection();
            try
            {
                //use the insert query command
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Email, Password, ConfirmPassword, Fullname)" +
                "VALUES(@email, @password, @confirm_password, @fullname)", connect);

                //assigning values to the placeholders 
                cmd.Parameters.AddWithValue("@email", user.Email.Trim());
                cmd.Parameters.AddWithValue("@password", user.Password.Trim());
                cmd.Parameters.AddWithValue("@confirm_password", user.ConfirmPassword.Trim());
                cmd.Parameters.AddWithValue("@fullname", user.Fullname.Trim());

                //open connection
                connect.Open();
                //execute query and insert form values into the database
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
    }
}