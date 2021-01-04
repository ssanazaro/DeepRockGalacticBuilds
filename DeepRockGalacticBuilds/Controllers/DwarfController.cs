using DeepRockGalacticBuilds.Managers;
using DeepRockGalacticBuilds.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DeepRockGalacticBuilds.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DwarfController : ControllerBase
	{
		private IDwarfManager DwarfManager { get; set; }

		public DwarfController(IDwarfManager dwarfManager)
		{
			DwarfManager = dwarfManager;
		}
		[HttpGet("")]
		[ProducesResponseType(typeof(List<Dwarf>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetAllDwarves()
		{
			try
			{
				List<Dwarf> dwarves = DwarfManager.GetAllDwarves();

				if (dwarves == null)
				{
					return NotFound("Requested trivia question does not exist");
				}

				return Ok(dwarves);
			}

			catch (Exception ex)
			{
				//Logger.Error(ex, "An exception occurred while retirving trivia questions");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(Dwarf), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetDwarfById(int id)
		{
			try
			{
				var dwarf = DwarfManager.GetDwarfById(id);

				if (dwarf == null)
				{
					return NotFound("Requested trivia question does not exist");
				}

				return Ok(dwarf);
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
		public IActionResult AddDwarf([FromBody]Dwarf dwarf)
		{
			try
			{
				var result = DwarfManager.AddDwarf(dwarf);

				if (result == false )
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
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult UpdateDwarf([FromBody]Dwarf dwarf)
		{
			try
			{
				bool result = DwarfManager.UpdateDwarf(dwarf);

				if (result == false)
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
		[ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteDwarf(int id)
		{
			try
			{
				bool result = DwarfManager.DeleteDwarf(id);

				if (result == false)
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
