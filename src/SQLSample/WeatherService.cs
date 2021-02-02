using MTech.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MTech.SQLSample
{
    public class WeatherService : IWeatherService
    {
        private readonly SqlConnection _connection;

        public WeatherService(SqlConnection connection)
            => _connection = connection;

        public void Create(WeatherForecast model)
        {
            var sql = $"INSERT INTO [WeatherForecast] (Date, Summary, TemperatureC) VALUES(@date, @summary, @temperatureC) SELECT SCOPE_IDENTITY();";

            using var command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@date", model.Date);
            command.Parameters.AddWithValue("@summary", model.Summary);
            command.Parameters.AddWithValue("@temperatureC", model.TemperatureC);
            _connection.Open();
            command.ExecuteNonQuery();
        }

        public WeatherForecast[] GetForecast()
        {
            var result = new List<WeatherForecast>();
            var sql = "SELECT * FROM [WeatherForecast]";

            using (var command = new SqlCommand(sql, _connection))
            {
                _connection.Open();

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new WeatherForecast
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                        TemperatureC = Convert.ToInt32(reader["TemperatureC"])
                    });
                }
            }

            return result.ToArray();
        }
    }
}
