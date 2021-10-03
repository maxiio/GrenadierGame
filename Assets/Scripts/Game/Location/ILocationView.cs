using System.Collections.Generic;
using Game.Location.Place;

namespace Game.Location {
	public interface ILocationView {
		List<ObjectSpawnPoint> ObjectSpawnPoints { get; }
	}
}