using Db.UI;
using Game.EntityComponent;
using TMPro;
using UnityEngine;

namespace UI.EntityComponent {
	public class DamageableView : MonoBehaviour {
		[SerializeField] private UIEffects uiEffects;
		[SerializeField] private Damageable damageable;
		[SerializeField] private TextMeshProUGUI textMesh;
		
		private void Start() {
			DisableText();
			damageable.healthChanged.AddListener(DisplayChanges);
		}

		private void OnDestroy() {
			damageable.healthChanged.RemoveListener(DisplayChanges);
		}

		private void DisplayChanges(float healthDelta) {
			textMesh.gameObject.SetActive(true);
			textMesh.text = healthDelta.ToString();
			Invoke(nameof(DisableText), uiEffects.TimeToDisplayDamage);
		}

		private void DisableText() {
			textMesh.gameObject.SetActive(false);
		}
	}
}