using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketStore.Logic.DtoModels.Filters
{
    public sealed record UserFilterDto
    {
        public string ClientName { get; init; }
        public string UserName { get; init; }
		public string ClientEmail { get; init; }

		public string ClientLastName { get; init; }
	}
}
