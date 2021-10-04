using System.Collections.Generic;
using UnityEngine;

namespace Db.Object.Implementation {
	[CreateAssetMenu(menuName = "Settings/" + nameof(ObjectBase), fileName = nameof(ObjectBase))]
	public class ObjectBase : ScriptableObject, IObjectBase {
		[SerializeField] private List<GameObjectVo> gameObjectVos;

		public bool HasObject(EObjectType objectType) {
			return GetObjectSettings(objectType) != null;
		}

		public GameObjectVo GetObjectSettings(EObjectType objectType) {
			return gameObjectVos.Find(x => x.objectType == objectType);
		}
	}
}