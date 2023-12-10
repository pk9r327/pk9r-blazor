using Microsoft.AspNetCore.Components.Web;

namespace Pk9r.Blazor;
public static class RenderMode
{
    public static InteractiveServerRenderMode InteractiveServerWithoutPrerendering { get; } = new InteractiveServerRenderMode(prerender: false);
}
