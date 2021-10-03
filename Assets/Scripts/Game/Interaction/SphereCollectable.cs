using Db.Interaction;
using Game.EntityComponent;
using UnityEngine;

namespace Game.Interaction {
	[RequireComponent(typeof(SphereCollider))]
	public class SphereCollectable : Collectable {
		[SerializeField] private InteractionBase interactionBase;
		[SerializeField] private ObjectTypeHolder objectTypeHolder;
		[SerializeField] private SphereCollider sphereCollider;
		
		private void Start() {
			var objectType = objectTypeHolder.Get();
			sphereCollider.radius = interactionBase.GetSettings(objectType).interactiveRadius;
		}
		
#if UNITY_EDITOR
		private void OnDrawGizmos() {
			Gizmos.color = Color.blue;
			if (sphereCollider != null) {
				Gizmos.DrawWireSphere(transform.position, sphereCollider.radius);
			}
		}
#endif
	}
}