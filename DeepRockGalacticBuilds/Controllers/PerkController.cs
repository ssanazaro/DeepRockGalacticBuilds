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
	public class PerkController : Controller
	{
		private IPerkManager PerkManager { get; set; }

		public PerkController(IPerkManager perkManager)
		{
			PerkManager = perkManager;
		}

		[HttpGet("")]
		[ProducesResponseType(typeof(Perk), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetAllPerks()
		{
			try
			{
				List<Perk> result = PerkManager.GetAllPerks();

				if (result == null)
				{
					return NotFound("Requested trivia question does not exist");
				}

				return Ok(result);
			}

			catch (Exception ex)
			{
				//Logger.Error(ex, "An exception occurred while retirving trivia questions");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(Perk), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetPerkByID(int modificationID)
		{
			try
			{
				var result = PerkManager.GetPerkByID(modificationID);

				if (result == null)
				{
					return NotFound("Requested trivia question does not exist");
				}

				return Ok(result);
			}

			catch (Exception ex)
			{
				//Logger.Error(ex, "An exception occurred while retirving trivia questions");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost]
		[ProducesResponseType(typeof(Perk), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult AddPerk([FromBody] Perk perk)
		{
			try
			{
				var result = PerkManager.AddPerk(perk);

				if (result == null)
				{
					return NotFound("Dwarf not added");
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
		[ProducesResponseType(typeof(Perk), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult UpdatePerk(Perk perk)
		{
			try
			{
				var result = PerkManager.UpdatePerk(perk);

				if (result == null)
				{
					return NotFound("Requested trivia question does not exist");
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
		[ProducesResponseType(typeof(Perk), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeletePerk(int id)
		{
			try
			{
				var result = PerkManager.DeletePerk(id);

				if (result == null)
				{
					return NotFound("Requested trivia question does not exist");
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
