using Game.Throwing;
using UnityEngine;

namespace Game.Weapon {
	public abstract class AGrenade : Throwable {
		[SerializeField] private GameObject explosionFxPrefab;
		
		private void OnCollisionEnter(Collision collision) {
			Explosion(collision);
		}

		protected abstract void OnExplosion(Collision collision);

		private void Explosion(Collision collision) {
			CreateFx();
			OnExplosion(collision);
			Destroy(gameObject);
		}

		private void CreateFx() {
			var explosionFx = Instantiate(explosionFxPrefab);
			explosionFx.transform.position = transform.position;
			explosionFx.SetActive(true);
		}
	}
}