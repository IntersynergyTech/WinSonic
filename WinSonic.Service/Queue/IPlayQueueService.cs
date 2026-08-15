namespace WinSonic.Service.Queue;

public interface IPlayQueueService
{
    public object RestoreQueue();
    public object SaveQueue(object queue);
}
