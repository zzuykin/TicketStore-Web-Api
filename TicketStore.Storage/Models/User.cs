
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketStore.Storage.Models;
[Index(nameof(OrderNum))]
public class User{
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