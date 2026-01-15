using Edunext.Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edunext.Application.DTOs.Table;

public class TableWithOrdersDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = default!;
    public bool IsActive { get; set; }

    public int TotalOrders => Orders.Count;
    public decimal TotalRevenue => Orders.Sum(x => x.TotalPrice);

    public List<OrderWithDetailsDto> Orders { get; set; } = new();
}
