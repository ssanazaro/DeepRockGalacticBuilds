using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Models
{
	public class Equipment
	{
		public int EquipmentID { get; set; }
		public string EquipmentName { get; set; }
		public string EquipmentDescription { get; set; }
		public List<Modification> EquipmentModifications {get;set;}
	}
}
