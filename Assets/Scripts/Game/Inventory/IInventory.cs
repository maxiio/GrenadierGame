using Db.Object;

namespace Game.Inventory {
	public interface IInventory {
		bool TryAddItem(EObjectType objectType);
	}
}