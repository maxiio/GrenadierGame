using System.Collections.Generic;
using UnityEngine;

namespace Util {
	public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour {
		[Header("Settings")]
		[SerializeField] private T prefab;

		private readonly Queue<T> _objectsQueue = new Queue<T>();
		private const int PoolSizeMultiplication = 2;
		
		private int _poolSize = 2;

		private void Awake() {
			InitObjectQueue();
		}

		public T GetObject(Vector3 position) {
			if (_objectsQueue.Count == 0) {
				_poolSize *= PoolSizeMultiplication;
				InitObjectQueue();
			}

			T obj = _objectsQueue.Dequeue();
			obj.gameObject.SetActive(true);
			obj.transform.position = position;
			return obj;
		}

		public void ReturnObject(T obj) {
			obj.gameObject.SetActive(false);
			obj.transform.SetParent(transform);
			obj.transform.position = transform.position;
			obj.transform.rotation = transform.rotation;

			_objectsQueue.Enqueue(obj);
		}

		private void InitObjectQueue() {
			for (int i = 0; i < _poolSize; i++) {
				_objectsQueue.Enqueue(CreateObject());
			}
		}

		private T CreateObject() {
			var obj = Instantiate(prefab, transform);

			obj.transform.SetParent(transform);
			obj.gameObject.SetActive(false);

			return obj;
		}
	}
}