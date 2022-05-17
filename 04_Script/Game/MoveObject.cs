using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
	public Rigidbody rb;
	private GameObject car;
	private Animator carAni;

	public Vector3 rawForce;
	public bool isSelect;
	// dirflag true - Vertical false - Horizontal
	[SerializeField]
	private bool dirflag;
	private int moveCount;

#region Unity Functions
    private void Awake()
    {
        car = this.gameObject;
		carAni = car.GetComponent<Animator>();
		isSelect = false;
    }

	// Start is called before the first frame update
	private void Start()
	{
		// CheckMoveDir();
		rawForce = Vector3.zero;
	}

    // Update is called once per frame
    // private void Update()
    // {
        
    // }

	private void FixedUpdate()
	{
		CarMove();
	}
#endregion

#region Public Functions
	// for managment of Object;
	public bool CheckSelected()
	{
		if (isSelect == true)
			return true;
		else
			return false;
	}

	public void SelectObject()
	{
		Debug.Log(gameObject.transform.name + "Selected => status : " + isSelect);
		if (isSelect == true)
			isSelect = false;
		else
			isSelect = true;
	}

	public void ChangeForce(Vector3 force)
	{
		rawForce = force;
		Debug.Log(rawForce.normalized.x);
	}

	public void CarMove()
	{
		if (rawForce == Vector3.zero)
			return ;
		// Vertical move
		if (dirflag)
		{
			rb.AddForce(Vector3.forward * rawForce.normalized.x * 100f, ForceMode.Acceleration);
		}
		else // Horizontal move
		{
			rb.AddForce(Vector3.right * rawForce.normalized.x * 100f, ForceMode.Acceleration);
		}
	}
#endregion

#region Private Functions
	private void OnCollisionEnter(Collision other)
	{
		ChangeForce(Vector3.zero);

		if (other.gameObject.CompareTag("DestroyZone"))
		{
			other.transform.gameObject.SetActive(false);
		}
	}
#endregion
}
