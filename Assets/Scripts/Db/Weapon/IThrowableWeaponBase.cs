using Db.Object;

namespace Db.Weapon {
	public interface IThrowableWeaponBase {
		bool HasSettings(EObjectType objectType);
		ThrowableWeaponVo GetSettings(EObjectType objectType);
	}
}