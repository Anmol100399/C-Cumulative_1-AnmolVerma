using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//I already installed MySQL.Data!
using MySql.Data.MySqlClient;

namespace C__Cumulative_1_AnmolVerma.Models
{
    public class SchoolDbContext
    {
        //These are readonly "secrect" properties.
        //Only the SchoolDbContext class can use them.
        //Change these to match our own local school database.
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "school"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }
        //This is the method we actually use to get the database!
        /// <summary>
        /// Returns a connection to the school database.
        /// </summary>
        /// <example>
        /// private SchoolDBContext School = new SchoolDbContext();
        /// MySqlConnection Conn = School.AccessDatabase();
        /// </example>
        /// <returns>A MySqlCoonnection Object</returns>
        public MySqlConnection AccessDatabase ()
        {
            //we are instantiating the MySqlConection Class to create an object
            //the object is a specific connection to our school database on port 3306 of localhost
            return new MySqlConnection(ConnectionString);
        }
    }
}