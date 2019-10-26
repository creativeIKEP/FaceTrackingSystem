using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IPSet : MonoBehaviour
{
    public InputField ipAdress;
    public InputField portNo;
    public UdpSender udpSender;

    public void Set(){
        udpSender.SetRemote(ipAdress.text, int.Parse(portNo.text));
    }
}
