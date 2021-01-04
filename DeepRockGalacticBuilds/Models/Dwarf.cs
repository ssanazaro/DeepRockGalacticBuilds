using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Models
{
	public class Dwarf
	{
		public int DwarfID { get; set; }
		public string DwarfName { get; set; }
		public List<Equipment> DwarfEquipment { get; set; }
		public List<Perk> DwarfPerks { get; set; }

	}
}
