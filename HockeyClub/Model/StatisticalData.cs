using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace HockeyClub.Model
{
    public class StatisticalData
    {
        private string connectionString = $@"Data Source=SAMSONPC;Initial Catalog=HockeyClub;Integrated Security=True";

        public decimal AverageAge()
        {
            decimal avgAge = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = $"SELECT AVG(DATEDIFF(day, date_birthday, GETDATE()) / 365.0) AS average_age FROM HockeyPlayer";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        avgAge = (decimal)reader["average_age"];
                    }
                }
            }
            return avgAge;
        }

        public List<(string,int)> CountStickPerSeasonEveryOne()
        {
            List<(string,int)> list = new List<(string,int)>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = $"SELECT HP.fio, COUNT(*) as count_stick FROM HockeyPlayer HP JOIN HockeyPlayer_Stick HS ON HS.id_hp = HP.id_hp JOIN Sticks S ON HS.id_st = S.id_st GROUP BY HP.fio ORDER BY COUNT(*) DESC";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string fio = (string)reader["fio"];
                        int countSticks = (int)reader["count_stick"];
                        list.Add((fio, countSticks));
                    }
                }
            }
            return list;
        }
        
        public decimal AverageStickLife()
        {
            int avgStickLife = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = $"SELECT AVG(DATEDIFF(DAY,HockeyPlayer_Stick.issue_date, HockeyPlayer_Stick.return_date)) AS average_stick_time FROM HockeyPlayer JOIN HockeyPlayer_Stick ON HockeyPlayer.id_hp = HockeyPlayer_Stick.id_hp JOIN Sticks ON HockeyPlayer_Stick.id_st = Sticks.id_st WHERE HockeyPlayer.id_hp = 3";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        avgStickLife = (int)reader["average_stick_time"];
                    }
                }
                return avgStickLife;
            }
        }
    }
}
