using System;
using UnityEngine;

namespace Game.Throw {
	public class Aimable : MonoBehaviour {
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

		private void Update() {
			
		}
	}
}