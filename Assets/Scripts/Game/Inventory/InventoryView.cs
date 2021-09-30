using Db.Inventory;
using Db.Object;
using UI.Inventory;
using UnityEngine;

namespace Game.Inventory {
	public class InventoryView : MonoBehaviour {
		[Header("Dependent objects")]
		[SerializeField] private Impl.Inventory inventory;
		[SerializeField] private InventoryCellsContainer cellsContainer;

		private void Start() {
			inventory.ChangedItem += ChangedItem;
		}

		private void ChangedItem(EObjectType objectType) {
			if (inventory.TryGetItem(objectType, out InventoryItemVo item))
			{
				cellsContainer.UpdateItemInfo(item);
			}
		}
	}
}