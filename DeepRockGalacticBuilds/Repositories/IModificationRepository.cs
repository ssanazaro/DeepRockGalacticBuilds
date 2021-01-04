using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeepRockGalacticBuilds.Models;

namespace DeepRockGalacticBuilds.Repositories
{
	public interface IModificationRepository
	{
		public List<Modification> GetAllModifications();
		public Modification GetModificationByID(int modificationID);
		public bool AddModification(Modification modification);
		public bool UpdateModification(Modification modification);
		public bool DeleteModification(int modificationID);

	}
}
