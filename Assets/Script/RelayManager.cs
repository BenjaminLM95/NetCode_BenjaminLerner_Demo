using TMPro;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using Unity.Services.Relay.Models;
using Unity.Services.Relay;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP; 

public class RelayManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI joinCodeText;
    [SerializeField] private TMP_InputField joinCodeInputField; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private async void Start()
    {
        await UnityServices.InitializeAsync();

        await AuthenticationService.Instance.SignInAnonymouslyAsync(); 
    }

    public async void StartRelay() 
    {
        string joinCode = await StartHostWithRelay();
        joinCodeText.text = joinCode;
    }

    public async void JoinRelay() 
    {
        await StartClientWithRelay(joinCodeInputField.text); 
    }

    private async Task<string> StartHostWithRelay(int maxConnections = 3) 
    {
        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(maxConnections);        

        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(allocation, "dtls"));

        string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

        return NetworkManager.Singleton.StartHost() ? joinCode : null; 
    }

    private async Task<bool> StartClientWithRelay(string joinCode) 
    {
        JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(joinAllocation, "dtls")); 

        return !string.IsNullOrEmpty(joinCode) && NetworkManager.Singleton.StartClient();
    }

    private void OnGUI()
    {
        float w = 200f, h = 40f;
        float x = 10f, y = 10f;

        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            if (GUI.Button(new Rect(x, y, w, h), "Host")) StartRelay();
            if (GUI.Button(new Rect(x, y + h + 10, w, h), "Client")) JoinRelay();
            if (GUI.Button(new Rect(x, y + 2 * (h + 10), w, h), "Observer")) NetworkManager.Singleton.StartServer();
            
        }
    }
}
