using DeepRockGalacticBuilds.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Repositories
{
	public class PerkRepository : IPerkRepository
	{
		string database = "./DeepRockGalactic.db";
		public List<Perk> GetAllPerks()
		{
			List<Perk> modificationList = new List<Perk>();
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
						var perk = new Perk();
						perk.PerkID = Convert.ToInt32(result["EquipmentID"]);
						perk.PerkName = result["EquipmentName"].ToString();

						modificationList.Add(perk);
					}

					return modificationList;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Perk GetPerkByID(int perkID)
		{
			var perk = new Perk();

			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "SELECT * FROM Perk WHERE PerkID = @PerkID;";
					tableCmd.Parameters.AddWithValue("@PerkID", perkID);
					var result = tableCmd.ExecuteReader();

					while (result.Read())
					{
						perk.PerkID = Convert.ToInt32(result["PerkID"]);
						perk.PerkName = result["PerkName"].ToString();
					}
					return perk;
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool AddPerk(Perk perk)
		{
			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "INSERT INTO Perk (PerkName) VALUES (@PerkName);";
					tableCmd.Parameters.AddWithValue("@PerkName", perk.PerkName);
					tableCmd.ExecuteNonQuery();

					return true;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Modification not added");
			}
		}

		public bool UpdatePerk(Perk perk)
		{
			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "UPDATE Perk SET PerkName = @PerkName WHERE PerkID = @PerkID;";
					tableCmd.Parameters.AddWithValue("@PerkName", perk.PerkName);
					tableCmd.Parameters.AddWithValue("@PerkID", perk.PerkID);
					tableCmd.ExecuteNonQuery();

					return true;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public bool DeletePerk(int perkID)
		{
			var connectionStringBuilder = new SqliteConnectionStringBuilder();
			connectionStringBuilder.DataSource = database;

			try
			{
				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "DELETE FROM Perk WHERE PerkID = @PerkID;";
					tableCmd.Parameters.AddWithValue("@PerkID", perkID);
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
