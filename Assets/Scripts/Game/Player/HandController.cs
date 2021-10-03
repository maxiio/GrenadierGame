using Db.Object;
using UnityEngine;

namespace Game.Player {
	public class HandController : MonoBehaviour {
		[SerializeField] private Inventory.Impl.Inventory inventory;

		public EObjectType ObjectInHand { get; private set; }

		private void Start() {
			ObjectInHand = EObjectType.None;
			inventory.ItemAdded += AddItemIfHandEmpty;
			inventory.ItemRemoved += CheckHandForRemovedItem;
		}

		private void CheckHandForRemovedItem(EObjectType removedItemObjectType) {
			if (inventory.HasItem(removedItemObjectType)) {
				return;
			}

			inventory.TryGetAnyItem(out var inventoryItem);
			ObjectInHand = inventoryItem?.ObjectType ?? EObjectType.None;
		}

		private void AddItemIfHandEmpty(EObjectType addedItemObjectType) {
			if (ObjectInHand == EObjectType.None) {
				ObjectInHand = addedItemObjectType;
			}
		}
	}
}