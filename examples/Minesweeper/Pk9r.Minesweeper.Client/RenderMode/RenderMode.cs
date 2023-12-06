using Microsoft.AspNetCore.Components.Web;

namespace Pk9r.Minesweeper;
public static class RenderMode 
{
    public static InteractiveServerRenderMode InteractiveServerWithoutPrerendering { get; } = new InteractiveServerRenderMode(prerender: false);
}
