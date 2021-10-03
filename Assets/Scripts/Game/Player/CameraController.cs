using Db.Camera;
using Game.Input;
using UnityEngine;

namespace Game.Player {
	public class CameraController : MonoBehaviour {
		[Header("Dependent objects")]
		[SerializeField] private Camera mainCamera;
		[SerializeField] private Transform rotatableTransform;

		[Header("Settings")]
		[SerializeField] private CameraBase cameraBase;
		[SerializeField] private Transform cameraPosition;

		private float _horizontalAngle;
		private float _verticalAngle;

		private void Start() {
			if (cameraBase.HasLockCursor) {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
			
			var mainCameraTransform = mainCamera.transform;
			mainCameraTransform.SetParent(cameraPosition, false);
			mainCameraTransform.localPosition = Vector3.zero;
			mainCameraTransform.localRotation = Quaternion.identity;
			
			_horizontalAngle = rotatableTransform.localEulerAngles.y;
		}

		private void Update() {
			float turnPlayer = InputController.Instance.CameraVerticalDirection * cameraBase.MouseSensitivity;
			_horizontalAngle += turnPlayer;

			if (_horizontalAngle > 360) {
				_horizontalAngle -= 360.0f;
			}

			if (_horizontalAngle < 0) {
				_horizontalAngle += 360.0f;
			}

			Vector3 currentAngles = rotatableTransform.localEulerAngles;
			currentAngles.y = _horizontalAngle;
			rotatableTransform.localEulerAngles = currentAngles;

			var turnCam = -InputController.Instance.CameraHorizontalDirection;
			turnCam *= cameraBase.MouseSensitivity;
			_verticalAngle = Mathf.Clamp(turnCam + _verticalAngle, cameraBase.MinCameraAngle, cameraBase.MaxCameraAngle);
			currentAngles = cameraPosition.transform.localEulerAngles;
			currentAngles.x = _verticalAngle;
			cameraPosition.transform.localEulerAngles = currentAngles;
		}
	}
}