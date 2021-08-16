using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : AI {
    private bool release;
	public void move(float velocity,float x,float y,bool canMove){
        if(canMove){
            release = y==0?true:false;
            print("release"+release+" y"+y);
            //ani.SetBool("running",false);
            if(y > 0 && canMove){
                y = y * velocity * Time.deltaTime;
                transform.Translate(0,0,y);
                //ani.SetBool("running",true);
            }
            if(y < 0 && canMove){
                y = y * velocity * Time.deltaTime;
                if(release){
                    transform.Rotate(0,180,0);
                    release = false;
                }
                transform.Translate(0,0,y*-1);
                //ani.SetBool("running",true);
            }
            if(x != 0 && canMove){
                x*= velocity*10 * Time.deltaTime;
                if(y == 0){
                    transform.Translate(0,0,Vector3.forward.z*velocity*Time.deltaTime);
                }
                transform.Rotate(0,x,0);
                //ani.SetBool("running",true);
            }
        }
	}
	public void move(float velocity,float x,float y,bool canMove,Rigidbody rig){
		rig.constraints =  RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;//RigidbodyConstraints.FreezePositionY ;//| RigidbodyConstraints.FreezeRotationZ;
        if(canMove){
            Vector3 movement = new Vector3 (0.0f, 0.0f, y);
			rig.AddRelativeForce(movement * velocity);
			
			 if(x != 0 && canMove){
                x*= velocity*1 * Time.deltaTime;
                if(y == 0){
                    //transform.Translate(0,0,Vector3.forward.z*velocity*Time.deltaTime);
                }
                transform.Rotate(0,x,0);
				rig.velocity = rig.velocity * 0.98f;
                //ani.SetBool("running",true);
            }
			
        }
	}
}