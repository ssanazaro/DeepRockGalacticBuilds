using DeepRockGalacticBuilds.Models;
using DeepRockGalacticBuilds.Repositories;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Managers
{
	public class DwarfManager : IDwarfManager
	{
		private IDwarfRepository DwarfRepository { get; set; }

		public DwarfManager(IDwarfRepository dwarfRepository)
		{
			DwarfRepository = dwarfRepository;
		}

		public List<Dwarf> GetAllDwarves()
		{
			var dwarves = DwarfRepository.SelectDwarves();
			return dwarves;
		}
		public Dwarf GetDwarfById(int id)
		{
			Dwarf dwarf = DwarfRepository.SelectDwarfById(id);
			return dwarf;
		}
		public bool AddDwarf(Dwarf dwarf)
		{
			bool result = DwarfRepository.AddDwarf(dwarf);
			return result;
		}
		public bool UpdateDwarf(Dwarf dwarf)
		{
			bool result = DwarfRepository.UpdateDwarf(dwarf);
			return result;
		}
		public bool DeleteDwarf(int id)
		{
			bool result = DwarfRepository.DeleteDwarf(id);
			return result;
		}
	}
}
