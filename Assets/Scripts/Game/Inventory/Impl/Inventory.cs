using System;
using System.Collections.Generic;
using Db.Inventory;
using Db.Object;
using UnityEngine;

namespace Game.Inventory.Impl {
	public class Inventory : MonoBehaviour, IInventory {
		public Action<EObjectType> ChangedItem;
		public Action<EObjectType> AddedItem;
		public Action<EObjectType> RemovedItem;

		private List<InventoryItemVo> _inventory = new List<InventoryItemVo>();

		public bool TryAddItem(EObjectType objectType) {
			var hasAddItem = HasAddItem(objectType);
			if (hasAddItem) {
				ChangedItem.Invoke(objectType);
				AddedItem.Invoke(objectType);
			}

			return hasAddItem;
		}

		public bool TryGetItem(EObjectType objectType, out InventoryItemVo item) {
			item = null;
			foreach (var inventoryItem in _inventory) {
				if (inventoryItem.ObjectType == objectType) {
					item = inventoryItem;
					return true;
				}
			}

			return false;
		}

		public bool HasItem(EObjectType objectType) {
			return TryGetItem(objectType, out InventoryItemVo _);
		}

		public bool TryRemoveItem(EObjectType objectType) {
			var hasRemoveItem = HasRemoveItem(objectType);
			if (hasRemoveItem) {
				ChangedItem.Invoke(objectType);
				RemovedItem.Invoke(objectType);
			}

			return hasRemoveItem;
		}

		public List<InventoryItemVo> GetInventoryItems()
			=> _inventory;

		private bool HasAddItem(EObjectType objectType) {
			foreach (var item in _inventory) {
				if (item.ObjectType == objectType) {
					item.Amount++;
					return true;
				}
			}

			var newItem = new InventoryItemVo {
				ObjectType = objectType,
				Name = objectType.ToString(),
				Amount = 1
			};
			_inventory.Add(newItem);
			return true;
		}

		private bool HasRemoveItem(EObjectType objectType) {
			foreach (var item in _inventory) {
				if (item.ObjectType != objectType) {
					continue;
				}

				item.Amount--;
				if (item.Amount <= 0) {
					return _inventory.Remove(item);
				}

				return true;
			}

			return false;
		}
	}
}