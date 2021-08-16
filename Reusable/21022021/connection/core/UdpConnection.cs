using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text;
using System;
 
public class UdpConnection{
	
	public bool connected;
	private UdpClient sock;
	private string ip;
	private int port;
	
	public UdpConnection(string ip,int port){
		this.ip = ip;
		this.port = port;
	}
	public UdpClient dinamicPort(int port){
		
		try{
			return new UdpClient(port++);
		}catch(Exception e){
			
		}
		return dinamicPort(port);
	}
	public void connect(){
		sock = dinamicPort(9999);
		
		try{
			sock.Connect(ip, port);
			connected = true;
		}catch(Exception e){
			connected = false;
		}
	}
	public void setIp(string ip){
		this.ip = ip;
	}
	public void setPort(int port){
		this.port = port;
	}
	public void write(string txt){
		Byte[] sendBytes = Encoding.ASCII.GetBytes(txt);
		sock.Send(sendBytes, sendBytes.Length);
	}
	public string read(){
		IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
		Byte[] receiveBytes = sock.Receive(ref RemoteIpEndPoint);
		return Encoding.ASCII.GetString(receiveBytes);
	}
	
	public void disconnect(){
		if(connected){
			connected = false;
			sock.Close();
		}
	}	
}