using FilmManagement.Application.Common.Dynamic;
using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Purchases.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagement.Application.Features.Purchases.Queries.GetList
{
    public class GetListPurchaseQuerRequest : IRequest<ApiPagedResponse<GetListPurchaseResponseDto>>
    {
        public int Start { get; set; } = 0;
        public int Limit { get; set; } = 10; 
        public DynamicQuery? DynamicQuery { get; set; }
    }
}
