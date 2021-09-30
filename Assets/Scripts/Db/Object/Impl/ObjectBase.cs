using System.Collections.Generic;
using UnityEngine;

namespace Db.Object.Impl {
	[CreateAssetMenu(menuName = "Settings/ObjectBase", fileName = "ObjectBase")]
	public class ObjectBase : ScriptableObject, IObjectBase {
		[SerializeField] private List<GameObjectVo> gameObjectVos;

		public List<GameObjectVo> GetObjects 
			=> gameObjectVos;
	}
}