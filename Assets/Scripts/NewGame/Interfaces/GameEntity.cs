using UnityEngine;

namespace Game
{

    /// <summary>
    /// A Positionable object can be set a Position in the world.
    /// </summary>
    public interface Positionable
    {
        Vector3 Position { get; set; }
        float XPosition { get; set; }
        float YPosition { get; set; }
    }

    public class GameObjectPositioner : Positionable
    {
        public Vector3 Position { get { return gameObject.transform.position; } set { gameObject.transform.position = value; } }
        public float XPosition
        {
            get
            {
                return gameObject.transform.position.x;
            }
            set
            {
                Vector3 newPosition = gameObject.transform.position;
                newPosition.x = value;
                gameObject.transform.position = newPosition;
            }
        }

        public float YPosition
        {
            get
            {
                return gameObject.transform.position.y;
            }
            set
            {
                Vector3 newPosition = gameObject.transform.position;
                newPosition.y = value;
                gameObject.transform.position = newPosition;
            }
        }

        private GameObject gameObject = null;

        public GameObjectPositioner(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }

    /// <summary>
    /// A Speedable object can be moved by setting a Velocity.
    /// </summary>
    public interface Speedable
    {
        Vector2 Velocity { get; set; }
    }

    public class Rigidbody2DSpeeder : Speedable
    {
        public Vector2 Velocity { get { return rigidbody2D.velocity; } set { rigidbody2D.velocity = value; } }

        private Rigidbody2D rigidbody2D = null;

        public Rigidbody2DSpeeder(GameObject gameObject) : this(gameObject.GetComponent<Rigidbody2D>()) {}

        public Rigidbody2DSpeeder(Rigidbody2D rigidBody2D)
        {
            this.rigidbody2D = rigidBody2D;
        }
    }

    /// <summary>
    /// A Eliminable object can be eliminated from the game scene. This doesn't necesarily mean the object is destroyed.
    /// </summary>
    public interface Eliminable
    {
        void Eliminate();
    }

    public class GameObjectEliminator : Eliminable
    {
        private GameObject gameObject = null;

        public GameObjectEliminator(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void Eliminate()
        {
            GameObject.Destroy(gameObject);
        }
    }

    /// <summary>
    /// A ColorTintable object is able to change the tint color being displayed.
    /// </summary>
    public interface ColorTintable
    {
        Color TintColor { get; set; }
    }

    public class SpriteRendererColorTinter : ColorTintable
    {
        public Color TintColor { get { return spriteRenderer.color; } set { spriteRenderer.color = value; } }
        private SpriteRenderer spriteRenderer = null;

        public SpriteRendererColorTinter(GameObject gameObject) : this(gameObject.GetComponent<SpriteRenderer>()) {}

        public SpriteRendererColorTinter(SpriteRenderer spriteRenderer)
        {
            this.spriteRenderer = spriteRenderer;
        }
    }

    /// <summary>
    /// A ObjectCreatable object is able to create new objects.
    /// </summary>
    public interface ObjectCreatable
    {
        T CreateGameObjectFromPrefab<T>(GameObject prefab, Vector3 position);
    }

}

