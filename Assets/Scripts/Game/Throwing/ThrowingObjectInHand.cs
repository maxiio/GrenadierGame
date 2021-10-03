using Db.Weapon;
using Db.Weapon.Implementation;
using Game.Player;
using UnityEngine;

namespace Game.Throwing {
	public class ThrowingObjectInHand : MonoBehaviour {
		[SerializeField] private Transform throwDirection;
		[SerializeField] private ObjectInHandController objectInHandController;
		[SerializeField] private ThrowableWeaponBase throwableWeaponBase;
		[SerializeField] private Transform throwStartPoint;

		public void Throw() {
			if (throwableWeaponBase.TryGetThrowableWeapon(objectInHandController.ObjectInHand
				, out ThrowableWeaponVo throwableWeaponVo)) {
				var position = throwStartPoint.position;
				var rotation = throwStartPoint.localRotation;
				var throwableObject = Instantiate(throwableWeaponVo.projectilePrefab, position, rotation);

				var direction = throwDirection.forward.normalized;
				var force = throwableWeaponVo.forceSpeed;
				var throwableComponent = throwableObject.GetComponent<Throwable>();
				throwableComponent.Throw(direction, force);
				objectInHandController.DeleteObjectInHand();
			}
		}
	}
}