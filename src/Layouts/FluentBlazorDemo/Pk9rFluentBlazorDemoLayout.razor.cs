using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace Pk9r.Blazor.Layouts.FluentBlazorDemo.Components;

public partial class Pk9rFluentBlazorDemoLayout
{
    private string? _version;

    [Parameter]
    public RenderFragment? NavMenuContent { get; set; } = default!;

    [Parameter]
    public RenderFragment? Body { get; set; } = default!;

    protected override void OnInitialized()
    {
        _version = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

        //OfficeColor[] colors = Enum.GetValues<OfficeColor>();
        //_selectedColorOption = colors[new Random().Next(colors.Length)];

        //GlobalState.SetColor(_selectedColorOption.ToAttributeValue());

        //_prevUri = NavigationManager.Uri;
        //NavigationManager.LocationChanged += LocationChanged;
    }
}