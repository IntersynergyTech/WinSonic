using CommunityToolkit.Mvvm.Messaging;
using WinSonic.Gui.Common.Messages;

namespace WinSonic.Gui.Common.GuiServices;

public class TrackContextService
{
    private static object? _registeredQueueRecipient;
    private static object? _registeredPlayRecipient;

    public static void RegisterQueueHandler(object recipient, Action<TrackContextQueueMessage> action)
    {
        if (_registeredQueueRecipient != null)
        {
            WeakReferenceMessenger.Default.Unregister<TrackContextQueueMessage>(_registeredQueueRecipient);
        }

        _registeredQueueRecipient = recipient;
        WeakReferenceMessenger.Default.Register<TrackContextQueueMessage>(recipient, (r, m) => action(m));
    }

    public static void RegisterPlayHandler(object recipient, Action<TrackContextPlayMessage> action)
    {
        if (_registeredPlayRecipient != null)
        {
            WeakReferenceMessenger.Default.Unregister<TrackContextPlayMessage>(_registeredPlayRecipient);
        }

        _registeredPlayRecipient = recipient;
        WeakReferenceMessenger.Default.Register<TrackContextPlayMessage>(recipient, (r, m) => action(m));
    }

    public static void SendQueueRequest(TrackContextQueueMessage message)
    {
        WeakReferenceMessenger.Default.Send(message);
    }

    public static void SendPlayRequest(TrackContextPlayMessage message)
    {
        WeakReferenceMessenger.Default.Send(message);
    }
}
