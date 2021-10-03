using Db.Weapon;
using Db.Weapon.Impl;
using Game.Player;
using UnityEngine;

namespace Game.Throw {
	public class ThrowItemInHand : MonoBehaviour {
		[SerializeField] private Transform throwDirection;
		[SerializeField] private HandController handController;
		[SerializeField] private ThrowableWeaponBase throwableWeaponBase;
		[SerializeField] private Transform throwStartPoint;

		public void Throw() {
			if (throwableWeaponBase.TryGetThrowableWeapon(handController.ObjectInHand
				, out ThrowableWeaponVo throwableWeaponVo)) {
				var position = throwStartPoint.position;
				var rotation = throwStartPoint.localRotation;
				var throwableObject = Instantiate(throwableWeaponVo.projectilePrefab, position, rotation);

				var objectRigidbody = throwableObject.GetComponent<Rigidbody>();
				var direction = throwDirection.forward.normalized;
				Debug.Log(direction);
				var force = throwableWeaponVo.launchForce;
				objectRigidbody.AddForce(direction * force);
			}
		}
	}
}