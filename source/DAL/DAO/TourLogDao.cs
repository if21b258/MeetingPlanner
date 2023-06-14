using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using TourPlannerModel;

namespace TourPlannerDAL.DAO
{
    internal class TourLogDao
    {
        public static bool AddTourLog(TourLogModel tourLog)
        {
            NpgsqlConnection connection = DatabaseService.Connect();

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO tourlog(tourid, date, time, comment, difficulty, duration, rating)
                                    VALUES(@tourid, @date, @time, @comment, @difficulty, @duration, @rating)";
            command.Parameters.AddWithValue("tourid", tourLog.TourId);
            command.Parameters.AddWithValue("date", tourLog.Date);
            command.Parameters.AddWithValue("time", tourLog.Time);
            command.Parameters.AddWithValue("comment", tourLog.Comment);
            command.Parameters.AddWithValue("difficulty", tourLog.Difficulty);
            command.Parameters.AddWithValue("duration", tourLog.Duration);
            command.Parameters.AddWithValue("rating", tourLog.Rating);
            command.Prepare();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected > 0)
            {
                return true;
            }
            else return false; ;
        }

        public static bool EditTourLog(TourLogModel tourLog)
        {
            NpgsqlConnection connection = DatabaseService.Connect();

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE tourlog SET
                                    date = @date, 
                                    time = @time,
                                    comment = @comment,
                                    difficulty = @difficulty,
                                    duration = @duration,
                                    rating = @rating
                                    WHERE tourlogid = @tourlogid";
            command.Parameters.AddWithValue("date", tourLog.Date);
            command.Parameters.AddWithValue("time", tourLog.Time);
            command.Parameters.AddWithValue("comment", tourLog.Comment);
            command.Parameters.AddWithValue("difficulty", tourLog.Difficulty);
            command.Parameters.AddWithValue("duration", tourLog.Duration);
            command.Parameters.AddWithValue("rating", tourLog.Rating);
            command.Parameters.AddWithValue("logid", tourLog.LogId);
            command.Prepare();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected > 0)
            {
                return true;
            }
            else return false; ;
        }

        public static bool DeleteTourLog(TourLogModel tourLog)
        {
            NpgsqlConnection connection = DatabaseService.Connect();

            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM tourlog WHERE tourlogid = @tourlogid";
            command.Parameters.AddWithValue("logid", tourLog.LogId);
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
