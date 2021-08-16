using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UdpBaseNetworkManager : Util{
	public bool tryConnect;
	public bool tryDisconnect;
	public string ip;
	public int port;
	public string identification;
	private UdpConnection connection;
	public bool showInt;
	
    protected void Start(){
        connection = new UdpConnection(ip,port);
    }

    protected void Update(){
        connectionSwitch();
    }
	
	
	protected void connectionSwitch(){
		if(tryConnect){
			tryConnect = false;
			connection.connect();
			log("connected");
		}
		if(tryDisconnect){
			tryDisconnect = false;
			connection.disconnect();
			log("disconnected");
		}
	}
	
	protected UdpConnection getConnection(){
		return this.connection;
	}
	
	protected void setConnection(string ip,int port){
		connection.setIp(ip);
		connection.setPort(port);
	}
}
