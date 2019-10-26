using System;
using UnityEngine;

public class UdpSender: MonoBehaviour
{
    //データを送信するリモートホストとポート番号
    public string remoteHost = "";
    public int remotePort = 0;

    //UdpClientオブジェクトを作成する
    System.Net.Sockets.UdpClient udp;

    private void Start()
    {
        udp = new System.Net.Sockets.UdpClient();
    }


    public void SetRemote(string remoteHost, int remotePort){
        this.remoteHost = remoteHost;
        this.remotePort = remotePort;
    }

    public void Send(string json)
    {
        if(string.IsNullOrWhiteSpace(remoteHost)){
            return;
        }

        byte[] sendBytes = System.Text.Encoding.UTF8.GetBytes(json);

        //リモートホストを指定してデータを送信する
        udp.Send(sendBytes, sendBytes.Length, remoteHost, remotePort);
        Debug.Log("送信: " + json);
    }

    private void OnApplicationQuit()
    {
        //UdpClientを閉じる
        udp.Close();
    }
}
