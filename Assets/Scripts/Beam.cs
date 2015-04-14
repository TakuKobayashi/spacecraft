using UnityEngine;
using System;
using System.Collections;

public class Beam : MonoBehaviour {

	public Action<RaycastHit> OnBeamHit;
	public Action OnBeamMiss;
	public Action OnBeamFinish;
	float effectDisplayTime = 0.2f;
	float range = 100.0f;
	Ray shotRay;
	RaycastHit shotHit;  
	ParticleSystem beamParticle;
	LineRenderer lineRenderer;
	bool isShot = false;
	
	// Use this for initialization
	void Awake () {
		beamParticle = GetComponent<ParticleSystem> ();
		beamParticle.Stop ();
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) || isShot) {
			isShot = true;
			shot ();
		}
		if (Input.GetMouseButtonUp (0)) {
			isShot = false;
			disableEffect ();
		}
	}
	
	private void shot(){
		beamParticle.Stop ();
		beamParticle.Play ();
		lineRenderer.enabled = true;
		lineRenderer.SetPosition (0, transform.position);
		shotRay.origin = transform.position;
		shotRay.direction = transform.forward;
		if (Physics.Raycast (shotRay, out shotHit, range)) {
			// hit
			if (OnBeamHit != null) OnBeamHit (shotHit);
		} else {
			if(OnBeamMiss != null) OnBeamMiss();
		}
		lineRenderer.SetPosition(1 , shotRay.origin + shotRay.direction * range);
	}
	
	private void disableEffect(){
		beamParticle.Stop ();
		lineRenderer.enabled = false;
		if (OnBeamFinish != null) OnBeamFinish ();
	}
}
