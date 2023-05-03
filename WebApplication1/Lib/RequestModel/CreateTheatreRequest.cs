using Lib.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.RequestModel
{
    public class CreateTheatreRequest : IRequest<CreateTheatreResponse>
    {
        public string Name { get; set; } = string.Empty;

        public int CinemaId { get; set; }

        public int TheatreTypeId { get; set; }
    }
}
