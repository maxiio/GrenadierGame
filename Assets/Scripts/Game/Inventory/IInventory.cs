using Db.Inventory;
using Db.Object;

namespace Game.Inventory {
	public interface IInventory {
		bool TryAddItem(EObjectType objectType);
		bool TryGetItem(EObjectType objectType, out InventoryItemVo item);
		bool TryRemoveItem(EObjectType objectType);
	}
}