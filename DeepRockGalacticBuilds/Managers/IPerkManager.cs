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
		public Perk AddPerk(Perk perk);
		public Perk UpdatePerk(Perk perk);
		public Perk DeletePerk(int perkID);
	}
}
