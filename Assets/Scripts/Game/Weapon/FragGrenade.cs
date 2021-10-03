using Game.EntityComponent;
using UnityEngine;

namespace Game.Weapon {
	public class FragGrenade : AGrenade {
		private static Collider[] _sphereCastPool = new Collider[DefaultSphereCastPoolSize];
		private const int DefaultSphereCastPoolSize = 10;
		
		[SerializeField] private float radius;
		[SerializeField] private float damage;

		protected override void OnExplosion(Collision _) {
			int count = Physics.OverlapSphereNonAlloc(transform.position, radius, _sphereCastPool);
			
			while (count == _sphereCastPool.Length) {
				DoubledSphereCastPoolSize();
				count = Physics.OverlapSphereNonAlloc(transform.position, radius, _sphereCastPool);
			}
			
			for (int i = 0; i < count; ++i)
			{
				if (_sphereCastPool[i].TryGetComponent<Damageable>(out var damageableObject)) {
					damageableObject.Damage(damage);
				}
			}
		}

		private static void DoubledSphereCastPoolSize() {
			var lastSize = _sphereCastPool.Length;
			_sphereCastPool = new Collider[lastSize * lastSize];
		}
	}
}