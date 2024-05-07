

using System.ComponentModel.DataAnnotations;

namespace TicketStore_Web_Api.Features.DtoModels.UserOrder;

public sealed record EditUserOrder
{
    [Required]
    public int OrderNum { get; init; }

    [Required, MaxLength(255)]
    public string ConcertName { get; init; }

    [Required]
    public int TicketPrice { get; init; }

    [Required, MaxLength(255)]
    public string OrderStatus { get; init; }

    public Guid IsnUser { get; init; }

    [Required, MaxLength(255)]
    public string ClientName { get; init; }

    [Required, MaxLength(255)]
    public string ClientSurname { get; init; }

    [Required, MaxLength(255)]
    public string ClientEmail { get; init; }

    [Required, MaxLength(255)]
    public string ClientLastName { get; init; }
}
