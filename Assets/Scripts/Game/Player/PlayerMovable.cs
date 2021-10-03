using Db.Player;
using Game.Input;
using UnityEngine;

namespace Game.Player {
	public class PlayerMovable : MonoBehaviour {
		[SerializeField] private PlayerBase playerBase;
		[SerializeField] private CharacterController characterController;

		private void Update() {
			Vector3 move = new Vector3(InputController.Instance.HorizontalDirection, 0, InputController.Instance.VerticalDirection);
			if (move.sqrMagnitude > 1.0f) {
				move.Normalize();
			}

			move *= playerBase.Speed * Time.deltaTime;
			move = transform.TransformDirection(move);
			characterController.Move(move);
		}
	}
}