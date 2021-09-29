using System.Collections.Generic;
using Db.Object;
using UnityEngine;

namespace Game.Inventory {
	public class Inventory : MonoBehaviour, IInventory {
		private List<EObjectType> _inventory = new List<EObjectType>();
		
		public bool TryAddItem(EObjectType objectType) {
			_inventory.Add(objectType);
			return true;
		}
	}
}