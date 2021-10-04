using UnityEngine;

namespace Db.Camera {
	[CreateAssetMenu(menuName = "Settings/" + nameof(CameraBase), fileName = nameof(CameraBase))]
	public class CameraBase : ScriptableObject {
		[SerializeField] private float mouseSensitivity;
		[SerializeField] private float minCameraAngle;
		[SerializeField] private float maxCameraAngle;
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