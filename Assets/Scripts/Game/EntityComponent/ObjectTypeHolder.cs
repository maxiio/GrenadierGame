using Db.Object;
using UnityEngine;

namespace Game.EntityComponent {
	public class ObjectTypeHolder : MonoBehaviour {
		[SerializeField] private EObjectType objectType;

		private void Awake() {
			if (objectType == EObjectType.None) Debug.LogError($"Not initialized {nameof(ObjectTypeHolder)} in {gameObject}");
		}

		public EObjectType Get() {
			return objectType;
		}
	}
}