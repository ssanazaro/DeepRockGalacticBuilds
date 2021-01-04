using DeepRockGalacticBuilds.Models;
using DeepRockGalacticBuilds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Managers
{
	public class ModificationManager : IModificationManager
	{
		private IModificationRepository ModificationRepository { get; set; }

		public ModificationManager(IModificationRepository modificationRepository)
		{
			ModificationRepository = modificationRepository;
		}

		public List<Modification> GetAllModifications()
		{
			var modification = ModificationRepository.GetAllModifications();
			return modification;
		}
		public Modification GetModificationByID(int modificationID)
		{
			var modification = ModificationRepository.GetModificationByID(modificationID);
			return modification;
		}
		public bool AddModification(Modification modification)
		{
			var result = ModificationRepository.AddModification(modification);
			return result;
		}
		public bool UpdateModification(Modification modification)
		{
			var result = ModificationRepository.UpdateModification(modification);
			return result;
		}
		public bool DeleteModification(int modificationID)
		{
			var result = ModificationRepository.DeleteModification(modificationID);
			return result;
		}
	}
}
