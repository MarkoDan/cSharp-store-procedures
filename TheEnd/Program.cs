using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace TheEnd
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            string ConnectionString = "Data Source=DESKTOP-QHO6GIC;Initial Catalog=TheEndDb;Integrated Security=True";
 
            
            SqlConnection connection = new SqlConnection(ConnectionString);
            while (true)
            {
                Console.WriteLine("1 - Vis Alle Personer med alle deres data");
                Console.WriteLine("2 - Vis Alle Personer med alle deres data ud fra et bestemt fornavn");
                Console.WriteLine("3 - Vis alle personer med en adresse");
                int choise = Convert.ToInt32(Console.ReadLine());
                if(choise == 1 ) 
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString));
                    {
                        connection.Open();

                        SqlCommand cmd = new SqlCommand("usp_GetAllPersons", connection);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"Id: {reader["Id"]}, FirstName {reader["FirstName"]}, LastName: {reader["LastName"]}, Birthday {reader["BirthDay"]}");
                                Console.WriteLine();
                            }
                        }
                        connection.Close();
                    }

                }
                else if(choise == 2 )
                {
                    Console.WriteLine("Enter a name: ");
                    string name = Console.ReadLine();
                    using (SqlConnection conn = new SqlConnection(ConnectionString));
                    {
                        connection.Open();

                        SqlCommand cmd = new SqlCommand("_usp_GetPersonByFirstName", connection);

                        cmd.CommandType = CommandType.StoredProcedure;

                      
                        cmd.Parameters.Add(new SqlParameter("@FirstName", name));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"Id: {reader["Id"]}, FirstName {reader["FirstName"]}, LastName: {reader["LastName"]}, Birthday {reader["BirthDay"]}");
                                Console.WriteLine();
                            }
                        }
                        connection.Close();
                    }



                }
                else if(choise == 3)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString));
                    {
                        connection.Open();

                        SqlCommand cmd = new SqlCommand("usp_getFirstNameAndLastNameAndStreetNumberFromAllPersons", connection);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"FirstName {reader["FirstName"]}, LastName: {reader["LastName"]}, StreetAndNumbe: {reader["StreetAndNumber"]}");
                                Console.WriteLine();
                            }
                        }
                        connection.Close();    
                    }

                }
                else if(choise == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number");
                }
            }

        }
    }
}