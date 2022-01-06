using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class DetailsContext
    {
        
            public string ConnectionString { get; set; }

            public DetailsContext(string connectionString)
            {
                this.ConnectionString = connectionString;
            }

            private MySqlConnection GetConnection()
            {
                return new MySqlConnection(ConnectionString);
            }



            public List<Details> GetAllDetails()
            {
                List<Details> list = new List<Details>();

                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from forecast ", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Details()
                            {
                                id = Convert.ToInt32(reader["id"]),
                                date = Convert.ToDateTime(reader["date"]),
                                temperatureC = Convert.ToDouble(reader["temperatureC"]),
                                temperatureF = Convert.ToDouble(reader["temperatureF"]),
                                summary = reader["summary"].ToString()

                            });
                        }
                    }
                }
                return list;
            }

        }

    }


