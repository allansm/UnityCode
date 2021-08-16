using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : BaseMovement{
	public float velocity;
	public Transform startPosition;
	private float x;
	private float y;
	private float currentVelocity;
	private Rigidbody rig;
	//public Animator ani;
	
    // Start is called before the first frame update
    void Start(){
        currentVelocity = 0;
		rig = GetComponent<Rigidbody>();
		placeMeAt(startPosition);
    }

    // Update is called once per frame
    void Update(){
		reduceRigidbodyVel();
        axisXY();
		test();
    }
	
	//remove animator
	public void axisXY(){
		//temp
		//ani.SetBool("l",false);
		//ani.SetBool("r",false);
		
		if(Input.GetKey("k")){
			y = 1;
		}else{
			y=0;
		}
		x = Input.GetAxis("Horizontal");
		float factor = 0.01f;
		if(y > 0){
			if(currentVelocity < velocity){
				currentVelocity += velocity * factor;
			}else{
				currentVelocity = velocity;
			}
		}else{
			currentVelocity -= currentVelocity * (factor*10);
		}
		currentVelocity = (currentVelocity < 0)?0:currentVelocity;
        move(currentVelocity,x,y,true,rig);
		//temporary
		/*if(x>0 && y >0){
			ani.SetBool("l",true);
		}
		if(x<0 && y >0){
			ani.SetBool("r",true);
		}*/
    }
	
	public float getX(){
		return this.x;
	}
	
	public float getY(){
		return this.y;
	}
	
	public float getCurrentVelocity(){
		return this.currentVelocity;
	}
	
	public void reduceRigidbodyVel(){
		 rig.velocity = rig.velocity * 0.98f;
		 //print(rig.velocity.z);
	}
	public void test(){
		if(transform.position.y < -10){
			rig.isKinematic = true;
			placeMeAt(startPosition);
			rig.isKinematic = false;
		}
	}
}
