using Db.Weapon.Implementation;
using Game.Player;
using UnityEngine;

namespace Game.Interaction {
	public class Aiming : MonoBehaviour {
		private const int LineRendererPointsCount = 100;
		private const float DistanceBetweenPoints = 0.1f;
		
		[SerializeField] private ThrowableWeaponBase throwableWeaponBase;
		[SerializeField] private ObjectInHandController objectInHandController;
		[SerializeField] private Camera weaponCamera;
		[SerializeField] private LineRenderer lineRendererComponent;
		[SerializeField] private Transform startPosition;
		
		private float _speed;
		private bool _isAiming;

		private void Update() {
			if (_isAiming) {
				var direction = weaponCamera.transform.forward;
				RenderTrajectory(startPosition.position, direction, _speed);
			}
		}
		
		public void SwitchAimingState(bool isAiming) {
			var objectInHand = objectInHandController.ObjectInHand;
			if (!throwableWeaponBase.HasSettings(objectInHand)) {
				SetAimingState(false);
				return;
			}

			_speed = throwableWeaponBase.GetSettings(objectInHand).forceSpeed;
			SetAimingState(isAiming);
		}

		private void SetAimingState(bool value) {
			_isAiming = value;
			lineRendererComponent.gameObject.SetActive(value);
		}

		private void RenderTrajectory(Vector3 position, Vector3 direction, float speed) {
			Vector3[] points = new Vector3[LineRendererPointsCount];
			lineRendererComponent.positionCount = points.Length;

			for (int i = 0; i < points.Length; i++) {
				float time = i * DistanceBetweenPoints;
				points[i] = position + direction * speed * time + Physics.gravity * time * time / 2f;
			}

			lineRendererComponent.SetPositions(points);
		}
	}
}