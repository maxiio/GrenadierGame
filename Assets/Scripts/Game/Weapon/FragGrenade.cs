using Db.Weapon;
using Db.Weapon.Implementation;
using Game.EntityComponent;
using UnityEngine;

namespace Game.Weapon {
	public class FragGrenade : AGrenade {
		private static Collider[] _sphereCastPool = new Collider[DefaultSphereCastPoolSize];
		private const int DefaultSphereCastPoolSize = 10;

		[SerializeField] private ThrowableWeaponBase weaponBase;
		[SerializeField] private ObjectTypeHolder objectTypeHolder;
		private ThrowableWeaponVo _throwableWeaponVo;

		private void Start() {
			var objectType = objectTypeHolder.Get();
			_throwableWeaponVo = weaponBase.GetSettings(objectType);
		}

		protected override void OnExplosion(Collision _) {
			int count = Physics.OverlapSphereNonAlloc(transform.position, _throwableWeaponVo.splashRadius, _sphereCastPool);
			
			while (count >= _sphereCastPool.Length) {
				DoubledSphereCastPoolSize();
				count = Physics.OverlapSphereNonAlloc(transform.position, _throwableWeaponVo.splashRadius, _sphereCastPool);
			}
			
			for (int i = 0; i < count; ++i)
			{
				if (_sphereCastPool[i].TryGetComponent<Damageable>(out var damageableObject)) {
					damageableObject.Damage(_throwableWeaponVo.damage);
				}
			}
		}

		private static void DoubledSphereCastPoolSize() {
			var lastSize = _sphereCastPool.Length;
			_sphereCastPool = new Collider[lastSize * lastSize];
		}
	}
}