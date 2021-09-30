using Db.Object;
using UnityEngine;

namespace Game.Player {
	public class ItemInHand : MonoBehaviour {
		[Header("Dependent objects")]
		[SerializeField] private Inventory.Impl.Inventory inventory;

		public EObjectType ObjectInHand { get; private set; }

		private void Start() {
			inventory.AddedItem += UpdateHand;
			inventory.RemovedItem += CheckHand;
		}

		private void CheckHand(EObjectType objectType) {
			if (inventory.HasItem(objectType)) {
				return;
			}

			var inventoryItems = inventory.GetInventoryItems();
			ObjectInHand = inventoryItems.Count > 0 ? inventoryItems[0].ObjectType : EObjectType.None;
		}

		private void UpdateHand(EObjectType objectType) {
			if (ObjectInHand == EObjectType.None) {
				ObjectInHand = objectType;
			}
		}
	}
}