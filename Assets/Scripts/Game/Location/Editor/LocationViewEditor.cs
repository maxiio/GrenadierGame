using System.Collections.Generic;
using Game.Location.Impl;
using UnityEditor;
using UnityEngine;

namespace Game.Location.Editor {
	[CustomEditor(typeof(LocationView))]
	public class LocationViewEditor : UnityEditor.Editor {
		public override void OnInspectorGUI() {
			if (GUILayout.Button("Collect ObjectSpawnPoints"))
				CollectObjectSpawnPoints();

			base.OnInspectorGUI();
		}

		private void CollectObjectSpawnPoints() {
			if (!(target is LocationView locationView)) return;
			EditorCollect(locationView.ObjectSpawnPoints);
			serializedObject.ApplyModifiedProperties();
		}

		private void EditorCollect<TComponent>(List<TComponent> list)
			where TComponent : Component {
			var view = (LocationView)target;
			var components = view.GetComponentsInChildren<TComponent>();
			list.Clear();
			foreach (var comp in components) {
				list.Add(comp);
			}

			EditorUtility.SetDirty(view);
		}
	}
}