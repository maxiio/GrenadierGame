using Db.Inventory;
using Db.Object;
using TMPro;
using UnityEngine;

namespace UI.Inventory {
	public class InventoryCell : MonoBehaviour {
		[SerializeField] private TextMeshProUGUI itemName;
		[SerializeField] private TextMeshProUGUI itemAmount;

		private EObjectType _objectType;

		public EObjectType GetItemObjectType() => _objectType;
		
		public void UpdateInventoryCell(InventoryItemVo inventoryItemVo) {
			_objectType = inventoryItemVo.ObjectType;
			var name = inventoryItemVo.Name;
			var amount = inventoryItemVo.Amount;

			itemName.text = name;
			itemAmount.text = amount.ToString();
		}
	}
}