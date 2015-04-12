using UnityEngine;
using System;
using System.Collections;

public partial class GameController : SingletonBehaviour<GameController> 
{
	[SerializeField] Prefab dustStormPrefab;
	GameObject dustStorm;
	
	/**
	 * Application Initialize
	 */
	public override void SingleAwake(){

	}

	public void dust(Vector3 position){
		if(dustStorm == null){
			dustStorm = Util.InstantiateTo(this.gameObject, dustStormPrefab);
			dustStorm.transform.position = position;
		}
	}
}

