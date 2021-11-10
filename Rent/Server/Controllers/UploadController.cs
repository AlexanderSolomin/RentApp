using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Rent.Server.Controllers
{
	[Authorize]
	[Route("api/upload/")]
	[ApiController]
	public class UploadController : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> Upload()
		{
			try
			{
				var formCollection = await Request.ReadFormAsync();
				var file = formCollection.Files[0];
				var folderName = Path.Combine("StaticFiles", "Img");
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

					if (file.Length > 0)
					{
						var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
						var fullPath = Path.Combine(pathToSave, fileName);
						var dbPath = Path.Combine(folderName, fileName);
						using (var stream = new FileStream(fullPath, FileMode.Create))
						{
							file.CopyTo(stream);
						}
						return Ok(dbPath);
					}
					else
					{
						return BadRequest();
					}

			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex}");
			}
		}
	}
}
