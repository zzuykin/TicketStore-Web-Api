
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TicketStore.Storage.Models;

[Index(nameof(ConcertName))]
public class Concert
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid IsnNode { get; set; }

    [Required, MaxLength(255)]
    public string ConcertName { get; set; }

    [Required]
    public int AvailableTickets { get; set; }

    [Required]
    public int TicketPrice { get; set; }

    //public virtual Orders Orders { get; set; }
}