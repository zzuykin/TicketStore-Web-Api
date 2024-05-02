
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketStore.Storage.Models;

[Index(nameof(IsnUser))]
public class Orders
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnNode { get; set; }

    [ForeignKey(nameof(User))]
    public Guid IsnUser { get; set; }

    [Required]
    public int OrderNum { get; set; }

    [Required, MaxLength(255)]
    public string ConcertName { get; set; }

    [Required, MaxLength(255)]
    public string OrderStatus { get; set; }

    public virtual User User { get; set; }
}

