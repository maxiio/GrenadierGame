using UnityEngine;

namespace Db.Camera {
	[CreateAssetMenu(menuName = "Settings/" + nameof(CameraBase), fileName = nameof(CameraBase))]
	public class CameraBase : ScriptableObject {
		[SerializeField] private float mouseSensitivity = 100.0f;
		[SerializeField] private float minCameraAngle = -89.0f;
		[SerializeField] private float maxCameraAngle = 89.0f;
		[SerializeField] private bool hasLockCursor;

		public float MouseSensitivity 
			=> mouseSensitivity;
		public float MinCameraAngle 
			=> minCameraAngle;
		public float MaxCameraAngle 
			=> maxCameraAngle;
		public bool HasLockCursor 
			=> hasLockCursor;
	}
}