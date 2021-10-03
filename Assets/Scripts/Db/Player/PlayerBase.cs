using UnityEngine;

namespace Db.Player {
	[CreateAssetMenu(menuName = "Settings/" + nameof(PlayerBase), fileName = nameof(PlayerBase))]
	public class PlayerBase : ScriptableObject {
		[SerializeField] private float speed;

		public float Speed
			=> speed;
	}
}