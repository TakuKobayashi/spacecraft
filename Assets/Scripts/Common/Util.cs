using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Util 
{
	public static void Normalize(Transform t)
	{
		t.localPosition = Vector3.zero;
		t.localEulerAngles = Vector3.zero;
		t.localScale = Vector3.one;
	}

	public static GameObject InstantiateTo(GameObject parent, GameObject go)
	{
		GameObject ins = (GameObject)GameObject.Instantiate(
			go, 
			parent.transform.position, 
			parent.transform.rotation
		);
		ins.transform.parent = parent.transform;
		Normalize(ins.transform);
		return ins;
	}
	public static GameObject InstantiateTo(GameObject parent, Prefab prefab)
	{
		return InstantiateTo(parent, prefab.gameObject);
	}

	public static void Reparent(GameObject parent, GameObject go)
	{
		go.transform.parent = parent.transform;
		Normalize(go.transform);
	}
	
	/// <summary>
	/// 親子関係を外してから削除
	/// </summary>
	/// <param name='parent'>
	/// Parent.
	/// </param>
	public static void DeleteAllChildren(Transform parent)
	{
		List<Transform> transformList = new List<Transform>();
		
		foreach (Transform child in parent) transformList.Add(child);
		
		parent.DetachChildren();
		
		foreach (Transform child in transformList) GameObject.Destroy(child.gameObject);
	}
	public static Transform FindInChildren(Transform root, string name)
	{
		for (int i = 0, count = root.childCount; i < count; ++i)
		{
			Transform t = root.GetChild(i);
			if (t.gameObject.name == name)
				return t;
			
			Transform c = FindInChildren(t, name);
			if (c != null)
				return c;
		}
		
		return null;
	}
	
	public static void ChangeParentAllChildren(Transform from, Transform to)
	{
		for (int i = from.childCount - 1; i >= 0; --i)
		{
			Transform child = from.GetChild(i);
			Vector3 p = child.localPosition;
			Vector3 s = child.localScale;
			Quaternion q = child.localRotation;
			child.parent = to;
			child.localPosition = p;
			child.localScale = s;
			child.localRotation = q;
		}
	}
	
	public static Vector3 Bezier2(Vector3 p1, Vector3 p2, Vector3 p3, float t)
	{
		float rt = 1 - t;
		return t * t * p3 + 2 * t * rt * p2 + rt * rt * p1;
	}

	// 非アクティブオブジェクトからもComponentを取得
	public static List<T> GetAllComponents<T>(GameObject obj) 
	where T : Component 
	{
		T[] list = obj.GetComponentsInChildren<T>(true);
		return new List<T>(list);
	}

	public static Prefab FindPrefabFromName( Prefab[] prefabs,  string name )
	{
		Prefab prefab = null;
		foreach( Prefab p in prefabs )
		{
			if( p == null )	continue; 
			if( p.gameObject == null) continue;
			if( string.Compare( p.gameObject.name, name ) == 0 )
			{
				prefab = p;
				break;
			}
		}
		
		return prefab;
	}
}

