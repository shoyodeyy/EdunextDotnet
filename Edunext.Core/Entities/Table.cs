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

    public void Disable()
    {
        IsActive = false;
    }

    public void UpdateCode(string requestCode)
    {
        if (string.IsNullOrWhiteSpace(requestCode))
        {
            throw new ArgumentNullException("Code cannot be empty.");
        }
        
        Code = requestCode;
    }

    public void Enable()
    {
        IsActive = true;
    }
}