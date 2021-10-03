using Game.EntityComponent;
using UnityEngine;

namespace Game.Weapon {
	public class FragGrenade : AGrenade {
		private static readonly Collider[] SphereCastPool = new Collider[32];

		[SerializeField] private float radius;
		[SerializeField] private float damage;
		
		protected override void OnExplosion(Collision _) {
			int count = Physics.OverlapSphereNonAlloc(transform.position, radius, SphereCastPool);
			for (int i = 0; i < count; ++i)
			{
				Damageable t = SphereCastPool[i].GetComponent<Damageable>();
				t.Damage(damage);
			}
		}
	}
}