using HockeyClub.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyClub.DataAccess
{
    public class DbDataAccess: IRepository
    {
        private string connectionString = $@"Data Source=SAMSONPC;Initial Catalog=HockeyClub;Integrated Security=True";
        private List<Stick> listSticks = new List<Stick>();
        private List<HockeyPlayer> listTeam = new List<HockeyPlayer>();
        private List<UsageStick> listUsageStick = new List<UsageStick>();

        public void AddHockeyPlayer(HockeyPlayer player)
        {
            int number;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = $"Insert into HockeyPlayer (game_number, fio, date_birthday, role, height, size, phone_number) " +
                    $"values ('{player.GameNumber}', '{player.FullName}','{player.DateBirthday}','{player.Role}','{player.Height}','{player.Size}','{player.PhoneNumber}');";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                number = sqlCommand.ExecuteNonQuery();
            }
        }

        public void AddStick(Stick stick)
        {
            int number;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = $"Insert into Sticks (brand, model, flex, bend, grip) " +
                    $"values ('{stick.Brand}', '{stick.Model}','{stick.Flex}','{stick.Bend}','{stick.Grip}');";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                number = sqlCommand.ExecuteNonQuery();
            }
        }

        public void AddUsageStick(UsageStick usageStick)
        {
            int number;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = $"Insert into HockeyPlayers_Stick (id_hp, id_st, issue_date, return_date) " +
                    $"values ('{usageStick.HockeyPlayer}', '{usageStick.Stick}','{usageStick.IssueDate}','{usageStick.ReturnDate}');";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                number = sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteHockeyPlayer(HockeyPlayer player)
        {
            int number;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = $"DELETE FROM HockeyPlayer WHERE id_hp = @Id_hp";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@Id_hp", player.Id);
                number = sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteStick(Stick stick)
        {
            int number;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = $"DELETE FROM Sticks WHERE id_st = @Id_st";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@Id_st", stick.Id);
                number = sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteUsageStick(UsageStick usageStick)
        {
            int number;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = $"DELETE FROM HockeyPlayers_Stick WHERE id_st = @Id_st AND id_hp = @Id_hp";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@Id_st", usageStick.Stick.Id);
                sqlCommand.Parameters.AddWithValue("@Id_hp", usageStick.HockeyPlayer.Id);
                number = sqlCommand.ExecuteNonQuery();
            }
        }

        public async Task<List<HockeyPlayer>> GetAllHockeyPlayers()
        {
            List<HockeyPlayer> team = new List<HockeyPlayer>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string command = "Select * from HockeyPlayer";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        int id = (int)reader["id_hp"];
                        int gamenumber = (int)reader["game_number"];
                        string fullname = (String)reader["fio"];
                        DateTime datebirthday = (DateTime)reader["date_birthday"];
                        string role = (String)reader["role"];
                        int height = (int)reader["height"];
                        string size = (String)reader["size"];
                        string phonenumber = (String)reader["phone_number"];
                        HockeyPlayer hockeyPlayer = new HockeyPlayer(id, gamenumber, fullname, datebirthday, role, height, size, phonenumber);
                        team.Add(hockeyPlayer);
                        listTeam.Add(hockeyPlayer);
                    }
                }
            }
            return team;
        }

        public async Task<List<Stick>> GetAllSticks()
        {
            List<Stick> sticks = new List<Stick>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string command = "Select * from Sticks";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        int id = (int)reader["id_st"];
                        string brand = (String)reader["brand"];
                        string model = (String)reader["model"];
                        int flex = (int)reader["flex"];
                        int bend = (int)reader["bend"];
                        string grip = (String)reader["grip"];
                        Stick stick = new Stick(id,brand, model, flex, bend, grip);
                        sticks.Add(stick);
                        listSticks.Add(stick);
                    }
                }
            }
            return sticks;
        }

        public async Task<List<UsageStick>> GetAllUsageSticks()
        {
            await GetAllHockeyPlayers();
            await GetAllSticks();
            List<UsageStick> usageSticks = new List<UsageStick>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string command = "Select * from HockeyPlayer_Stick";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        int id_hockeyplayer = (int)reader["id_hp"];
                        int id_stick = (int)reader["id_st"];
                        HockeyPlayer player = listTeam.FirstOrDefault(x => x.Id == id_hockeyplayer);
                        Stick stick = listSticks.FirstOrDefault(x => x.Id == id_stick);
                        DateTime issuedate = (DateTime)reader["issue_date"];
                        DateTime returndate = (DateTime)reader["return_date"];
                        UsageStick usageStick = new UsageStick(player, stick, issuedate, returndate);
                        usageSticks.Add(usageStick);
                        listUsageStick.Add(usageStick);
                    }
                }
            }
            return usageSticks;
        }

        public void UpdateHockeyPlayer(HockeyPlayer player)
        {
            int number;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = $"UPDATE HockeyPlayer SET game_number=@GameNumber,fio=@FullName,date_birthday=@DateBirthday, " +
                    $"role=@Role, height=@Height, size=@Size, phone_number=@PhoneNumber WHERE id_hp = @Id_hp";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@GameNumber", player.GameNumber);
                sqlCommand.Parameters.AddWithValue("@FullName", player.FullName);
                sqlCommand.Parameters.AddWithValue("@DateBirthday", player.DateBirthday);
                sqlCommand.Parameters.AddWithValue("@Role", player.Role);
                sqlCommand.Parameters.AddWithValue("@Height", player.Height);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", player.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Size", player.Size);
                sqlCommand.Parameters.AddWithValue("@Id_hp", player.Id);
                number = sqlCommand.ExecuteNonQuery();
            }
        }

        public void UpdateStick(Stick stick)
        {
            int number;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = $"UPDATE Stick SET brand=@Brand,model=@Model,flex=@Flex, " +
                    $"bend=@Bend, grip=@Grip WHERE id_st = @Id_st";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@Brand", stick.Brand);
                sqlCommand.Parameters.AddWithValue("@Model", stick.Model);
                sqlCommand.Parameters.AddWithValue("@Flex", stick.Flex);
                sqlCommand.Parameters.AddWithValue("@Bend", stick.Bend);
                sqlCommand.Parameters.AddWithValue("@Grip", stick.Grip);
                sqlCommand.Parameters.AddWithValue("@Id_st", stick.Id);
                number = sqlCommand.ExecuteNonQuery();
            }
        }

        public void UpdateUsageStick(UsageStick usageStick)
        {
            int number;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string command = $"UPDATE HockeyPlayer_Stick SET issue_date=@IssueDate,return_date=@ReturnDate" +
                    $"WHERE id_st = @Id_st AND id_hp = @Id_hp";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@IssueDate", usageStick.IssueDate);
                sqlCommand.Parameters.AddWithValue("@ReturnDate", usageStick.ReturnDate);
                sqlCommand.Parameters.AddWithValue("@Id_hp", usageStick.HockeyPlayer.Id);
                sqlCommand.Parameters.AddWithValue("@Id_st", usageStick.Stick.Id);
                number = sqlCommand.ExecuteNonQuery();
            }
        }
    }
}