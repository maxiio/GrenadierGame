namespace Db.Object {
	public interface IObjectBase {
		bool HasObject(EObjectType objectType);
		GameObjectVo GetObjectSettings(EObjectType objectType);
	}
}