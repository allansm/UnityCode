using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1 : MonoBehaviour{
	public int width;
	public int height;
	public bool change;
	public bool fullscreen;
	
	
	void Start(){
		
	}
	
	void Update(){
		changeRes();
	}
	
	void changeRes(){
		if(change){
			change = false;
			Screen.SetResolution(width,height,fullscreen);
			print("changed");
		}
	}
	
	bool showInt;
	void OnGUI(){
		int pos1 = 120;
		if(showInt){
			GUI.Label(new Rect(pos1,10,200,20),"width:");
			width = int.Parse(GUI.TextField(new Rect(pos1,30,200,20),""+width,25));
			GUI.Label(new Rect(pos1,50,200,20),"height:");
			height = int.Parse(GUI.TextField(new Rect(pos1,70,200,20),""+height,25));
			fullscreen = GUI.Toggle(new Rect(pos1,70+40,200,20),fullscreen,"fullscreen");
			
			if(GUI.Button(new Rect(pos1,110+40,100,20),"Change")){
				showInt = false;
				change = true;
			}
		}else{
			if(GUI.Button(new Rect(pos1,10,100,20),"Config")){
				showInt = true;
			}
		}
	}
}