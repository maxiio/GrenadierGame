using System;
using UnityEngine;

namespace Db.Object {
	[Serializable]
	public class ObjectVo {
		public EObjectType objectType;
		public GameObject prefab;
	}
}