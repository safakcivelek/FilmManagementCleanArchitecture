using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmManagement.Application.Features.Purchases.Dtos
{
    public class GetListPurchaseResponseDto
    {
        public Guid FilmId { get; set; }
        public Guid UserId { get; set; }
        public string FilmName { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
