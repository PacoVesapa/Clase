using Unity.Cinemachine;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public CinemachineCamera camara;

    public void InvertirCamara()
    {
        var Follow = camara.GetComponent<CinemachineFollow>();
        if (Follow != null)
        {
            Follow.FollowOffset.y = -4;
        }
    }
    public void CamaraNormal()
    {
        var Follow = camara.GetComponent<CinemachineFollow>();
        if (Follow != null)
        {
            Follow.FollowOffset.y = 4;
        }
    }
}
