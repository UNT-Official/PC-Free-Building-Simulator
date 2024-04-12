using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] private int distance = 5;
	[SerializeField] private GameObject PickPos;
	[SerializeField] private GameObject PickedObject;
	[SerializeField] private bool Picked;
	
    private void Update()
    {
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, distance))
			{
				if(hit.collider.gameObject.GetComponent<Item>() && Picked == false)
				{
					PickUp(hit.collider.gameObject);
				}
			}
		}
		else if((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Ended) && (Picked == true))
		{
			Drop();
		}
    }
	
	private void PickUp(GameObject HitObj) {
		PickedObject = HitObj;
		PickPos.GetComponent<SpringJoint>().connectedBody = HitObj.GetComponent<Rigidbody>();
		PickedObject.transform.parent = PickPos.transform;
		Picked = true;
	}
	
	private void Drop() {
		PickPos.GetComponent<SpringJoint>().connectedBody = null;
		PickedObject.transform.SetParent(null);
		PickedObject = null;
		Picked = false;
	}
}