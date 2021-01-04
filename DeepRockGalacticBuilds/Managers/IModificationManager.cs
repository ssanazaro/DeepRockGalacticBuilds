﻿using DeepRockGalacticBuilds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Managers
{
	public interface IModificationManager
	{
		public List<Modification> GetAllModifications();
		public Modification GetModificationByID(int modificationID);
		public Modification AddModification(Modification modification);
		public Modification UpdateModification(Modification modification);
		public Modification DeleteModification(int modificationID);
	}
}
