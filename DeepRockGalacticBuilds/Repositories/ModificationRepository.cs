using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeepRockGalacticBuilds.Models;
using Microsoft.Data.Sqlite;

namespace DeepRockGalacticBuilds.Repositories
{
	public class ModificationRepository : IModificationRepository
	{
		string database = "./DeepRockGalactic.db";
		public List<Modification> GetAllModifications()
		{
			List<Modification> modificationList = new List<Modification>();
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
						var modification = new Modification();
						modification.ModificationID = Convert.ToInt32(result["EquipmentID"]);
						modification.ModificationName = result["EquipmentName"].ToString();

						modificationList.Add(modification);
					}

					return modificationList;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Modification GetModificationByID(int modificationID)
		{
			var connectionStringBuilder = new SqliteConnectionStringBuilder();
			connectionStringBuilder.DataSource = database;

			using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
			{
				connection.Open();

				var tableCmd = connection.CreateCommand();
				tableCmd.CommandText = "SELECT * FROM Equipment WHERE EquipmentID = " + modificationID;
				tableCmd.ExecuteNonQuery();

				return null;
			}
		}

		public Modification AddModification(Modification modification)
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
					tableCmd.Parameters.AddWithValue("@dwarf", modification.ModificationName);
					tableCmd.ExecuteNonQuery();

					return modification;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Equipment not added");
			}
		}

		public Modification UpdateModification(Modification modification)
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

		public Modification DeleteModification(int modificationID)
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

