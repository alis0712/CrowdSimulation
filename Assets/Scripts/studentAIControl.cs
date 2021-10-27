using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class studentAIControl : MonoBehaviour
{

   public GameObject student;
    
    public void OnEnter()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            student.GetComponent<Animator>().Play("hidingMan");
            student.GetComponent<Animator>().Play("hidingGirl");
        }
            
     }

   void Update()
    {
        OnEnter();
    }
}
