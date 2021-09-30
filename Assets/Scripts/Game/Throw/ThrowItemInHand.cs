using Game.Player;
using UnityEngine;

namespace Game.Throw {
	public class ThrowItemInHand : MonoBehaviour {
		[Header("Dependent objects")]
		[SerializeField] private ItemInHand itemInHand;

		public void Throw() {
			Debug.Log("Throw");
		}
	}
}