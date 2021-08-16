using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : AI{
	private Transform target;
	public float distance;
    // Start is called before the first frame update
    void Start(){
        target = getMainCamera().transform;//Camera.main.transform;
		setCanLog(false);
    }

    // Update is called once per frame
    void Update(){
        hide();
    }
	/*public float getDiference(float x,float y){
		float val;
		if(x> y){
			val = x - y;
		}else{
			val = y -x;
		}
		return val;
	}
	public float getHigher(float x,float y){
		if(x >y){
			return x;
		}else{
			return y;
		}
	}*/
	//public float getDistance(Vector3 x,Vector3 y){
		/*float val = getDiference(transform.position.x,target.position.x);
		val = getHigher(val,getDiference(transform.position.y,target.position.y));
		val = getHigher(val,getDiference(transform.position.z,target.position.z));
		return val;*/
		//float dist = Vector3.Distance (x,y);
		
		//float val = dist.x;//getDiference(transform.position.x,target.position.x);
		//val = getHigher(val,dist.y);
		//val = getHigher(val,dist.z);
		//return dist;
		
		//return Vector3.Distance (x,y);
	//}
	public void hide(){
		float d = getDistance(GetComponent<Renderer>().bounds.center,target.position);
		string txt = transform.localPosition.x+" "+transform.localPosition.y+" "+transform.localPosition.z;
		log(txt+""+d);
		if(d > distance){
			GetComponent<MeshRenderer>().enabled = false;
			//print("hiding");
		}else{
			GetComponent<MeshRenderer>().enabled = true;
		}
	}
}
