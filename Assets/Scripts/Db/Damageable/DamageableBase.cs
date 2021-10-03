using System.Collections.Generic;
using Db.Object;
using UnityEngine;

namespace Db.Damageable {
	[CreateAssetMenu(menuName = "Settings/DamageableBase", fileName = "DamageableBase")]
	public class DamageableBase : ScriptableObject {
		[SerializeField] private List<DamageableObjectVo> damageableSettings;

		public DamageableObjectVo GetSettings(EObjectType objectType) {
			var res = damageableSettings.Find(x => x.objectType == objectType);
			if (res == null) Debug.LogError($"Can't find {objectType} in {nameof(DamageableBase)}");
			return res;
		}
	}
}