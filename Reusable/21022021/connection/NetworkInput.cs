using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NetworkInput : BaseNetworkInput{
	public void Start(){
		base.Start();
	}
	public void Update(){
		base.Update();
	}
	
	public void setManager(NetworkManager manager){
		base.setManager(manager);
	}
	
	public string getMessage(){
		return base.getMessage();
	}
}
