using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{

    public string playerName;

    void Start()
    {
        PhotonNetwork.Instantiate(playerName, new Vector3(59.4300003f, 0.731000006f, -53.1699982f), Quaternion.identity, 0);
        Debug.Log("playerName ==" + playerName);
    }

}
