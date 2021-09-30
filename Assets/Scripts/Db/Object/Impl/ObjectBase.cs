using System.Collections.Generic;
using UnityEngine;

namespace Db.Object.Impl {
	[CreateAssetMenu(menuName = "Settings/ObjectBase", fileName = "ObjectBase")]
	public class ObjectBase : ScriptableObject, IObjectBase {
		[SerializeField] private List<ObjectVo> objectVos;

		public List<ObjectVo> GetObjects 
			=> objectVos;
	}
}