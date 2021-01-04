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
			var equipment = new Equipment();

			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "SELECT * FROM Equipment WHERE EquipmentID = @equipmentID;";
					tableCmd.Parameters.AddWithValue("@equipmentID", id);
					var result = tableCmd.ExecuteReader();

					while (result.Read())
					{
						equipment.EquipmentID = Convert.ToInt32(result["EquipmentID"]);
						equipment.EquipmentName = result["EquipmentName"].ToString();
					}
					return equipment;
				}
			}
			catch (Exception)
			{

				throw;
			}

		}

		public bool AddEquipment(Equipment equipment)
		{
			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "INSERT INTO Equipment (EquipmentName) VALUES (@EquipmentName);";
					tableCmd.Parameters.AddWithValue("@EquipmentName", equipment.EquipmentName);
					tableCmd.ExecuteNonQuery();

					return true;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Equipment not added");
			}
		}

		public bool UpdateEquipment(Equipment equipment)
		{
			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "UPDATE Equipment SET EquipmentName = @EquipmentName WHERE EquipmentID = @EquipmentID;";
					tableCmd.Parameters.AddWithValue("@EquipmentName", equipment.EquipmentName);
					tableCmd.Parameters.AddWithValue("@EquipmentID", equipment.EquipmentID);
					tableCmd.ExecuteNonQuery();

					return true;
				}
			}
			catch (Exception)
			{
				throw;
			}
			
		}

		public bool DeleteEquipment(int equipmentID)
		{
			var connectionStringBuilder = new SqliteConnectionStringBuilder();
			connectionStringBuilder.DataSource = database;

			try
			{
				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "DELETE FROM Equipment WHERE EquipmentID = @EquipmentID;";
					tableCmd.Parameters.AddWithValue("@EquipmentID", equipmentID);
					tableCmd.ExecuteNonQuery();

					return true;
				}
			}
			catch (SqliteException ex)
			{
				return false;
			}
		}
	}
}
