using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeUser : Util{
	
	UdpConnection con;
	public string message;
	private string lastMsg;
	public bool tryConnect;
	public bool tryDisconnect;
	private GameObject temp;
	private OnlineObjects oo;
	
    // Start is called before the first frame update
    void Start(){
        con = new UdpConnection("127.0.0.1",9800);
		temp = new GameObject();
		temp.name = "fobj";
		oo = gameObject.AddComponent<OnlineObjects>();
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
			if(lastMsg != message){
				lastMsg = message;
				con.write(message);
			}
		}
	}
	
	string fakeData(){
		temp.transform.position = new Vector3(getPlayer().transform.position.x,getPlayer().transform.position.y,(getPlayer().transform.position.z+15));
		temp.transform.rotation = getPlayer().transform.rotation;
		message = oo.getData("fakeUser",temp,getPlayer().GetComponentInChildren<Test4>().getCurrentState(),"","dummy");
		//Destroy(temp);
		return message;
	}
	//public NetworkManager manager;
	/*public string message;
	public bool run;
	private NetworkOutput output;
	private OnlineObjects oo;
	GameObject temp;
	
	
	void Start(){
		//base.Start();
		output = gameObject.AddComponent<NetworkOutput>();
		oo = gameObject.AddComponent<OnlineObjects>();
		ip = "127.0.0.1";
		port = 9800;
		
		NetworkManager tmp = GetComponent<Test11>() as NetworkManager;
		output.setManager(tmp);
		
		temp = new GameObject();
		temp.name = "fobj";
	}
	
	void Update(){
		//base.Update();
		setConnection(ip,port);
		fakeData();
		if(run){
			send();
		}
	}
	
	string fakeData(){
		temp.transform.position = new Vector3(getPlayer().transform.position.x,getPlayer().transform.position.y,(getPlayer().transform.position.z+15));
		temp.transform.rotation = getPlayer().transform.rotation;
		message = oo.getData("fakeUser",temp,"","dummy");
		//Destroy(temp);
		return message;
	}
	
	void send(){
		if(getConnection().connected){
			getConnection().write(fakeData());
		}
	}
	void OnGUI(){
		
	}*/
	/*UdpConnection con;
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
	}*/
}
