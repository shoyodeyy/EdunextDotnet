using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edunext.Application.DTOs.Menu;

public record UpdateMenuItemRequest
    ( string? Name, 
      decimal? Price, 
      int? Quantity, 
      string? Description, 
      string? ImageUrl,
      Guid? CategoryId
    );
