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
    public class UserDto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }

        [Required, MaxLength(255)]
        public string ClientName { get; set; }

        [Required, MaxLength(255)]
        public string ClientSurname { get; set; }

        [Required, MaxLength(255)]
        public string ClientEmail { get; set; }

        [Required, MaxLength(255)]
        public string ClientLastName { get; set; }

        [Required]
        public int OrderNum { get; set; }

        [InverseProperty(nameof(Orders.User))]
        public virtual ICollection<Orders> Order { get; set; }
    }
}
