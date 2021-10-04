using System;
using Db.Object;
using UnityEngine;

namespace Db.Weapon {
	[Serializable]
	public class ThrowableWeaponVo : ObjectVo {
		public float damage;
		public float splashRadius;
		public float forceSpeed;
		public GameObject projectilePrefab;
	}
}	