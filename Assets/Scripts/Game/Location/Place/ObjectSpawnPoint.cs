using Db.Object;
using UnityEngine;

namespace Game.Location.Place {
	public class ObjectSpawnPoint : MonoBehaviour {
		[SerializeField] private EObjectType objectType;

#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			var size = Vector3.one;
			var position = transform.position + Vector3.up * size.magnitude / 2;
			Gizmos.color = Color.green;
			Gizmos.DrawWireCube(position, size);
		}
#endif
	}
}