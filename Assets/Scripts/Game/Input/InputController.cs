using UnityEngine;

namespace Game.Input {
	public class InputController : MonoBehaviour {
		public static InputController Instance { get; protected set; }

		private const string Vertical = "Vertical";
		private const string Horizontal = "Horizontal";
		private const string MouseVertical = "Mouse X";
		private const string MouseHorizontal = "Mouse Y";
		
		public float VerticalDirection { get; private set; }
		public float HorizontalDirection { get; private set; }
		
		public float CameraVerticalDirection { get; private set; }
		public float CameraHorizontalDirection { get; private set; }

		private void Awake() {
			if (Instance != null) {
				Destroy(Instance.gameObject);
			}

			Instance = this;
		}

		private void Update() {
			KeyboardInput();
			MouseInput();
		}

		private void KeyboardInput() {
			VerticalDirection = UnityEngine.Input.GetAxis(Vertical);
			HorizontalDirection = UnityEngine.Input.GetAxis(Horizontal);
		}

		private void MouseInput() {
			CameraVerticalDirection = UnityEngine.Input.GetAxis(MouseVertical);
			CameraHorizontalDirection = UnityEngine.Input.GetAxis(MouseHorizontal);
		}
	}
}