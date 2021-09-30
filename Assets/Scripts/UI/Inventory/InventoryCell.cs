using Db.Inventory;
using TMPro;
using UnityEngine;

namespace UI.Inventory {
	public class InventoryCell : MonoBehaviour {
		[Header("Dependent objects")]
		[SerializeField] private TextMeshProUGUI itemName;
		[SerializeField] private TextMeshProUGUI itemAmount;
		
		private void UpdateInventoryCell(InventoryItemVo inventoryItemVo) {
			var name = inventoryItemVo.Name;
			var amount = inventoryItemVo.Amount;

			itemName.text = name;
			itemAmount.text = amount.ToString();
		}
	}
}