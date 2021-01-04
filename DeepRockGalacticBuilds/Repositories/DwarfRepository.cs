using DeepRockGalacticBuilds.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Repositories
{
	public class DwarfRepository : IDwarfRepository
	{
		string database = "./DeepRockGalactic.db";
		public List<Dwarf> SelectDwarves()
		{
			List<Dwarf> dwarfs = new List<Dwarf>();
			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "SELECT * FROM Dwarf;";
					var result = tableCmd.ExecuteReader();

					while (result.Read())
					{
						var dwarf = new Dwarf();
						dwarf.DwarfID = Convert.ToInt32(result["DwarfID"]);
						dwarf.DwarfName = result["DwarfName"].ToString();

						dwarfs.Add(dwarf);
					}

					return dwarfs;
				}
			}
			catch (Exception)
			{
				throw;

			}
		}
		public Dwarf SelectDwarfById(int id)
		{
			var dwarf = new Dwarf();

			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "SELECT * FROM Dwarf WHERE name = " + id;
					var result = tableCmd.ExecuteReader();

					while (result.Read())
					{
						dwarf.DwarfID = Convert.ToInt32(result["DwarfID"]);
						dwarf.DwarfName = result["DwarfName"].ToString();
					}
					return dwarf;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public bool AddDwarf(Dwarf dwarf)
		{
			try
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder();
				connectionStringBuilder.DataSource = database;

				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "INSERT INTO Dwarf (DwarfName) VALUES (@dwarf);";
					tableCmd.Parameters.AddWithValue("@dwarf", dwarf.DwarfName);
					tableCmd.ExecuteNonQuery();

					return true;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Dwarf not added");
			}
		}

		public bool UpdateDwarf(Dwarf dwarf)
		{
			var connectionStringBuilder = new SqliteConnectionStringBuilder();
			connectionStringBuilder.DataSource = database;

			try
			{
				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "UPDATE Dwarf SET DwarfName = @DwarfName WHERE DwarfID = @DwarfID;";
					tableCmd.Parameters.AddWithValue("@DwarfName", dwarf.DwarfName);
					tableCmd.Parameters.AddWithValue("@DwarfID", dwarf.DwarfID);
					tableCmd.ExecuteNonQuery();
				}
				return true;
			}
			catch (SqliteException ex)
			{
				return false;
			}
		}

		public bool DeleteDwarf(int id)
		{
			var connectionStringBuilder = new SqliteConnectionStringBuilder();
			connectionStringBuilder.DataSource = database;

			try
			{
				using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
				{
					connection.Open();

					var tableCmd = connection.CreateCommand();
					tableCmd.CommandText = "DELETE FROM Dwarf WHERE DwarfID = @DwarfID;";
					tableCmd.Parameters.AddWithValue("@DwarfID", id);
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
