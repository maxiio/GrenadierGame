using System.Collections.Generic;
using Db.Object;

namespace Db.Weapon {
	public interface IThrowableWeaponBase {
		List<ThrowableWeaponVo> GetThrowableWeapons { get; }
		bool TryGetThrowableWeapon(EObjectType objectType, out ThrowableWeaponVo throwableWeaponVo);
	}
}