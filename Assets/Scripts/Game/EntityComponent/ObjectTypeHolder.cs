using Db.Object;
using UnityEngine;

namespace Game.EntityComponent {
	public class ObjectTypeHolder : MonoBehaviour {
		[SerializeField] private EObjectType objectType;

		public EObjectType Get() => objectType;
	}
}