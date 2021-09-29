using System.Collections.Generic;
using Game.Location.Place;
using UnityEngine;

namespace Game.Location.Impl {
	public class LocationView : MonoBehaviour, ILocationView {
		[SerializeField] private List<ObjectSpawnPoint> objectSpawnPoints;

		public List<ObjectSpawnPoint> ObjectSpawnPoints => objectSpawnPoints;
	}
}