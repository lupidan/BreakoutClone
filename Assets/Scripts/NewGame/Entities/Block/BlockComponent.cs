using UnityEngine;
using System.Collections;

namespace Game
{
    public class BlockComponent : MonoBehaviour
    {

        /// <summary>
        /// The GameObject tag that all Block elements should have.
        /// </summary>
        public static string Tag = "Block";

        public DefaultBlock block = new DefaultBlock();

        /// <summary>
        /// The main sprite renderer of the Block Game Object.
        /// </summary>
        private SpriteRenderer spriteRenderer;

        void Awake()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}

