using UnityEngine;
using System.Collections;

namespace ObjectCreatable {

	public class PooledObjectCreator : MonoBehaviour, ObjectCreatable {

		private GameObjectPoolManager poolManager = new GameObjectPoolManager()

		#region ObjectCreatable implementation
		public T CreateGameObjectFromPrefab<T>(GameObject prefab, Vector3 position)
		{
			
		}
		#endregion

	}

}
