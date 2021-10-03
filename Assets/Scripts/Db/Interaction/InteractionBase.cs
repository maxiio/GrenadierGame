using System.Collections.Generic;
using Db.Object;
using UnityEngine;

namespace Db.Interaction {
	[CreateAssetMenu(menuName = "Settings/InteractionBase", fileName = "InteractionBase")]
	public class InteractionBase : ScriptableObject {
		[SerializeField] private List<InteractiveObjectVo> damageableSettings;

		public InteractiveObjectVo GetSettings(EObjectType objectType) {
			var res = damageableSettings.Find(x => x.objectType == objectType);
			if (res == null) Debug.LogError($"Can't find {objectType} in {nameof(InteractionBase)}");
			return res;
		}
	}
}