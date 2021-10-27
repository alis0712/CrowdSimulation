using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DropEnemy : MonoBehaviour 
{

	public GameObject obstacle;
	GameObject[] agents;
	// Use this for initialization

	void Start () 
	{
		agents = GameObject.FindGameObjectsWithTag("agent");
	}

	public void EvacuationMode()
    {
		
			if (Input.GetKeyDown(KeyCode.Q))
			{
				RaycastHit hitInfo;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
			{
				Instantiate(obstacle, hitInfo.point, obstacle.transform.rotation);
				foreach (GameObject a in agents)
				{
					a.GetComponent<AIControl>().DetectNewObstacle(hitInfo.point);
				}
			}

			}
			
		

	}
	
	// Update is called once per frame
	void Update () 
	{
		EvacuationMode();
	}
	
}
