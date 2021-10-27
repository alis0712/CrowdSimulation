using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManagerScenario2 : MonoBehaviour
{

    public string playerName;

    void Start()
    {
        PhotonNetwork.Instantiate(playerName, new Vector3(56f, 0.633000016f, -6.9000001f), Quaternion.identity, 0);
        Debug.Log("playerName ==" + playerName);
    }

}
