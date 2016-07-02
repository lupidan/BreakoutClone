using UnityEngine;

namespace Game
{
    public interface Positionable
    {
        Vector3 Position { get; set; }
        Vector2 Velocity { get; set; }
    }

    public interface Destroyable
    {
        void Destroy();
    }

    public interface ObjectCreatable
    {
        T CreateGameObjectFromPrefab<T>(GameObject prefab, Vector3 position);
    }

    

}

