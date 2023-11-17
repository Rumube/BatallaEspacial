namespace Common
{
    public interface EventQueue
    {
        void EnqueueEvent(EventData eventData);
        void Subscribe(EventIds eventId, EventObserver eventObserver);
        void Unsubscribe(EventIds eventId, EventObserver eventObserver);
    }
}