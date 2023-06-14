using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace TourPlannerDAL
{
    internal class DatabaseService
    {
        //TODO: outsource to config file
        private static string _host = "localhost";
        private static string _username = "postgres";
        private static string _password = "admin";
        private static string _database = "tourplanner";

        public static NpgsqlConnection Connect()
        {
            string cs = "Host=" + _host + ";Username=" + _username + ";Password=" + _password + ";Database=" + _database;
            NpgsqlConnection conn = new NpgsqlConnection(cs);
            conn.Open();
            return conn;
        }

        public void BuildDatabase()
        {
            CreateDatabase();
            CreateTableTour();
            CreateTableTourLog();
        }

        public void CreateDatabase()
        {
            string cs = "Host=" + _host + ";Username=" + _username + ";Password=" + _password;
            NpgsqlConnection conn = new NpgsqlConnection(cs);
            NpgsqlCommand command = new NpgsqlCommand(@"DROP DATABASE IF EXISTS " + _database + ";" +
                                                        " CREATE DATABASE " + _database);
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void CreateTableTour()
        {
            NpgsqlConnection conn = DatabaseService.Connect();
            NpgsqlCommand command = new NpgsqlCommand(@"CREATE TABLE IF NOT EXISTS TOUR (
	                                                    TOURID SERIAL PRIMARY KEY,
	                                                    NAME VARCHAR(80) DEFAULT '' NOT NULL,
	                                                    ORIGIN VARCHAR(80) DEFAULT '' NOT NULL,
	                                                    DESTINATION VARCHAR(80) DEFAULT '' NOT NULL,
	                                                    TRANSPORTTYPE VARCHAR(80) DEFAULT '' NOT NULL,
	                                                    DESCRIPTION VARCHAR(80) DEFAULT '' NOT NULL,
	                                                    DISTANCE VARCHAR(80) DEFAULT '' NOT NULL,
	                                                    ESTIMATEDTIME VARCHAR(80) DEFAULT '' NOT NULL,
                                                        );", conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public void CreateTableTourLog()
        {
            NpgsqlConnection conn = DatabaseService.Connect();
            NpgsqlCommand command = new NpgsqlCommand(@"CREATE TABLE IF NOT EXISTS TOURLOG (
                                                        LOGID SERIAL PRIMARY KEY,
                                                        TOURID INT REFERENCES TOUR (TOURID),
	                                                    DATE VARCHAR(80) DEFAULT '' NOT NULL,
	                                                    TIME VARCHAR(80) DEFAULT '' NOT NULL,
                                                        COMMENT VARCHAR(80) DEFAULT '' NOT NULL,
                                                        DIFFICULTY INT DEFAULT 0 NOT NULL,
                                                        DURATION VARCHAR(80) DEFAULT '' NOT NULL,
                                                        RATING INT DEFAULT 0 NOT NULL,
                                                        );", conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}