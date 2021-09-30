using System.Collections.Generic;
using Db.Inventory;
using UnityEngine;

namespace UI.Inventory {
	public class InventoryCellsContainer : MonoBehaviour {
		[SerializeField] private InventoryCellsPool cellsPool;
		
		private readonly List<InventoryCell> _activeCells = new List<InventoryCell>();
		
		public void UpdateItemInfo(InventoryItemVo item) {
			foreach (var activeCell in _activeCells) {
				if (activeCell.GetItemObjectType() != item.ObjectType) {
					continue;
				}

				// Has item in view
				if (item.Amount <= 0) {
					cellsPool.ReturnObject(activeCell);
				}
				else {
					activeCell.UpdateInventoryCell(item);
				}

				return;
			}
			
			// If item not exist
			var inventoryCell = cellsPool.GetObject(Vector3.zero);
			inventoryCell.UpdateInventoryCell(item);
			_activeCells.Add(inventoryCell);
		}
	}
}