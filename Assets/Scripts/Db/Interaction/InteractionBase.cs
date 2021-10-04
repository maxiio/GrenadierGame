using System.Collections.Generic;
using Db.Object;
using UnityEngine;

namespace Db.Interaction {
	[CreateAssetMenu(menuName = "Settings/" + nameof(InteractionBase), fileName = nameof(InteractionBase))]
	public class InteractionBase : ScriptableObject {
		[SerializeField] private List<InteractiveObjectVo> interactionSettings;

		public InteractiveObjectVo GetSettings(EObjectType objectType) {
			var res = interactionSettings.Find(x => x.objectType == objectType);
			if (res == null) Debug.LogError($"Can't find {objectType} in {nameof(InteractionBase)}");
			return res;
		}
	}
}