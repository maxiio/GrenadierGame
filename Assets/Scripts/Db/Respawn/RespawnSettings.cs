using System;
using Db.Object;

namespace Db.Respawn {
	[Serializable]
	public class RespawnSettings {
		public EObjectType objectType;
		public float timeToRespawn;
	}
}