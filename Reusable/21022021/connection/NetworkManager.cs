using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class NetworkManager : UdpBaseNetworkManager{
	private NetworkOutput output;
	private NetworkInput input;
	private OnlineObjects oo;
	private string lastMsg;
	private string currentState;
	
	public int maxUsers;
	public GameObject[] onlineObjects;
	
	
	void Start(){
		setCanLog(true);
		output = gameObject.AddComponent<NetworkOutput>();
		input = gameObject.AddComponent<NetworkInput>();
		oo = gameObject.AddComponent<OnlineObjects>();
		
		input.setCanLog(true);
		
		output.setManager(GetComponent<NetworkManager>());
		input.setManager(GetComponent<NetworkManager>());
		
		
		base.Start();
	}
	void Update(){
		
		oo.setLimit(maxUsers);
		onlineObjects = oo.getObjects();
		
		if(!getConnection().connected){
			try{
				oo.removeObjects();
			}catch(Exception e){
				
			}
		}
		
		
		base.Update();
		
		send();
		receive();
	}
	
	public void setCurrentState(string currentState){
		this.currentState = currentState;
	}
	
	public UdpConnection getConnection(){
		return base.getConnection();
	}
	public void setConnection(string ip,int port){
		base.setConnection(ip,port);
	}
	
	void send(){
		if(getConnection().connected){
			string msg = oo.getData(identification,getPlayer(),currentState,"","dummy");
			if(lastMsg != msg){
				getConnection().write(msg);
			}
		}
	}
	
	void receive(){
		if(getConnection().connected){
			string msg = input.getMessage();
			log(msg);
			if(msg != null){
				oo.setUser(msg);
			}
		}
	}
	
	
	void OnGUI(){
		if(showInt){
			GUI.Label(new Rect(10,10,200,20),"ip:");
			ip = GUI.TextField(new Rect(10,30,200,20),ip,25);
			GUI.Label(new Rect(10,50,200,20),"name:");
			identification = GUI.TextField(new Rect(10,70,200,20),identification,25);
			this.name = identification;
			base.setConnection(ip,port);
			if(GUI.Button(new Rect(10,110,100,20),"Connect")){
				tryConnect = true;
				showInt = false;
			}
		}else{
			if(!getConnection().connected){
				if(GUI.Button(new Rect(10,10,100,20),"Login")){
					showInt = true;
				}
			}else{
				if(GUI.Button(new Rect(10,10,100,20),"Disconnect")){
					tryDisconnect = true;
				}
			}
		}
	}
}
