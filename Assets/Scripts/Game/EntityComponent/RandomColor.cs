using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.EntityComponent {
	public class RandomColor : MonoBehaviour {
		[SerializeField] private MeshRenderer meshRenderer;
		
		private void Awake() {
			meshRenderer.material.color = GetRandomColor();
		}

		private Color GetRandomColor() {
			return Random.ColorHSV();
		}
	}
}