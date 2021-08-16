using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public abstract class Util : BasicFunctions {
	public GameObject getPlayer(){
		return GameObject.FindWithTag("Player");
	}
	public Camera getMainCamera(){
		return Camera.main;
	}
}
