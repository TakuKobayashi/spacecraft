using UnityEngine;
using System;
using System.Collections;

public class Field : MonoBehaviour
{
	[SerializeField] Prefab field;
	[SerializeField] Vector3 fieldScale;

	void Awake()
	{
		GameObject fieldObject = Util.InstantiateTo(gameObject, field);
		fieldObject.transform.localScale = fieldScale;
	}
}

