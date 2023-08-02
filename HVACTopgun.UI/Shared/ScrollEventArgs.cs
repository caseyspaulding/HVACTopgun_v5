using Microsoft.AspNetCore.Components;

namespace HVACTopgun.UI.Shared;
public class ScrollEventArgs : EventArgs
{
    public int ScrollPosition { get; set; } = 0;
}

[EventHandler("onscrollcustom", typeof(ScrollEventArgs), enableStopPropagation: true, enablePreventDefault: true)]
public static class EventHandlers
{
}