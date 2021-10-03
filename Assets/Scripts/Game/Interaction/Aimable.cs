using UnityEngine;

namespace Game.Interaction {
	public class Aimable : MonoBehaviour {
		[SerializeField] private Camera camera;
		[SerializeField] private LineRenderer lineRendererComponent;

		private bool _isAiming;

		private void Update() {
			if (_isAiming) {
				RenderTrajectory(startPosition: transform.position,
					direction: camera.transform.forward,
					speed: 100);
			}
		}
		
		public void SwitchAimingState(bool isAiming) {
			_isAiming = isAiming;
			lineRendererComponent.gameObject.SetActive(isAiming);
		}

		private void RenderTrajectory(Vector3 startPosition, Vector3 direction, float speed) {
			Vector3[] points = new Vector3[100];
			lineRendererComponent.positionCount = points.Length;

			for (int i = 0; i < points.Length; i++) {
				float time = i * 0.1f;
				points[i] = startPosition + direction * speed * time + Physics.gravity * time * time / 2f;

				if (points[i].y < 0) {
					lineRendererComponent.positionCount = i + 1;
					break;
				}
			}

			lineRendererComponent.SetPositions(points);
		}
	}
}