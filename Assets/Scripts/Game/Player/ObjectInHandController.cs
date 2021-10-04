using Db.Object;
using Game.Input;
using UnityEngine;

namespace Game.Player {
	public class ObjectInHandController : MonoBehaviour {
		[SerializeField] private Inventory.Implementation.Inventory inventory;

		public EObjectType ObjectInHand { get; private set; }
		private int _inventoryIndexOfObject;

		private void Start() {
			SetObjectInHand(EObjectType.None);
			inventory.ItemAdded += AddItemIfHandEmpty;
			inventory.ItemRemoved += CheckHandForRemovedItem;
		}

		private void Update() {
			if (InputController.Instance.SwitchToLeftItem) {
				SwitchItemByOffset(-1);
			}
			else if (InputController.Instance.SwitchToRightItem) {
				SwitchItemByOffset(1);
			}
		}

		private void OnDestroy() {
			inventory.ItemAdded -= AddItemIfHandEmpty;
			inventory.ItemRemoved -= CheckHandForRemovedItem;
		}

		public void DeleteObjectInHand() {
			inventory.TryRemoveItem(ObjectInHand);
		}

		private void SwitchItemByOffset(int offset) {
			var items = inventory.GetInventoryItems();
			var itemsCount = items.Count;
			if (itemsCount != 0) {
				var rowIndex = _inventoryIndexOfObject + offset;
				var newIndex = rowIndex >= 0 ? rowIndex % itemsCount : rowIndex + itemsCount;
				SetObjectInHand(items[newIndex].ObjectType);
			}
			else {
				SetObjectInHand(EObjectType.None);
			}
		}

		private void CheckHandForRemovedItem(EObjectType removedItemObjectType) {
			if (inventory.HasItem(removedItemObjectType)) {
				return;
			}

			inventory.TryGetAnyItem(out var inventoryItem);
			var objectInHand = inventoryItem?.ObjectType ?? EObjectType.None;
			SetObjectInHand(objectInHand);
		}

		private void AddItemIfHandEmpty(EObjectType addedItemObjectType) {
			if (ObjectInHand == EObjectType.None) {
				SetObjectInHand(addedItemObjectType);
			}
		}

		private void SetObjectInHand(EObjectType objectType) {
			_inventoryIndexOfObject = objectType == EObjectType.None ? -1 : inventory.GetItemIndex(objectType);
			ObjectInHand = objectType;
		}
	}
}