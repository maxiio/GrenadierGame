using Db.Object;
using Game.Input;
using Game.Interaction;
using Game.Throwing;
using UnityEngine;

namespace Game.Player {
	public class HandController : MonoBehaviour {
		[SerializeField] private ObjectInHandController objectInHandController;
		[SerializeField] private Aimable aimable;
		[SerializeField] private ThrowingObjectInHand throwingObjectInHand;

		private bool _isPressed;
		
		private void Update() {
			if (_isPressed && HasItemInHand() && InputController.Instance.PressUp) {
				_isPressed = false;
				aimable.SwitchAimingState(false);
				throwingObjectInHand.Throw();
			}
			
			if (!_isPressed && HasItemInHand() && InputController.Instance.PressDown) {
				_isPressed = true;
				aimable.SwitchAimingState(true);
			}
		}

		private bool HasItemInHand() => objectInHandController.ObjectInHand != EObjectType.None;
	}
}