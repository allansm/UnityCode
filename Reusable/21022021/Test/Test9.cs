using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test9 : AI{
	UdpConnection con;
	public string txt;
	private string lastMsg;
	public bool tryConnect;
	public bool tryDisconnect;
    // Start is called before the first frame update
    void Start(){
         con = new UdpConnection("127.0.0.1",9800);
    }

    // Update is called once per frame
    void Update(){
        simulate();
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
	void simulate(){
		fakeData();
		connection();
		if(con.connected){
			//string msg = txt;
			if(lastMsg != txt){
				lastMsg = txt;
				con.write(txt);
			}
		}
	}
	void fakeData(){
		txt = 
		"fakeUser;"+
		getPlayer().transform.position.x+";"+
		getPlayer().transform.position.y+";"+
		(getPlayer().transform.position.z+15)+";"+
		getPlayer().transform.eulerAngles.x+";"+
		getPlayer().transform.eulerAngles.y+";"+
		getPlayer().transform.eulerAngles.z;
	}
}
