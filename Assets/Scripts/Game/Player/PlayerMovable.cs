using Game.Input;
using UnityEngine;

namespace Game.Player {
	public class PlayerMovable : MonoBehaviour {
		[Header("Dependent objects")]
		[SerializeField] private CharacterController characterController;

		[Header("Control Settings")]
		[SerializeField] private float playerSpeed = 5.0f;

		private void Update() {
			Vector3 move = new Vector3(InputController.Instance.HorizontalDirection, 0, InputController.Instance.VerticalDirection);
			if (move.sqrMagnitude > 1.0f) {
				move.Normalize();
			}

			move *= playerSpeed * Time.deltaTime;
			move = transform.TransformDirection(move);
			characterController.Move(move);
		}
	}
}