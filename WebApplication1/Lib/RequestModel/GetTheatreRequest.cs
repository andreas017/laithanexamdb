﻿using Lib.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.RequestModel
{
    public class GetTheatreRequest : IRequest<List<GetTheatreResponse>>
    {
    }
}
