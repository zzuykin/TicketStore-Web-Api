
using System.ComponentModel.DataAnnotations;

namespace TicketStore_Web_Api.Features.DtoModels.Order
{
    public sealed record EditOrder
    {
        public Guid IsnNode { get; init; }

        public Guid IsnUser { get; init; }

        [Required]
        public int OrderNum { get; init; }

        [Required, MaxLength(255)]
        public string ConcertName { get; init; }

        [Required, MaxLength(255)]
        public string OrderStatus { get; init; }


    }
}
