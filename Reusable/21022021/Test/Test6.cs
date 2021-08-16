using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test6 : BasicFunctions{
	public bool tryConnect;
	public bool tryDisconnect;
	public string ip;
	public int port;
	//public string test;
	//public bool trySend;
	public string identification;
	private UdpConnection con;
	
    // Start is called before the first frame update
    void Start(){
        con = new UdpConnection(ip,port);
    }

    // Update is called once per frame
    void Update(){
        connection();
		//send();
    }
	
	void connection(){
		if(tryConnect){
			tryConnect = false;
			con.connect();
			print("connected");
		}
		if(tryDisconnect){
			tryDisconnect = false;
			con.disconnect();
			print("disconnected");
		}
	}
	
	public UdpConnection getConnection(){
		return this.con;
	}
	/*void send(){
		if(trySend){
			trySend = false;
			con.write(test);
		}
	}*/
	
	bool showInt;
	void OnGUI(){
		if(showInt){
			GUI.Label(new Rect(10,10,200,20),"ip:");
			ip = GUI.TextField(new Rect(10,30,200,20),ip,25);
			GUI.Label(new Rect(10,50,200,20),"name:");
			identification = GUI.TextField(new Rect(10,70,200,20),identification,25);
			if(GUI.Button(new Rect(10,110,100,20),"Connect")){
				tryConnect = true;
				showInt = false;
			}
		}else{
			if(!con.connected){
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
