using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[SerializeField] Beam beam;
	[SerializeField] Prefab dustStormPrefab;
	GameObject dustStorm;

	void Start(){
		beam.OnBeamHit = (RaycastHit hit) => {
			if(dustStorm == null){
				dustStorm = Util.InstantiateTo(this.gameObject, dustStormPrefab);
				dustStorm.transform.position = hit.point;
			}
		};
		beam.OnBeamFinish = () => {
			if(dustStorm != null){
				dustStorm = null;
				Destroy(dustStorm);
			}
		};
	}
	
	void Update(){
		beam.transform.position = this.transform.position;
		beam.transform.position = this.transform.position;
	}
}
