using System.Collections;
using UnityEngine;

namespace Game.Throw {
	public class Aimable : MonoBehaviour {
		[Header("Dependent objects")]
		[SerializeField] private Camera camera;

		private bool _isAiming;
		
		public void StartAiming() {
			Debug.Log("Start Aiming");
			_isAiming = true;
		}

		public void StopAiming() {
			Debug.Log("Stop Aiming");
			_isAiming = false;
		}
	}
}