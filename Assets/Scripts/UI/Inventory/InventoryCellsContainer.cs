using System.Collections.Generic;
using Db.Inventory;
using Db.Object;
using UnityEngine;

namespace UI.Inventory {
	public class InventoryCellsContainer : MonoBehaviour {
		[SerializeField] private InventoryCellsPool cellsPool;

		private readonly List<InventoryCell> _activeCells = new List<InventoryCell>();

		public void UpdateItemInfo(InventoryItemVo item) {
			if (item.Amount <= 0) {
				HideCellByObjectType(item.ObjectType);
				return;
			}

			foreach (var activeCell in _activeCells) {
				if (activeCell.GetItemObjectType() == item.ObjectType) {
					activeCell.UpdateInventoryCell(item);
					return;
				}
			}

			// If item not exist
			var inventoryCell = cellsPool.GetObject(Vector3.zero);
			inventoryCell.UpdateInventoryCell(item);
			_activeCells.Add(inventoryCell);
		}

		public void HideCellByObjectType(EObjectType objectType) {
			foreach (var activeCell in _activeCells) {
				if (activeCell.GetItemObjectType() == objectType) {
					cellsPool.ReturnObject(activeCell);
				}
			}
		}
	}
}