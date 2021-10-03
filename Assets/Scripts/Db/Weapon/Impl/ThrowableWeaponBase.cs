using System.Collections.Generic;
using Db.Object;
using UnityEngine;

namespace Db.Weapon.Impl {
	[CreateAssetMenu(menuName = "Settings/ThrowableWeaponBase", fileName = "ThrowableWeaponBase")]
	public class ThrowableWeaponBase : ScriptableObject, IThrowableWeaponBase {
		[SerializeField] private List<ThrowableWeaponVo> throwableWeaponVos;

		public List<ThrowableWeaponVo> GetThrowableWeapons 
			=> throwableWeaponVos;

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
	}
}