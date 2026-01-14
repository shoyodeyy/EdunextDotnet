using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edunext.Application.DTOs.MenuCategory;

public class MenuCategoryDto
{
    public Guid MenuCateId { get; set; }
    public string Name { get; set; } = default!;
}
