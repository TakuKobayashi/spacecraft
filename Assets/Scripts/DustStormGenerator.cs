using UnityEngine;
using System.Collections;

public class DustStormGenerator : MonoBehaviour {
	
	private bool dustVisible = false;
	[SerializeField] private Prefab dustPrefab;
	private GameObject dustObj;
	// Use this for initialization
	void Start () {
		dustObj = Util.InstantiateTo (gameObject, dustPrefab);
		dustObj.transform.position = this.transform.position;
		dustObj.transform.rotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		moveDustStorm();
	}

	void OnCollisionEnter(Collision collision) {
		showDustStorm();
	}
	
	void OnCollisionExit(Collision collisionInfo) {
		hideDustStorm();
	}
	
	public void showDustStorm() {
		dustVisible = true;
		dustObj.GetComponent<ParticleSystem>().Play();
	}
	
	public void hideDustStorm() {
		dustVisible = false;
		dustObj.GetComponent<ParticleSystem>().Stop();
	}
	
	public void moveDustStorm() {
		dustObj.transform.position = transform.position;
	}
}
