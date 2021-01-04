using DeepRockGalacticBuilds.Models;
using System.Collections.Generic;

namespace DeepRockGalacticBuilds.Managers
{
	public interface IEquipmentManager
	{
		public List<Equipment> GetAllEquipment();
		public Equipment GetEquipmentByID(int equipmentID);
		public Equipment AddEquipment(Equipment equipment);
		public Equipment UpdateEquipment(Equipment equipment);
		public Equipment DeleteEquipment(int equipmentID);
	}
}
