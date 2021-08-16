using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Test7 : BasicFunctions{
	Test6 test;
	public string pInfo;
	public string lastMsg;
    // Start is called before the first frame update
    void Start(){
        test = GetComponent<Test6>();
		setCanLog(true);
    }

    // Update is called once per frame
    void Update(){
        setOwnValues();
		send();
    }
	
	void setOwnValues(){
		pInfo = 
		test.identification+";"+
		this.transform.position.x+";"+
		this.transform.position.y+";"+
		this.transform.position.z+";"+
		this.transform.eulerAngles.x+";"+
		this.transform.eulerAngles.y+";"+
		this.transform.eulerAngles.z;
	}
	
	void send(){
		if(test.getConnection().connected){
			try{
				if(pInfo != null){
					//print("writed:"+pInfo);
					if(lastMsg != pInfo){
						lastMsg = pInfo;
						test.getConnection().write(pInfo);
					}
				}
			}catch(Exception e){
				//connected = false;
				test.getConnection().disconnect();
				log("disconnect by error:"+e.Message);
			}
		}
	}
}
