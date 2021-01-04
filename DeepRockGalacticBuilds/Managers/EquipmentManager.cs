using DeepRockGalacticBuilds.Models;
using DeepRockGalacticBuilds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Managers
{
	public class EquipmentManager : IEquipmentManager
	{
		private IEquipmentRepository EquipmentRepository { get; set; }

		public EquipmentManager(IEquipmentRepository equipmentRepository)
		{
			EquipmentRepository = equipmentRepository;
		}

		public List<Equipment> GetAllEquipment()
		{
			var equipment = EquipmentRepository.GetAllEquipment();
			return equipment;
		}
		public Equipment GetEquipmentByID(int equipmentID)
		{
			var equipment = EquipmentRepository.GetEquipmentByID(equipmentID);
			return equipment;
		}
		public Equipment AddEquipment(Equipment equipment)
		{
			var result = EquipmentRepository.AddEquipment(equipment);
			return result;
		}
		public Equipment UpdateEquipment(Equipment equipment)
		{
			Equipment dwarf = EquipmentRepository.UpdateEquipment(equipment);
			return dwarf;
		}
		public Equipment DeleteEquipment(int equipmentID)
		{
			Equipment dwarf = EquipmentRepository.DeleteEquipment(equipmentID);
			return dwarf;
		}
	}
}
