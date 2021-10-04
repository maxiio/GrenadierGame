using Db.Damageable;
using UnityEngine;
using UnityEngine.Events;

namespace Game.EntityComponent {
	public class Damageable : MonoBehaviour {
		public UnityEvent<float> healthChanged;

		[SerializeField] private DamageableBase damageableBase;
		[SerializeField] private ObjectTypeHolder objectTypeHolder;
		
		private float _healthPoints;

		private void Start() {
			var objectType = objectTypeHolder.Get();
			_healthPoints = damageableBase.GetSettings(objectType).healthPoints;
		}

		public void Damage(float damage) {
			_healthPoints -= damage;
			healthChanged.Invoke(-damage);
			if (_healthPoints > 0) {
				return;
			}

			Destroy(gameObject);
		}
	}
}