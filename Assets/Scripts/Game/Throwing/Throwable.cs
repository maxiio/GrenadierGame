using UnityEngine;

namespace Game.Throwing {
	[RequireComponent(typeof(Rigidbody))]
	public class Throwable : MonoBehaviour {
		private Rigidbody _rigidbody;

		private void Awake() {
			_rigidbody = GetComponent<Rigidbody>();
		}

		public void Throw(Vector3 direction, float force) {
			_rigidbody.AddForce(direction * force);
		}
	}
}