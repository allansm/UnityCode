using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputs : Util{
	public float axisX(){
		return Input.GetAxis("Horizontal");
    }
	public float axisY(){
        return Input.GetAxis("Vertical");
    }
    public bool j(){
        if(Input.GetKeyDown("j")){
           return true;
        }
		return false;
    }
    public bool space(){
        if(Input.GetKeyDown("space")){
           return true;
        }
		return false;
    }
    public bool i(SkillEffect skill){
        if(Input.GetKeyDown("i")){
           return true;
        }
		return false;
    }
   
    public bool x(){
        if(Input.GetKeyDown("x")){
           return true;
        }
		return false;
    }
}
