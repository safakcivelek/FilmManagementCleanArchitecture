using FilmManagement.Application.Common.Responses;
using FilmManagement.Application.Features.Purchases.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagement.Application.Features.Purchases.Commands.Create
{
    public class CreatePurchaseCommandRequest : IRequest<ApiResponse<CreatePurchaseResponseDto>>
    {
        public Guid FilmId { get; set; }
        public Guid UserId { get; set; }
    }
}
