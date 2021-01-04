using DeepRockGalacticBuilds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Repositories
{
	public interface IEquipmentRepository
	{
		public List<Equipment> GetAllEquipment();
		public Equipment GetEquipmentByID(int equipmentID);
		public bool AddEquipment(Equipment equipment);
		public bool UpdateEquipment(Equipment equipment);
		public bool DeleteEquipment(int equipmentID);
	}
}
