using Db.Object;
using Game.Input;
using Game.Throwing;
using UnityEngine;

namespace Game.Player {
	public class HandController : MonoBehaviour {
		[SerializeField] private ObjectInHandController objectInHandController;
		[SerializeField] private Aiming aiming;
		[SerializeField] private ThrowingObjectInHand throwingObjectInHand;

		private bool _isPressed;
		
		private void Update() {
			if (_isPressed && HasItemInHand() && InputController.Instance.PressUp) {
				_isPressed = false;
				aiming.SwitchAimingState(false);
				throwingObjectInHand.Throw();
			}
			
			if (!_isPressed && HasItemInHand() && InputController.Instance.PressDown) {
				_isPressed = true;
				aiming.SwitchAimingState(true);
			}
		}

		private bool HasItemInHand() => objectInHandController.ObjectInHand != EObjectType.None;
	}
}