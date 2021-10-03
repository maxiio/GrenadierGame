using System;
using Db.Respawn.Implementation;
using Game.Location.Impl;
using UnityEngine;

namespace Game.Spawner {
	public class RespawnManager : MonoBehaviour {
		[SerializeField] private RespawnBase respawnBase;
		[SerializeField] private LocationView locationView;
		
		private void FixedUpdate() {
						
		}
	}
}