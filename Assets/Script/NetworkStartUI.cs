using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class NetworkStartUI : MonoBehaviour
{
    private void OnGUI()
    {
        float w = 200f, h = 40f;
        float x = 10f, y = 10f; 

        if(!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer) 
        {
            if (GUI.Button(new Rect(x, y, w, h), "Host")) ConnectLAN_Host();
            if (GUI.Button(new Rect(x, y + h + 10, w, h), "Client")) ConnectLAN_Client();
            if (GUI.Button(new Rect(x, y + 2 * (h + 10), w, h), "Server")) NetworkManager.Singleton.StartServer(); 
        }
    }

    public void ConnectLAN_Host() 
    {
        Debug.Log("Connect as Host");

        var utp = NetworkManager.Singleton.GetComponent<UnityTransport>();

        // Host listens on 0.0.0.0 or your LAN IP
        utp.SetConnectionData("0.0.0.0", (ushort)7777);

        NetworkManager.Singleton.StartHost();         
    }

    public void ConnectLAN_Client() 
    {
        Debug.Log("Connect as Client");
        var utp = NetworkManager.Singleton.GetComponent<UnityTransport>();

        utp.SetConnectionData("127.0.0.1", (ushort)7777);

        NetworkManager.Singleton.StartClient();      

    }

}
