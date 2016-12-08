using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApplication1
{
    public class SQLConnection
    {
        private static string connectionstring = "server=ealdb1.eal.local; Database= ejl04_db; User Id=ejl04_usr; Password=Baz1nga4;";
        SqlConnection SqlCon = new SqlConnection(connectionstring);

        public void LogIn()
        {
                try
                {
                    SqlCon.Open();
                }
                catch (SqlException errormessage)
                {
                    Console.WriteLine("Error when logging in: " + errormessage);
                }
        }

        public void LogOut()
        {
            try
            {
                SqlCon.Close();
            }
            catch (SqlException errormessage)
            {
                Console.WriteLine("Error when logging out: " + errormessage);
            }
        }

        public bool LoggedIn()
        {
            if (SqlCon.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddStudent(string Efternavn, string Fornavn, string Klasse)
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("AddStudent", SqlCon);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add(new SqlParameter("ElevEfternavn", Efternavn));
                cmd1.Parameters.Add(new SqlParameter("ElevFornavn", Fornavn));
                cmd1.Parameters.Add(new SqlParameter("ElevKlasse", Klasse));
                cmd1.ExecuteNonQuery();
            }
            catch (SqlException errormessage)
            {
                Console.WriteLine("Error When Executing 'AddStudent': " + errormessage);
            }
        }

    }
}
