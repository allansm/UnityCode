using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public abstract class AI : Util {
	/*public GameObject getPlayer(){
		return GameObject.FindWithTag("Player");
	}
	public Camera getMainCamera(){
		return Camera.main;
	}*/
	public float getDistance(Vector3 x,Vector3 y){
		float dist = Vector3.Distance (x,y);
		return dist;
	}
	public void placeAt(Transform obj,Transform target){
		obj.position = target.position;
		obj.rotation = target.rotation;
	}
	public void placeAtMe(Transform target){
		target.position = transform.position;
		target.rotation = transform.rotation;
	}
	public void placeMeAt(Transform target){
		transform.position = target.position;
		transform.rotation = target.rotation;
	}
	//follow target position
	public void followTarget(Transform target,float velocity){
		transform.position = Vector3.Slerp(transform.position,target.position,/*Time.deltaTime*/0.05f*velocity);
	}
	public void followTarget(Transform target){
		GetComponent<NavMeshAgent>().SetDestination(target.position);
	}
	//rotate slowly agaist target 
	public void rotateAtTarget(Transform player,float velocity){
		transform.rotation = Quaternion.Lerp(transform.rotation,player.rotation,velocity*Time.deltaTime);
	}
	//rotate fast to target
	public void lookAtTarget(Transform target){
		Vector3 t = target.transform.position;
		t = new Vector3(target.transform.position.x,transform.position.y,target.transform.position.z);
		transform.LookAt(t);
	}
	public void push(Transform target){
		Vector3 forward = target.forward;
		//target.Translate(0,0,forward.z*-10f);
		target.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0,Vector3.forward.z*-500f));
	}
    public void push(Transform target,float force){
        Vector3 forward = target.forward;
		//target.Translate(0,0,forward.z*-10f);
		target.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0,Vector3.forward.z*force));
    }
}
