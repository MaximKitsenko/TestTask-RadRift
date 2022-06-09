namespace RadRiftGame.Infrastructure
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : Event;
    }
}