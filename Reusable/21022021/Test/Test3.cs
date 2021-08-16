using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : AI{
	//private Test test;
	private ParticleSystem ps;
	private float mx;
	private float mn;
    // Start is called before the first frame update
    void Start(){
        ps = gameObject.GetComponent<ParticleSystem>();
		mx = ps.main.startSize.constantMax;
		mn = ps.main.startSize.constantMin;
		
		//setCanLog(true);
    }

    // Update is called once per frame
    void Update(){
        test();
    }
	public GameObject getPlayer(){
		return GameObject.FindWithTag("Player");
	}
	
	/*public float getPercent(){
			float max = getPlayer().GetComponent<Test>().velocity;
			float current =  getPlayer().GetComponent<Test>().getCurrentVelocity();
			float percent = (1/max) * current;
			//1/2 = 0.5 * 2
			return percent;
	}
	public float getPercent(float max,float current){
		return (1/max) * current;
	}*/
	
	public void test(){
		var main = ps.main;
		float val = mx * getPercent(getPlayer().GetComponent<Test>().velocity,getPlayer().GetComponent<Test>().getCurrentVelocity());
		//log(""+val);
		main.startSize =val;  
	}
	
}
