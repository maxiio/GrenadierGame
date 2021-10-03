using Db.Weapon;
using Db.Weapon.Impl;
using Game.Player;
using UnityEngine;

namespace Game.Throw {
	public class ThrowItemInHand : MonoBehaviour {
		[SerializeField] private HandController handController;
		[SerializeField] private ThrowableWeaponBase throwableWeaponBase;

		public void Throw() {
			if (throwableWeaponBase.TryGetThrowableWeapon(handController.ObjectInHand,
				out ThrowableWeaponVo throwableWeaponVo)) {
				var throwableObject = Instantiate(throwableWeaponVo.projectilePrefab);


				Launch(throwableWeaponVo.launchForce);
			}
		}

		private void Launch(float force) {
		}
	}
}