using UnityEngine;

namespace Game
{
    public interface GameEntity
    {
        Vector3 Position { get; set; }
        Vector3 Velocity { get; set; }
        void Destroy();
        T CreateGameObjectFromPrefab<T>(GameObject prefab, Vector3 position);
    }
}

