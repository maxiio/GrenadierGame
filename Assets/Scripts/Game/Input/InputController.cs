using UnityEngine;

namespace Game.Input {
	public class InputController : MonoBehaviour {
		public static InputController Instance { get; private set; }

		private const int LeftMouseButton = 0;
		private const string Vertical = "Vertical";
		private const string Horizontal = "Horizontal";
		private const string MouseVertical = "Mouse X";
		private const string MouseHorizontal = "Mouse Y";
		
		public float VerticalDirection { get; private set; }
		public float HorizontalDirection { get; private set; }
		
		public float CameraVerticalDirection { get; private set; }
		public float CameraHorizontalDirection { get; private set; }
		
		public bool PressDown { get; private set; }
		public bool PressUp { get; private set; }
		
		public bool SwitchToLeftItem { get; private set; }
		public bool SwitchToRightItem { get; private set; }

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

			SwitchToLeftItem = UnityEngine.Input.GetKeyUp(KeyCode.LeftArrow);
			SwitchToRightItem = UnityEngine.Input.GetKeyUp(KeyCode.RightArrow);
		}

		private void MouseInput() {
			CameraVerticalDirection = UnityEngine.Input.GetAxis(MouseVertical);
			CameraHorizontalDirection = UnityEngine.Input.GetAxis(MouseHorizontal);

			PressDown = UnityEngine.Input.GetMouseButtonDown(LeftMouseButton);
			PressUp = UnityEngine.Input.GetMouseButtonUp(LeftMouseButton);
		}
	}
}