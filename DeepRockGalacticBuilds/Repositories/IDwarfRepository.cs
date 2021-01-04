using DeepRockGalacticBuilds.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Repositories
{
	public interface IDwarfRepository
	{
		public List<Dwarf> SelectDwarves();

		public Dwarf SelectDwarfById(int id);
		public bool AddDwarf(Dwarf dwarf);
		public bool UpdateDwarf(Dwarf dwarf);
		public bool DeleteDwarf(int id);
	}
}
