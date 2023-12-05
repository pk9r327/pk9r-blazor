using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components.Utilities;

namespace Pk9r.Minesweeper.Components;
public partial class MinesweeperNumberBox
{
    [Parameter]
    public string Values { get; set; } = "---";

    public string? GetClassValue(int index)
    {
        return new CssBuilder()
            .AddClass("counter")
            .AddClass($"counter{Values[index]}")
            .Build();
    }
}