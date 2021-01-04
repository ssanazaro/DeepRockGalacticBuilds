using DeepRockGalacticBuilds.Models;
using DeepRockGalacticBuilds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Managers
{
	public class PerkManager : IPerkManager
	{
		private IPerkRepository PerkRepository { get; set; }

		public PerkManager(IPerkRepository perkRepository)
		{
			PerkRepository = perkRepository;
		}
		public List<Perk> GetAllPerks()
		{
			var modification = PerkRepository.GetAllPerks();
			return modification;
		}
		public Perk GetPerkByID(int perkID)
		{
			var perk = PerkRepository.GetPerkByID(perkID);
			return perk;
		}
		public Perk AddPerk(Perk perk)
		{
			var result = PerkRepository.AddPerk(perk);
			return result;
		}
		public Perk UpdatePerk(Perk perk)
		{
			var result = PerkRepository.UpdatePerk(perk);
			return result;
		}
		public Perk DeletePerk(int perkID)
		{
			var perk = PerkRepository.DeletePerk(perkID);
			return perk;
		}
	}
}
