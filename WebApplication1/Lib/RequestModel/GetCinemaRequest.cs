﻿using Lib.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.RequestModel
{
    public class GetCinemaRequest : IRequest<GetCinemaOffsetPaginationResponse>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
