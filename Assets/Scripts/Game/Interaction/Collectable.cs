using Game.EntityComponent;
using Game.Inventory;
using UnityEngine;

namespace Game.Interaction {
	public class Collectable : MonoBehaviour {
		[SerializeField] private ObjectTypeHolder objectTypeHolder;

		private void OnTriggerEnter(Collider other) {
			var successfullyCollected = false;
			if (other.TryGetComponent(out IInventory inventory)) {
				successfullyCollected = inventory.TryAddItem(objectTypeHolder.Get());
			}

			if (successfullyCollected) {
				Destroy(gameObject);
			}
		}
	}
}