using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class Test8 : AI{
	private Test6 test;
	public GameObject[] players;
	private int n = 0;
	private int limit = 1;
	private string rec;
	//private bool isPlaying;
	private Thread thread;
	//private bool onetime = true;
	//private int limit = 1;
    // Start is called before the first frame update
    void Start(){
        test = getPlayer().GetComponent<Test6>();
		players = new GameObject[limit];
		
		thread = new Thread(new ThreadStart(receive));
		thread.IsBackground = true;
		
		setCanLog(true);
		
		
    }

    // Update is called once per frame
    void Update(){
		/*isPlaying = true;
		if(onetime){
			onetime = false;
			thread.Start();
		}*/
		if(!thread.IsAlive && this.test.getConnection().connected){
			try{
				thread = new Thread(new ThreadStart(receive));
				thread.IsBackground = true;
				thread.Start();
			}catch(Exception e){
				
			}
		}
        setPlayersValues();
		removePlayers();
    }
	
	void receive(){
		while(true){
			log("t working");
			if(this.test.getConnection().connected){
				try{
					this.rec =  this.test.getConnection().read();
					log("read:"+this.rec);
				}catch(Exception e){
					log("error : "+e.Message);
					this.test.getConnection().connected = false;
				}
			}else{
				break;
			}
			/*if(!isPlaying){
				break;
			}else{
				isPlaying = false;
			}*/
		}
	}
	
	void setPlayersValues(){
		if(test.getConnection().connected){
			//string rec = test.getConnection().read();
			if(this.rec != null){
				log(this.rec);
				try{
					string[] data = this.rec.Split(';');
					this.rec = null;
					string id = data[0];
					if(id != test.identification){
						float x = float.Parse(data[1]);
						float y = float.Parse(data[2]);
						float z = float.Parse(data[3]);
						float rx = float.Parse(data[4]);
						float ry = float.Parse(data[5]);
						float rz = float.Parse(data[6]);
						/*float speed = float.Parse(data[7]);
						float direction = float.Parse(data[8]);
						bool jump = bool.Parse(data[9]);
						bool rest = bool.Parse(data[10]);
						float jumpHeight = float.Parse(data[11]);
						float gravityControl = float.Parse(data[12]);*/
					
						GameObject temp;
						try{
							temp = GameObject.Find(id);
							temp.transform.position = //new Vector3(x,y,z);
							Vector3.Slerp(temp.transform.position,new Vector3(x,y,z),/*Time.deltaTime*/0.05f*10);
							temp.transform.rotation = Quaternion.Euler(new Vector3(rx,ry,rz));
							/*Animator tempAni = temp.GetComponent<Animator>();
							tempAni.SetFloat("Speed",speed);
							tempAni.SetFloat("Direction",direction);
							tempAni.SetBool("Jump",jump);
							tempAni.SetBool("Rest",rest);*/
							//tempAni.SetFloat("JumpHeight",jumpHeight);
							//tempAni.SetFloat("GravityControl",gravityControl);
						}catch(Exception e){
							temp = Instantiate(Resources.Load("dummy"),new Vector3(x,y,z),Quaternion.Euler(new Vector3(rx,ry,rz))) as GameObject;
							temp.name = id;
							if(n < limit){
								players[n++] = temp;
							}
							/*Animator tempAni = temp.GetComponent<Animator>();
							tempAni.SetFloat("Speed",speed);
							tempAni.SetFloat("Direction",direction);
							tempAni.SetBool("Jump",jump);
							tempAni.SetBool("Rest",rest);*/
							//tempAni.SetFloat("JumpHeight",jumpHeight);
							//tempAni.SetFloat("GravityControl",gravityControl);
						}
					}
				}catch(Exception e){
					//test.getConnection().disconnect();
				}
			}
		}else{
			log("disconnected");
		}
	}
	void removePlayers(){
		if(!test.getConnection().connected && players != null){
			for(int i=0;i<=n;i++){
				//try{
					//print("remove player:"+players[i].name);
					Destroy(players[i]);
				//}catch(Exception e){
					//print("erro :"+e.Message);
				//}
			}
			players = new GameObject[5];
			n=0;
		}
	}
}
