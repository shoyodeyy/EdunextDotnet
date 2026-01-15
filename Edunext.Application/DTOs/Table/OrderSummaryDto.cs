using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edunext.Application.DTOs.Table;
public class OrderSummaryDto
{
    public Guid OrderId { get; set; }
    public string Status { get; set; } = default!;
    public DateTime CreateAt { get; set; }

    public int TotalItems { get; set; }
    public decimal TotalPrice { get; set; }

    public List<OrderItemSummaryDto> Items { get; set; } = new();
}
