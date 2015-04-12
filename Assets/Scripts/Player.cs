using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[SerializeField] Prefab beamPrefab;
	[SerializeField] Prefab dustStormPrefab;
	GameObject dustStorm;
	GameObject beamObject;
	[SerializeField] Prefab stonePrefab;
	public int stoneStockSize = 10;
	bool isBeamHitting = false;

	void Start(){
		beamObject = Util.InstantiateTo (gameObject, beamPrefab);
		Beam beam = beamObject.GetComponent<Beam>();
		beam.OnBeamHit = (RaycastHit hit) => {
			if(dustStorm == null){
				dustStorm = Util.InstantiateTo(this.gameObject, dustStormPrefab);
				dustStorm.transform.position = hit.point;
			}
			
			isBeamHitting = true;
		};
		beam.OnBeamFinish = () => {
			if(dustStorm != null) Destroy(dustStorm);
			isBeamHitting = false;
		};
	}
	
	void Update(){
		beamObject.transform.position = this.transform.position;
		beamObject.transform.position = this.transform.position;
		if(Input.GetMouseButtonDown(1)) {
			if(stoneStockSize > 0) {
				Vector3 forward = transform.forward;
				GameObject stone = (GameObject)Instantiate(stonePrefab, this.transform.position + (forward * 5), this.transform.rotation);
				stoneStockSize -= 1;
			}
		}
		if(isBeamHitting) {
			stoneStockSize += 1;
		}
	}
}
