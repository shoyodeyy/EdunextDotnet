using Edunext.Core.Common;

namespace Edunext.Core.Entities;

public class MenuCategory : BaseEntity
{
    public string Name { get; private set; } = default!;

    public bool IsActive { get; private set; } = true;

    private MenuCategory() { }

    public MenuCategory(string name) { Name = name; }

    public void Disable() 
    {
        IsActive = false;
    }
}