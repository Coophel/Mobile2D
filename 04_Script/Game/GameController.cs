using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public List<MoveObject> Vehicle;
	Vector3 dragStartPos;
	Touch touch;
	public LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnSingleTouch();
    }
#region Private Functions
	private void OnSingleTouch()
	{
		if (Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);
			RaycastHit rayhit;
			var ray = Camera.main.ScreenPointToRay(touch.position);

			// if (select) get Drag force and move selected object; 수정해야함
			foreach(var x in Vehicle)
			{
				if (x.CheckSelected())
				{
					if (touch.phase == TouchPhase.Began)
						DragStart();
					if (touch.phase == TouchPhase.Moved)
						Dragging();
					if (touch.phase == TouchPhase.Ended)
						DragRelease(x);
				}
			}

			if (Physics.Raycast(ray, out rayhit))
			{
				if (rayhit.transform.CompareTag("DynamicObject"))
				{
					rayhit.transform.GetComponent<MoveObject>().SelectObject();
				}
			}
		}
		else
			return ;
	}

	private void DragStart()
	{
		dragStartPos = Camera.main.ScreenToViewportPoint(touch.position);
		dragStartPos.y = 5; // drag pos y->5
		lr.positionCount = 1;
		lr.SetPosition(0, dragStartPos);
	}

	private void Dragging()
	{
		Vector3 draggingPos = Camera.main.ScreenToViewportPoint(touch.position);
		draggingPos.y = 5; // drag pos y->5
		lr.positionCount = 2;
		lr.SetPosition(1, draggingPos);
	}

	private void DragRelease(MoveObject myobject)
	{
		lr.positionCount = 0;

		Vector3 dragReleasePos = Camera.main.ScreenToViewportPoint(touch.position);
		dragReleasePos.y = 5;

		Vector3 force = dragStartPos - dragReleasePos;

		// Check sort drag to cancel select  수정 필요
		if (Mathf.Abs(force.magnitude) < 0.1f)
		{
			myobject.SelectObject();
			return ;
		}
		force.Normalize();

		myobject.ChangeForce(force);
	}
#endregion
}
