using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public abstract class BaseOnlineObjects : BasicFunctions{
	private GameObject[] objects;
	private int n = 0;
	private int limit;
	
		
	protected string getData(string id,GameObject obj,string currentState,string message,string resource){
		User temp = new User();
		temp.id = id;
		temp.position = obj.transform.position;
		temp.rotation = obj.transform.eulerAngles;
		
		temp.currentState = currentState;
		
		temp.message = message;
		temp.resource = resource;
		return JsonUtility.ToJson(temp);
	}
	
	protected User getUser(string json){
		return JsonUtility.FromJson<User>(json);
	}
	protected void setUser(string json){
		User user = getUser(json);
		try{
			GameObject temp = GameObject.Find(user.id);
			temp.transform.position = user.position;
			temp.transform.rotation = Quaternion.Euler(user.rotation);
			if(user.currentState != "Entry"){
				temp.GetComponentInChildren<Animator>().Play(user.currentState);
			}else{
				temp.GetComponentInChildren<Animator>().Rebind();
			}
		}catch(Exception e){
			addObject(instantiate(user));
		}
	}
	protected GameObject instantiate(User user){
		GameObject temp = Instantiate(Resources.Load(user.resource),user.position,Quaternion.Euler(user.rotation)) as GameObject;
		temp.name = user.id;
		return temp;
	}
	
	protected void addObject(GameObject obj){
		if(n < limit){
			objects[n++] = obj;
		}
	}
	
	protected GameObject[] getObjects(){
		return this.objects;
	}
	
	protected void setLimit(int limit){
		this.limit = limit;
		if(objects == null){
			objects = new GameObject[limit];
		}
	}
	
	protected GameObject findObject(string id){
		for(int i=0;i<=n;i++){
			if(objects[i].name == id){
				return objects[i];
			}
		}
		return null;
	}
	
	protected void removeObject(GameObject obj){
		for(int i=0;i<=n;i++){
			if(objects[i].name == obj.name){
				objects[i] = null;
				Destroy(obj);
			}
		}
		GameObject[] temp = objects;		
		objects = new GameObject[limit];
		int size = n;
		n = 0;
		for(int i=0;i<=size;i++){
			if(temp[i].name != null){
				objects[n++] = temp[i];
			}
		}
	}
	
	protected void removeObjects(){
		for(int i=0;i<=n;i++){
			Destroy(objects[i]);
		}
		objects = new GameObject[limit];
		n=0;
	}
}