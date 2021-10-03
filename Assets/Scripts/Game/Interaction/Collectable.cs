using Db.Object;
using Game.Inventory;
using UnityEngine;

namespace Game.Interaction {
	public class Collectable : MonoBehaviour {
		[Header("Dependent objects")]
		[SerializeField] private SphereCollider sphereCollider;

		[Header("Settings")]
		[SerializeField] private EObjectType objectType;

		[SerializeField] private float radius;

		private void Start() {
			sphereCollider.radius = radius;
		}

		private void OnTriggerEnter(Collider other) {
			var successfullyCollected = false;
			if (other.TryGetComponent(out IInventory inventory)) {
				successfullyCollected = inventory.TryAddItem(objectType);
			}

			if (successfullyCollected) {
				Destroy(gameObject);
			}
		}

#if UNITY_EDITOR
		private void OnDrawGizmos() {
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere(transform.position, radius);
		}
#endif
	}
}