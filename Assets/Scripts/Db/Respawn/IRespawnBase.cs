using Db.Object;

namespace Db.Respawn {
	public interface IRespawnBase {
		bool HasRespawnSettings(EObjectType objectType);
		RespawnSettings GetRespawnSettings(EObjectType objectType);
	}
}