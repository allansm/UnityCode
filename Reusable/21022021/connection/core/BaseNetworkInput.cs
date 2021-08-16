using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public abstract class BaseNetworkInput : Util{
	private NetworkManager manager;
	private string message;
	private Thread thread;
	
    protected void Start(){
		thread = new Thread(new ThreadStart(receive));
		thread.IsBackground = true;
    }
	
    protected void Update(){
		if(!thread.IsAlive && manager.getConnection().connected){
			try{
				thread = new Thread(new ThreadStart(receive));
				thread.IsBackground = true;
				thread.Start();
			}catch(Exception e){
				log("error : "+e.Message);
			}
		}
    }
	
	protected void setManager(NetworkManager manager){
		this.manager = manager;
	}
	
	protected string getMessage(){
		return this.message;
	}
	
	protected void receive(){
		while(true){
			log("thread working");
			if(this.manager.getConnection().connected){
				log("thread connected");
				try{
					this.message =  this.manager.getConnection().read();
					log("read:"+this.message);
				}catch(Exception e){
					log("error : "+e.Message);
					this.manager.getConnection().connected = false;
				}
			}else{
				break;
			}
		}
	}
}
