using System;
using System.Collections.Generic;
using UnityEngine;


public class UdpReceiver: MonoBehaviour
{
    public string localIpString = "127.0.0.1";
    public int localPort = 2002;
    public UDPBlendShapeVisualizer uDPBlendShapeVisualizer;

    System.Net.Sockets.UdpClient udp;

    private void Start()
    {
        System.Net.IPAddress localAddress =
            System.Net.IPAddress.Parse(localIpString);

        //UdpClientを作成し、ローカルエンドポイントにバインドする
        System.Net.IPEndPoint localEP =
            new System.Net.IPEndPoint(localAddress, localPort);
        udp = new System.Net.Sockets.UdpClient(localEP);
    }


    private void Update()
    {
        //データを受信する
        System.Net.IPEndPoint remoteEP = null;
        byte[] rcvBytes = udp.Receive(ref remoteEP);

        //データを文字列に変換する
        string rcvMsg = System.Text.Encoding.UTF8.GetString(rcvBytes);

        //受信したデータと送信者の情報を表示する
        Debug.Log("受信したデータ: " + rcvMsg);
        Debug.Log("送信元アドレス: " + remoteEP.Address + ",ポート番号: " + remoteEP.Port);

        uDPBlendShapeVisualizer.Renering(rcvMsg);
    }


    private void OnApplicationQuit()
    {
        udp.Close();
    }
}