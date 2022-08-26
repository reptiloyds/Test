using System.Collections.Generic;
using UnityEngine;

namespace DevelopmentTools
{
	public static class UnityExtensionMethods
	{
		public static void Activate(this GameObject go) => go.SetActive(true);
		public static void Deactivate(this GameObject go) => go.SetActive(false);

		public static T Activate<T>(this T component) where T : Component
		{
			component.gameObject.SetActive(true);
			return component;
		}

		public static bool IsActivate<T>(this T component) where T : Component
		{
			return component.gameObject.activeInHierarchy;
		}

		public static T Deactivate<T>(this T component) where T : Component
		{
			component.gameObject.SetActive(false);
			return component;
		}

		public static T SetActive<T>(this T component, bool active) where T : Component
		{
			component.gameObject.SetActive(active);
			return component;
		}

		public static T SetParent<T>(this T behaviour, Transform parent, bool worldPositionStays = true) where T : MonoBehaviour
		{
			behaviour.transform.SetParent(parent, worldPositionStays);
			return behaviour;
		}

		public static List<GameObject> GetChildren(this GameObject gameObject)
		{
			var result = new List<GameObject>();
			foreach (Transform child in gameObject.transform)
			{
				result.Add(child.gameObject);
			}
			return result;
		}
	}
}
