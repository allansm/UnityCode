using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System;
 
public class TcpConnection{
	private StreamWriter writer;
	private StreamReader reader = null;
	public bool connected;
	private TcpClient sock;
	private string ip;
	private int port;
	
	public TcpConnection(string ip,int port){
		this.ip = ip;
		this.port = port;
	}
	
	public void connect(){
		try{
			sock = new TcpClient();
			sock.Connect(IPAddress.Parse(ip),port);	
			writer = new StreamWriter(sock.GetStream());
			reader = new StreamReader(sock.GetStream());
			connected = true;
		}catch(Exception e){
			connected = false;
		}
	}
	public void write(string txt){
		writer.WriteLine(txt);
		writer.Flush();
	}
	public string read(){
		return reader.ReadLine();
	}
	
	public void disconnect(){
		if(connected){
			connected = false;
			sock.Close();
		}
	}
}
 
