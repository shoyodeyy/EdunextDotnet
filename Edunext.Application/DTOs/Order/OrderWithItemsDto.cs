using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edunext.Application.DTOs.Order;

public class OrderWithItemsDto
{
    public Guid Id { get; set; }
    public string Status { get; set; } = default!;
    public DateTime CreateAt { get; set; }
    public decimal TotalPrice => Items.Sum(x => x.TotalPrice);
    public List<OrderItemDto> Items { get; set; } = new();
}
