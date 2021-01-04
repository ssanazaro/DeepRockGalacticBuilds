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
			var connectionStringBuilder = new SqliteConnectionStringBuilder();
			connectionStringBuilder.DataSource = database;

			using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
			{
				connection.Open();

				var tableCmd = connection.CreateCommand();
				tableCmd.CommandText = "SELECT * FROM Equipment WHERE EquipmentID = " + perkID;
				tableCmd.ExecuteNonQuery();

				return null;
			}
		}

		public Perk AddPerk(Perk perk)
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
					tableCmd.Parameters.AddWithValue("@dwarf", perk.PerkID);
					tableCmd.ExecuteNonQuery();

					return perk;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Equipment not added");
			}
		}

		public Perk UpdatePerk(Perk perk)
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

		public Perk DeletePerk(int perkID)
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
