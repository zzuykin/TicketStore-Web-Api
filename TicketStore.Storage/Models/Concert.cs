
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TicketStore.Storage.Models;

[Index(nameof(ConcertName))]
[Keyless]
public class Concert
{
    [Required]
    public int Number { get; set; }

    [Required, MaxLength(255)]
    public string ConcertName { get; set; }

    [Required]
    public int AvailableTickets { get; set; }

    [Required]
    public int TicketPrice { get; set; }

    //public virtual Orders Orders { get; set; }
}