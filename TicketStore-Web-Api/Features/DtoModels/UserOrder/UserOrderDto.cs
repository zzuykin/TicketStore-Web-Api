
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TicketStore_Web_Api.Features.DtoModels.UserOrder;

public sealed record UserOrderDto
{

    [Required]
    public int OrderNum { get; init; }

    [Required, MaxLength(255)]
    public string ConcertName { get; init; }

    [Required, MaxLength(255)]
    public string OrderStatus { get; init; }

    [Required]
    public int TicketPrice { get; init; }
    public Guid IsnUser { get; init; }

    [Required, MaxLength(255)]
    public string ClientName { get; init; }

    [Required, MaxLength(255)]
    public string ClientSurname { get; init; }

    [Required, MaxLength(255)]
    public string ClientEmail { get; init; }

    [MaxLength(255)]
    [DisplayName("Отчество")]
    [DefaultValue("Отсутствует")]
    public string ClientLastName { get; init; }
}
