using Db.Object;
using Game.Input;
using UnityEngine;

namespace Game.Player {
	public class ObjectInHandController : MonoBehaviour {
		[SerializeField] private Inventory.Implementation.Inventory inventory;

		public EObjectType ObjectInHand { get; private set; }
		private int _inventoryIndexOfObject;

		private void Start() {
			ObjectInHand = EObjectType.None;
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

		private void SwitchItemByOffset(int offset) {
			
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

		private void SetObjectInHand(EObjectType objectType, int index) {
			_inventoryIndexOfObject = index;
			ObjectInHand = objectType;
		}
	}
}