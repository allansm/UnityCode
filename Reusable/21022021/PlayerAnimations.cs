using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : AI{
	private Animator ani;
	private Test test;
	private float x;
	private float y;
	private string currentState;
	public NetworkManager manager;
    // Start is called before the first frame update
    void Start(){
        ani = GetComponent<Animator>();
		test = getPlayer().GetComponent<Test>();
    }

    // Update is called once per frame
    void Update(){
        animate();
    }
	private void animate(){
		ani.SetBool("l",false);
		ani.SetBool("r",false);
		setCurrentState("Entry");
		
		setXY();
		
		if(x>0 && y >0){
			ani.SetBool("l",true);
			setCurrentState("l");
		}
		if(x<0 && y >0){
			ani.SetBool("r",true);
			setCurrentState("r");
		}
		
	}
	public string getCurrentState(){
		return currentState;
	}
	private void setXY(){
		x = test.getX();
		y = test.getY();
	}
	public void setCurrentState(string currentState){
		if(manager != null){
			this.currentState = currentState;
			manager.setCurrentState(currentState);
		}
	}
}
