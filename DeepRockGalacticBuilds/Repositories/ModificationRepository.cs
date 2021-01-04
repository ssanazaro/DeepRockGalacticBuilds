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
			var modification = new Modification();

			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "SELECT * FROM Modification WHERE ModificationID = @ModificationID;";
					tableCmd.Parameters.AddWithValue("@ModificationID", modificationID);
					var result = tableCmd.ExecuteReader();

					while (result.Read())
					{
						modification.ModificationID = Convert.ToInt32(result["ModificationID"]);
						modification.ModificationName = result["ModificationName"].ToString();
					}
					return modification;
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool AddModification(Modification modification)
		{
			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "INSERT INTO Modification (ModificationName) VALUES (@ModificationName);";
					tableCmd.Parameters.AddWithValue("@ModificationName", modification.ModificationName);
					tableCmd.ExecuteNonQuery();

					return true;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Modification not added");
			}
		}

		public bool UpdateModification(Modification modification)
		{
			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "UPDATE Modification SET ModificationName = @ModificationName WHERE ModificationID = @ModificationID;";
					tableCmd.Parameters.AddWithValue("@EquipmentName", modification.ModificationName);
					tableCmd.Parameters.AddWithValue("@ModificationID", modification.ModificationID);
					tableCmd.ExecuteNonQuery();

					return true;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public bool DeleteModification(int modificationID)
		{
			var connectionStringBuilder = new SqliteConnectionStringBuilder();
			connectionStringBuilder.DataSource = database;

			try
			{
				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "DELETE FROM Modification WHERE ModificationID = @ModificationID;";
					tableCmd.Parameters.AddWithValue("@ModificationID", modificationID);
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

