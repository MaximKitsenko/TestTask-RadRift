using System;

namespace RadRiftGame.Contracts.ValueObjects
{
    public class GameRoomId : IEquatable<GameRoomId>
    {
        public Guid Id { get; }

        public static GameRoomId EmptyGameRoomId => emptyGameRoomId;

        protected static GameRoomId emptyGameRoomId = new GameRoomId(Guid.Empty);

        public GameRoomId(Guid id)
        {
            Id = id;
        }

        public bool Equals(GameRoomId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GameRoomId)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}