using System.Collections.Generic;
using Db.Object;
using UnityEngine;

namespace Db.Weapon.Impl {
	[CreateAssetMenu(menuName = "Settings/ThrowableWeaponBase", fileName = "ThrowableWeaponBase")]
	public class ThrowableWeaponBase : ScriptableObject, IThrowableWeaponBase {
		[SerializeField] private List<ThrowableWeaponVo> throwableWeaponVos;

		public bool TryGetThrowableWeapon(EObjectType objectType, out ThrowableWeaponVo throwableWeaponVo) {
			throwableWeaponVo = null;
			foreach (var weaponVo in throwableWeaponVos) {
				if (weaponVo.objectType == objectType) {
					throwableWeaponVo = weaponVo;
					return true;
				}
			}
			return false;
		}

		public bool HasSettings(EObjectType objectType) {
			return GetSettings(objectType) != null;
		}

		public ThrowableWeaponVo GetSettings(EObjectType objectType) {
			return throwableWeaponVos.Find(x => x.objectType == objectType);
		}
	}
}