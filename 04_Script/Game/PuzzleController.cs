using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
	[SerializeField]
	List<MoveObject> Vehicles;
	Vector3 dragStartPos;
	Touch touch;

#region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        InitStage();
    }

    // Update is called once per frame
    void Update()
    {
        OnTouch();
    }
#endregion

#region Private Functions

	// get objects at frist time;
	private void InitStage()
	{
		Vehicles = new List<MoveObject>();
		var vc = this.gameObject.GetComponentsInChildren<MoveObject>();
		foreach (var MyObject in vc)
		{
			Vehicles.Add(MyObject);
		}
	}

	private void OnTouch()
	{
		// Single Touch;
		if (Input.touchCount == 1)
		{
			Debug.Log("Single touch");
			touch = Input.GetTouch(0);
			RaycastHit rayhit;
			var ray = Camera.main.ScreenPointToRay(touch.position);

			// Checking object is Selected;
			var mySelected = GetSelectedObject();

			// Care of DragInput;
			if (mySelected != null)
			{
				Debug.Log("DragInput");
				if (touch.phase == TouchPhase.Began)
					DragStart();
				if (touch.phase == TouchPhase.Moved)
					Dragging();
				if (touch.phase == TouchPhase.Ended)
					DragRelease(mySelected);
			}	// Care of point touch;
			else if (Physics.Raycast(ray, out rayhit))
			{
				Debug.Log(rayhit.transform.name);
				if (rayhit.transform.CompareTag("DynamicObject"))
				{
					rayhit.transform.GetComponent<MoveObject>().SelectObject();
				}
				else
				{
					RipSelected();
				}
			}
		} // Multi Touch
		else if (Input.touchCount > 1)
		{
			Debug.Log("Muti touch");
			return ;
		}
	}

	private void DragStart()
	{
		dragStartPos = Camera.main.ScreenToViewportPoint(touch.position);
		dragStartPos.y = 5; // drag pos y->5 ... for look lineRender
		// lr.positionCount = 1;
		// lr.SetPosition(0, dragStartPos);
	}

	private void Dragging()
	{
		Vector3 draggingPos = Camera.main.ScreenToViewportPoint(touch.position);
		draggingPos.y = 5; // drag pos y->5 ... for look lineRender
		// lr.positionCount = 2;
		// lr.SetPosition(1, draggingPos);
	}

	private void DragRelease(MoveObject myobject)
	{
		// lr.positionCount = 0;

		Vector3 dragReleasePos = Camera.main.ScreenToViewportPoint(touch.position);
		dragReleasePos.y = 5;

		Vector3 force = dragStartPos - dragReleasePos;

		// Check sort drag to cancel select
		if (Mathf.Abs(force.magnitude) < 0.1f)
		{
			myobject.SelectObject();
			return ;
		}
		force.Normalize();

		myobject.ChangeForce(force);
	}

	private MoveObject GetSelectedObject()
	{
		foreach(var select in Vehicles)
		{
			if (select.CheckSelected())
				return select;
		}
		return null;
	}

	private void RipSelected()
	{
		foreach(var select in Vehicles)
		{
			if (select.CheckSelected())
				select.SelectObject();
		}
	}
#endregion
}
