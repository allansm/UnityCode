using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class OnlineObjects : BaseOnlineObjects{
	public string getData(string id,GameObject obj,string currentState,string message,string resource){
		return base.getData(id,obj,currentState,message,resource);
	}
	
	public User getUser(string json){
		return base.getUser(json);
	}
	public GameObject instantiate(User user){
		return base.instantiate(user);
	}
	
	public void addObject(GameObject obj){
		base.addObject(obj);
	}
	
	public GameObject[] getObjects(){
		return base.getObjects();
	}
	
	public void setLimit(int limit){
		base.setLimit(limit);
	}
	
	public GameObject findObject(string id){
		return base.findObject(id);
	}
	
	public void setUser(string json){
		base.setUser(json);
	}
	
	public void removeObject(GameObject obj){
		base.removeObject(obj);
	}
	
	public void removeObjects(){
		base.removeObjects();
	}
}