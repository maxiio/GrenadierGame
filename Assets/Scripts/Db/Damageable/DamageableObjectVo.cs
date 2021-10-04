using System;
using Db.Object;

namespace Db.Damageable {
	[Serializable]
	public class DamageableObjectVo : ObjectVo {
		public int healthPoints;
	}
}