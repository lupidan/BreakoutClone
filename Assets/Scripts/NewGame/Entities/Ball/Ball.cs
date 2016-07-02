
namespace Game
{
    public interface Ball
    {

        bool IsOnPlay { get; }
        void Reset();
        void Launch(float angle, float speed);
        void CollidedWithBlock(Block block);
        void Destroy();

    }
}

