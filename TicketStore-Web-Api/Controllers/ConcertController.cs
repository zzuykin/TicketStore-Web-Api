

using Microsoft.AspNetCore.Mvc;
using TicketStore_Web_Api.Features.Interfaces.Managers;

namespace TicketStore_Web_Api.Controllers;

[Route("Concert")]
public class ConcertController : Controller
{
	public const string Concerts = "Concert";

	private readonly IConcertManager concertManager;

	public ConcertController(IConcertManager concertManager)
	{
		this.concertManager = concertManager;
	}

	[HttpGet(nameof(Concerts),Name = nameof(Concert))]
	public async Task<ActionResult> Concert()
	{
		var concert = concertManager.GetListConcerts();
		return View(concert);
	}

}
