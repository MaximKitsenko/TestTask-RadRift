namespace RadRiftGame.Infrastructure
{
    public interface Handles<T>
    {
        void Handle(T message);
    }
}