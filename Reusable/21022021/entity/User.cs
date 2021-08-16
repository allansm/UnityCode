using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters;
using System;
using System.Runtime;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;


[Serializable]
public class User{
	public string id;
	public Vector3 position;
	public Vector3 rotation;
	public string currentState;
	public string message;
	public string resource;
}
