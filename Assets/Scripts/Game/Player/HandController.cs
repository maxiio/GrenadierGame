using Db.Object;
using Game.Input;
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
				aimable.StopAiming();
				throwingObjectInHand.Throw();
			}
			
			if (!_isPressed && HasItemInHand() && InputController.Instance.PressDown) {
				_isPressed = true;
				aimable.StartAiming();
			}
		}

		private bool HasItemInHand() => objectInHandController.ObjectInHand != EObjectType.None;
	}
}