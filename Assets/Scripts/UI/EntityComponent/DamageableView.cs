using Game.EntityComponent;
using TMPro;
using UnityEngine;

namespace UI.EntityComponent {
	public class DamageableView : MonoBehaviour {
		[SerializeField] private Damageable damageable;
		[SerializeField] private TextMeshProUGUI textMesh;

		[Header("Cfg")]
		[SerializeField] private float timeToDisplay;
		
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
			Invoke(nameof(DisableText), timeToDisplay);
		}

		private void DisableText() {
			textMesh.gameObject.SetActive(false);
		}
	}
}