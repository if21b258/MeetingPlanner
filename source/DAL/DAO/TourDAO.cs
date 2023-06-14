using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;

namespace TourPlannerDAL.DAO
{
    internal class TourDAO
    {
        public static bool AddTour(TourModel tour)
        {
            NpgsqlConnection connection = DatabaseService.Connect();

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO tour(name, origin, destination, transporttype, description, distance, estimatedtime)
                                    VALUES(@name, @origin, @destination, @transporttype, @description, @distance, @estimatedtime)";
            command.Parameters.AddWithValue("username", tour.Name);
            command.Parameters.AddWithValue("origin", tour.Origin);
            command.Parameters.AddWithValue("destination", tour.Destination);
            command.Parameters.AddWithValue("transporttype", tour.TransportType);
            command.Parameters.AddWithValue("description", tour.Description);
            command.Parameters.AddWithValue("distance", tour.Distance);
            command.Parameters.AddWithValue("estimatedtime", tour.EstimatedTime);
            command.Prepare();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected > 0)
            {
                return true;
            }
            else return false; ;
        }

        public static bool EditTour(TourModel tour)
        {
            NpgsqlConnection connection = DatabaseService.Connect();

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE tour SET
                                    name = @name,
                                    origin = @origin,
                                    destination = @destination,
                                    transporttype = @transporttype,
                                    description = @description,
                                    distance = @distance,
                                    estimatedtime = @estimatedtime
                                    WHERE tourid = @tourid";
            command.Parameters.AddWithValue("name", tour.Name);
            command.Parameters.AddWithValue("origin", tour.Origin);
            command.Parameters.AddWithValue("destination", tour.Destination);
            command.Parameters.AddWithValue("transporttype", tour.TransportType);
            command.Parameters.AddWithValue("description", tour.Description);
            command.Parameters.AddWithValue("distance", tour.Distance);
            command.Parameters.AddWithValue("estimatedtime", tour.EstimatedTime);
            command.Parameters.AddWithValue("tourid", tour.TourId);
            command.Prepare();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected > 0)
            {
                return true;
            }
            else return false; ;
        }

        public static bool DeleteTour(TourModel tour)
        {
            NpgsqlConnection connection = DatabaseService.Connect();

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM tour WHERE tourid = @tourid";
            command.Parameters.AddWithValue("tourid", tour.TourId);
            command.Prepare();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected > 0)
            {
                return true;
            }
            else return false; ;
        }
    }
}
