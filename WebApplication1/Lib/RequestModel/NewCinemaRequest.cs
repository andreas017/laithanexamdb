using Lib.ResponseModel;
using MediatR;
using Minio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.RequestModel
{
    public class NewCinemaRequest : IRequest<NewCinemaResponse>
    {
        public string Name { get; set; } = "";

        public string Address { get; set; } = "";
    }
}
