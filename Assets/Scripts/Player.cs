using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	[SerializeField] Prefab beamPrefab;
	[SerializeField] Prefab dustStormPrefab;
	[SerializeField] Field field;
	GameObject dustStorm;
	GameObject beamObject;
	[SerializeField] Prefab stonePrefab;
	public int stoneStockSize = 10;

	void Start(){
		beamObject = Util.InstantiateTo (gameObject, beamPrefab);
		Beam beam = beamObject.GetComponent<Beam>();
		beam.OnBeamHit = (RaycastHit hit) => {
			if(dustStorm == null){
				dustStorm = Util.InstantiateTo(field.gameObject, dustStormPrefab);
			}
			dustStorm.transform.position = hit.point;
			stoneStockSize += 1;
		};
		beam.OnBeamMiss = () => {
			if(dustStorm != null) Destroy(dustStorm);
			dustStorm = null;
		};
		beam.OnBeamFinish = () => {
			if(dustStorm != null) Destroy(dustStorm);
			dustStorm = null;
		};
	}
	
	void Update(){
		Vector3 position = this.transform.position;
		position.y += 1;
		position.z += 1;
		beamObject.transform.position = position;
		if(Input.GetMouseButtonDown(1)) {
			if(stoneStockSize > 0) {
				Vector3 forward = transform.forward;
				GameObject stone = (GameObject)Instantiate(stonePrefab, this.transform.position + (forward * 5), this.transform.rotation);
				stoneStockSize -= 1;
			}
		}
	}
}
