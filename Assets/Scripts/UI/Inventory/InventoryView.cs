using Db.Inventory;
using Db.Object;
using UnityEngine;

namespace UI.Inventory {
	public class InventoryView : MonoBehaviour {
		[SerializeField] private Game.Inventory.Implementation.Inventory inventory;
		[SerializeField] private InventoryCellsContainer cellsContainer;

		private void Start() {
			inventory.ChangedItem += ChangedItem;
		}

		private void OnDestroy() {
			inventory.ChangedItem -= ChangedItem;
		}

		private void ChangedItem(EObjectType objectType) {
			if (inventory.TryGetItem(objectType, out InventoryItemVo item))
			{
				cellsContainer.UpdateItemInfo(item);
			}
			else {
				cellsContainer.HideCellByObjectType(objectType);
			}
		}
	}
}