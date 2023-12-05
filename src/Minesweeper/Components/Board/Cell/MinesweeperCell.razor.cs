using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components.Utilities;

namespace Pk9r.Minesweeper.Components;
public partial class MinesweeperCell
{
    protected string? ClassValue => new CssBuilder(Class)
        .AddClass("cell")
        .AddClass(Value.ToAttributeValue())
        .Build();

    [Parameter]
    public Cell Value { get; set; } = Cell.CellUp;
}