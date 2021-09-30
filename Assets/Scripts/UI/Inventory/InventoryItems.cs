using UnityEngine;
using Util;

namespace UI.Inventory {
	public class InventoryItems : MonoBehaviour {
		private const int CellPoolSize = 4;
		
		[Header("Dependent objects")]
		[SerializeField] private Transform layoutGroupRoot;
		[SerializeField] private GameObject inventoryCellPrefab;
		
		private void Awake() {
		}
	}
}