using Db.Object;
using Game.Input;
using Game.Player;
using UnityEngine;

namespace Game.Throw {
	public class ThrowController : MonoBehaviour {
		[SerializeField] private HandController handController;
		[SerializeField] private Aimable aimable;
		[SerializeField] private ThrowItemInHand throwItemInHand;

		private bool _isPressed;
		
		private void Update() {
			if (_isPressed && HasItemInHand() && InputController.Instance.PressUp) {
				_isPressed = false;
				aimable.StopAiming();
				throwItemInHand.Throw();
			}
			
			if (!_isPressed && HasItemInHand() && InputController.Instance.PressDown) {
				_isPressed = true;
				aimable.StartAiming();
			}
		}

		private bool HasItemInHand() => handController.ObjectInHand != EObjectType.None;
	}
}