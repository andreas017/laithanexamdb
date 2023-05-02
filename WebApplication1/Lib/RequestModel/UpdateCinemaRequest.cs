using Lib.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.RequestModel
{
    public class UpdateCinemaRequest : IRequest<UpdateCinemaResponse>
    {
        public int Id { get; set; }

        public string Address { get; set; } = string.Empty;
    }
}
