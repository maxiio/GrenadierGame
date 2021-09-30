using System.Collections.Generic;

namespace Db.Object {
	public interface IObjectBase {
		List<ObjectVo> GetObjects { get; }
	}
}