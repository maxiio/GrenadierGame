using UnityEngine;
using UnityEngine.Events;

namespace Game.EntityComponent {
	public class Damageable : MonoBehaviour {
		public UnityEvent<float> healthChanged;
		
		[SerializeField] private float healthPoints;

		public void Damage(float damage) {
			healthPoints -= damage;
			healthChanged.Invoke(-damage);
			if (healthPoints > 0) {
				return;
			}

			Destroy(gameObject);
		}
	}
}