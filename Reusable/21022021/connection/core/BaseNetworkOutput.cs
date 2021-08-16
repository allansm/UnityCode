using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseNetworkOutput : BasicFunctions{
	private NetworkManager manager;
	
	protected void setManager(NetworkManager manager){
		this.manager = manager;
	}
	
	protected void send(string message){
		if(manager.getConnection().connected){
			try{
				manager.getConnection().write(message);
			}catch(Exception e){
				log("disconnect by error:"+e.Message);
			}
		}
	}
}
