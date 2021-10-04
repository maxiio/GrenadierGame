using Db.Object;
using Db.Object.Implementation;
using Db.Respawn.Implementation;
using UnityEngine;

namespace Game.Util {
	public class ObjectSpawnPoint : MonoBehaviour {
		[SerializeField] private ObjectBase objectBase;
		[SerializeField] private RespawnBase respawnBase;
		[SerializeField] private EObjectType objectType;

		private GameObject _linkedObject;
		private float _timeAfterDestroyLinkedObject;
		private float _respawnTime;
		private GameObject _objectPrefab;

		private void Start() {
			_objectPrefab = objectBase.GetObjectSettings(objectType).prefab;
			_respawnTime = respawnBase.GetRespawnSettings(objectType).timeToRespawn;
			SpawnObject();
		}

		private void FixedUpdate() {
			if (_linkedObject != null) {
				return;
			}

			_timeAfterDestroyLinkedObject += Time.fixedDeltaTime;
			if (_timeAfterDestroyLinkedObject < _respawnTime) {
				return;
			}

			SpawnObject();
		}

		private void SpawnObject() {
			_timeAfterDestroyLinkedObject = 0;
			_linkedObject = Instantiate(_objectPrefab, transform.position, transform.rotation);
		}

#if UNITY_EDITOR
		private void OnDrawGizmos() {
			var size = Vector3.one;
			var position = transform.position + Vector3.up * size.magnitude / 2;
			Gizmos.color = Color.green;
			Gizmos.DrawWireCube(position, size);
		}
#endif
	}
}