using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketStore.Storage.Models;

namespace TicketStore_Web_Api.Features.DtoModels.User
{
    public sealed record UserDto
    {
        [Key]
        public Guid IsnNode { get; init; }

        [Required, MaxLength(255)]
        public string ClientName { get; init; }

        [Required, MaxLength(255)]
        public string ClientSurname { get; init; }

        [Required, MaxLength(255)]
        public string ClientEmail { get; init; }

        [Required, MaxLength(255)]
        public string ClientLastName { get; init; }

        [Required, MaxLength(20)]
        public string Code { get; init; }

    }
}
