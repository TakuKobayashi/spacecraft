using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[SerializeField] Prefab beamPrefab;
	[SerializeField] Prefab dustStormPrefab;
	GameObject beamObject;

	void Start(){
		beamObject = Util.InstantiateTo (gameObject, beamPrefab);
		Beam beam = beamObject.GetComponent<Beam>();
		beam.OnBeamHit = (RaycastHit hit) => {
			GameController.Instance.dust (hit.point);
		};
	}
	
	void Update(){
		beamObject.transform.position = this.transform.position;
		beamObject.transform.position = this.transform.position;
	}
}
