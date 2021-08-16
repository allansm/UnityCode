using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicFunctions : MonoBehaviour{
    private bool canLog;
	
	public void log(string msg){
		if(canLog){
			print(msg);
		}
	}
	
	public void setCanLog(bool canLog){
		this.canLog = canLog;
	}
	
	public float getDiference(float x,float y){
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
	}
	
	public float getPercent(float max,float current){
		return (1/max) * current;
	}
	
}
