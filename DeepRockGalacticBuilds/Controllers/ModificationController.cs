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
	public class ModificationController : Controller
	{
		private IModificationManager ModificationManager { get; set; }

		public ModificationController(IModificationManager modificationManager)
		{
			ModificationManager = modificationManager;
		}

		[HttpGet("")]
		[ProducesResponseType(typeof(Modification), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetAllModifications()
		{
			try
			{
				List<Modification> result = ModificationManager.GetAllModifications();

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
		[ProducesResponseType(typeof(Modification), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetModificationByID(int modificationID)
		{
			try
			{
				var result = ModificationManager.GetModificationByID(modificationID);

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
		[ProducesResponseType(typeof(Modification), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult AddModification([FromBody] Modification modification)
		{
			try
			{
				var result = ModificationManager.AddModification(modification);

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
		[ProducesResponseType(typeof(Modification), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult UpdateModification(Modification modification)
		{
			try
			{
				var result = ModificationManager.UpdateModification(modification);

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
		[ProducesResponseType(typeof(Modification), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteModification(int id)
		{
			try
			{
				var result = ModificationManager.DeleteModification(id);

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
