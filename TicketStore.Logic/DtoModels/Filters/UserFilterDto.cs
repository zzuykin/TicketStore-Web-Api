using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketStore.Logic.DtoModels.Filters
{
    public sealed record UserFilterDto
    {
        public string Code { get; init; }
    }
}
