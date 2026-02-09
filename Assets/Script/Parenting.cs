using Unity.Netcode;
using UnityEngine;

public class Parenting : NetworkBehaviour
{
    
    [ServerRpc(RequireOwnership = false)]
    public void BecomeAChildServerRpc(NetworkObjectReference parentObjectRef) 
    {
        if (parentObjectRef.TryGet(out NetworkObject parentObj)) { transform.SetParent(parentObj.transform); }
    }
    [ServerRpc(RequireOwnership = false)]
    public void BecomeIndependientServerRpc() 
    {
        transform.SetParent(null); 
    }
}
