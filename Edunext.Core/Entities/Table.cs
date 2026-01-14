using System.ComponentModel.DataAnnotations;
using Edunext.Core.Common;

namespace Edunext.Core.Entities;

public class Table : BaseEntity
{
    public string Code { get; private set; } = default!;
    public bool IsActive { get; private set; } = true;

    private Table()
    {
    }

    public Table(string code)
    {
        Code = code;
    }

    public void UpdateCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ValidationException("Code cannot be empty.");
        }

        Code = code.Trim();
    }

    public void Disable()
    {
        IsActive = false;
    }

    public void Enable()
    {
        IsActive = true;
    }
}