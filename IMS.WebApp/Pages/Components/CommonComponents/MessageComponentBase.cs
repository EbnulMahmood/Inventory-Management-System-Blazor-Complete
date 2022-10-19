using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Pages.Components.CommonComponents
{
    public class MessageComponentBase : ComponentBase
    {
        [Parameter]
        public string Message { get; set; } = string.Empty;
        [Parameter]
        public string? Type { get; set; } = null;
    }
}
