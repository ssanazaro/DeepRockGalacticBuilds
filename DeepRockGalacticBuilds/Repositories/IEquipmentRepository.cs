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
		public Equipment AddEquipment(Equipment equipment);
		public Equipment UpdateEquipment(Equipment equipment);
		public Equipment DeleteEquipment(int equipmentID);
	}
}
