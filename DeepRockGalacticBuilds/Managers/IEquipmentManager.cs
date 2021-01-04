using DeepRockGalacticBuilds.Models;
using System.Collections.Generic;

namespace DeepRockGalacticBuilds.Managers
{
	public interface IEquipmentManager
	{
		public List<Equipment> GetAllEquipment();
		public Equipment GetEquipmentByID(int equipmentID);
		public bool AddEquipment(Equipment equipment);
		public bool UpdateEquipment(Equipment equipment);
		public bool DeleteEquipment(int equipmentID);
	}
}
