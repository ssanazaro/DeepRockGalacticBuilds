using DeepRockGalacticBuilds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Managers
{
	public interface IPerkManager
	{
		public List<Perk> GetAllPerks();
		public Perk GetPerkByID(int perkID);
		public bool AddPerk(Perk perk);
		public bool UpdatePerk(Perk perk);
		public bool DeletePerk(int perkID);
	}
}
