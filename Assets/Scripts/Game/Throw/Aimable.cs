using UnityEngine;

namespace Game.Throw {
	public class Aimable : MonoBehaviour {
		[Header("Dependent objects")]
		[SerializeField] private Camera camera;

		public void StartAiming() {
			Debug.Log("Aiming");
		}
	}
}