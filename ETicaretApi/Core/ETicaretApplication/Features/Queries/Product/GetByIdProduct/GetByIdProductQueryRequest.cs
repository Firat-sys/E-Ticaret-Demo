﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApplication.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryRequest :IRequest<GetByIdProductQueryResponse>
    {
        public string id { get; set; }
    }
}
