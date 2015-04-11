using UnityEngine;
using System.Collections;

public class DustStormGenerator : MonoBehaviour {
	
	private bool dustVisible = false;
	private GameObject dustPrefab;
	private GameObject dustObj;
	// Use this for initialization
	void Start () {
		dustPrefab = (GameObject)Resources.Load("ParticleSystems/Prefabs/DustStorm");
		dustObj = (GameObject)Instantiate(dustPrefab, transform.position, transform.rotation);
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
