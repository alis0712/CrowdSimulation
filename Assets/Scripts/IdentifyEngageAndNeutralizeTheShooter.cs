using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class IdentifyEngageAndNeutralizeTheShooter : MonoBehaviourPunCallbacks
{
    public InputField createRoomTxt, joinRoomTxt;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void CreateRoom()// We hit Create room Button
    {
        string roomName = createRoomTxt.text;
        PhotonNetwork.CreateRoom(roomName);
    }

    public void JoinRoom() // We hit join room button
    {
        string roomName = joinRoomTxt.text;
        PhotonNetwork.JoinRoom(roomName);
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
       
        Debug.Log("We joined the room");

        //change scene
        SceneManager.LoadScene("Identify, Engage and Neutralize The Shooter");
    }
    
}