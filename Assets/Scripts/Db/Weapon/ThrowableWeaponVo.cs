using System;
using Db.Object;
using UnityEngine;

namespace Db.Weapon {
	[Serializable]
	public class ThrowableWeaponVo : ObjectVo {
		public float launchForce;
		public GameObject projectilePrefab;
	}
}