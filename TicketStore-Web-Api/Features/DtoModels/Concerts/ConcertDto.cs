

using System.ComponentModel.DataAnnotations;

namespace TicketStore_Web_Api.Features.DtoModels.Concerts;

public sealed record ConcertDto
{
	public int Number { get; set; }

	[Required, MaxLength(255)]
	public string ConcertName { get; set; }

	[Required]
	public int AvailableTickets { get; set; }

	[Required]
	public int TicketPrice { get; set; }
}
