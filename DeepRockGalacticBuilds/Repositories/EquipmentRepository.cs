using DeepRockGalacticBuilds.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Repositories
{
	public class EquipmentRepository :IEquipmentRepository
	{
		string database = "./DeepRockGalactic.db";
		public List<Equipment> GetAllEquipment()
		{
			List<Equipment> equipmentList = new List<Equipment>();
			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "SELECT * FROM Equipment;";
					var result = tableCmd.ExecuteReader();

					while (result.Read())
					{
						var equipment = new Equipment();
						equipment.EquipmentID = Convert.ToInt32(result["EquipmentID"]);
						equipment.EquipmentName = result["EquipmentName"].ToString();

						equipmentList.Add(equipment);
					}

					return equipmentList;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Equipment GetEquipmentByID(int id)
		{
			var connectionStringBuilder = new SqliteConnectionStringBuilder();
			connectionStringBuilder.DataSource = database;

			using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
			{
				connection.Open();

				var tableCmd = connection.CreateCommand();
				tableCmd.CommandText = "SELECT * FROM Equipment WHERE EquipmentID = " + id;
				tableCmd.ExecuteNonQuery();

				return null;
			}
		}

		public Equipment AddEquipment(Equipment equipment)
		{
			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "INSERT INTO Equipment (DwarfName) VALUES (@dwarf);";
					tableCmd.Parameters.AddWithValue("@dwarf", equipment.EquipmentName);
					tableCmd.ExecuteNonQuery();

					return equipment;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Equipment not added");
			}
		}

		public Equipment UpdateEquipment(Equipment equipment)
		{
			var connectionStringBuilder = new SqliteConnectionStringBuilder();
			connectionStringBuilder.DataSource = database;

			using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
			{
				connection.Open();

				var tableCmd = connection.CreateCommand();
				tableCmd.CommandText = "CREATE TABLE Dwarf(name VARCHAR(50));";
				tableCmd.ExecuteNonQuery();

				return null;
			}
		}

		public Equipment DeleteEquipment(int equipmentID)
		{
			var connectionStringBuilder = new SqliteConnectionStringBuilder();
			connectionStringBuilder.DataSource = database;

			using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
			{
				connection.Open();

				var tableCmd = connection.CreateCommand();
				tableCmd.CommandText = "CREATE TABLE Equipment(name VARCHAR(50));";
				tableCmd.ExecuteNonQuery();

				return null;
			}
		}
	}
}
