using DeepRockGalacticBuilds.Managers;
using DeepRockGalacticBuilds.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepRockGalacticBuilds.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EquipmentController : Controller
	{
		private IEquipmentManager EquipmentManager { get; set; }

		public EquipmentController(IEquipmentManager equipmentManager)
		{
			EquipmentManager = equipmentManager;
		}

		[HttpGet("")]
		[ProducesResponseType(typeof(List<Equipment>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetAllEquipment()
		{
			try
			{
				List<Equipment> equipment = EquipmentManager.GetAllEquipment();

				if (equipment == null)
				{
					return NotFound("No Equipment Found");
				}

				return Ok(equipment);
			}

			catch (Exception ex)
			{
				//Logger.Error(ex, "An exception occurred while retirving trivia questions");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(Equipment), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetEquipmentByID(int equipmentID)
		{
			try
			{
				var equipment = EquipmentManager.GetEquipmentByID(equipmentID);

				if (equipment == null)
				{
					return NotFound("Equipment not found");
				}

				return Ok(equipment);
			}

			catch (Exception ex)
			{
				//Logger.Error(ex, "An exception occurred while retirving trivia questions");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult AddEquipment([FromBody] Equipment equipment)
		{
			try
			{
				var result = EquipmentManager.AddEquipment(equipment);

				if (result == false)
				{
					return NotFound("Equipment not added");
				}

				return Ok(result);
			}

			catch (Exception ex)
			{
				//Logger.Error(ex, "An exception occurred while retirving trivia questions");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPut("")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult UpdateEquipment([FromBody] Equipment equipment)
		{
			try
			{
				var result = EquipmentManager.UpdateEquipment(equipment);

				if (result == false)
				{
					return NotFound("Equipment not updated");
				}

				return Ok(result);
			}

			catch (Exception ex)
			{
				//Logger.Error(ex, "An exception occurred while retirving trivia questions");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpDelete("")]
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteEquipment(int id)
		{
			try
			{
				var result = EquipmentManager.DeleteEquipment(id);

				if (result == false)
				{
					return NotFound("Equipment not deleted");
				}

				return Ok(result);
			}

			catch (Exception ex)
			{
				//Logger.Error(ex, "An exception occurred while retirving trivia questions");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
