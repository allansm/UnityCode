using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test5 : AI{
	public bool initiate;
	public float vel;
	
	private Vector3 startPos;
    // Start is called before the first frame update
    void Start(){
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update(){
        test();
		test2();
    }
	
	public void test(){
		if(initiate){
			initiate = false;
			GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0,vel));
		}
	}
	public void test2(){
		if(getDistance(startPos,transform.position) > 100){
			transform.position = startPos;
		}
	}
}
