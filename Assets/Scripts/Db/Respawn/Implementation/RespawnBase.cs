using System.Collections.Generic;
using Db.Object;
using UnityEngine;

namespace Db.Respawn.Implementation {
	[CreateAssetMenu(menuName = "Settings/" + nameof(RespawnBase), fileName = nameof(RespawnBase))]
	public class RespawnBase : ScriptableObject, IRespawnBase {
		[SerializeField] private List<RespawnSettings> respawnSettingsList;
		
		public bool HasRespawnSettings(EObjectType objectType) {
			return GetRespawnSettings(objectType) != null;
		}

		public RespawnSettings GetRespawnSettings(EObjectType objectType) {
			return respawnSettingsList.Find(x => x.objectType == objectType);
		}
	}
}