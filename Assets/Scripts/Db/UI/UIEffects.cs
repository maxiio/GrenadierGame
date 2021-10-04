using UnityEngine;

namespace Db.UI {
	[CreateAssetMenu(menuName = "Settings/" + nameof(UIEffects), fileName = nameof(UIEffects))]
	public class UIEffects : ScriptableObject {
		[SerializeField] private float timeToDisplayDamage;

		public float TimeToDisplayDamage 
			=> timeToDisplayDamage;
	}
}