using Db.Object;
using Game.Input;
using Game.Player;
using UnityEngine;

namespace Game.Throw {
	public class ThrowController : MonoBehaviour {
		[Header("Dependent objects")]
		[SerializeField] private ItemInHand itemInHand;
		[SerializeField] private Aimable aimable;
		[SerializeField] private ThrowItemInHand throwItemInHand;

		private bool _isPressed;
		
		private void Update() {
			if (_isPressed && HasItemInHand() && InputController.Instance.PressUp) {
				_isPressed = false;
				ThrowItemInHand();
			}
			
			if (!_isPressed && HasItemInHand() && InputController.Instance.PressDown) {
				_isPressed = true;
				ActivateAiming();
			}
		}

		private bool HasItemInHand() => itemInHand.ObjectInHand != EObjectType.None;

		private void ActivateAiming() {
			aimable.StartAiming();
		}

		private void ThrowItemInHand() {
			throwItemInHand.Throw();
		}
	}
}