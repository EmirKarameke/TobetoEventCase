using Microsoft.AspNetCore.Components;

namespace EventCase.Blazor.Web.Pages
{
    public partial class EventDetailPage
    {
        [Parameter] public string? EventId { get; set; }
    }
}
