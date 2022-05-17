using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public CharControll controller;
	public Animator animator;

	[SerializeField]
	private float runSpeed;
	public float horizontalMove = 0f;

#region Unity Functions
	private void Update()
	{
		// horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetInteger("AnimState", (int)horizontalMove);
	}

	private void FixedUpdate()
	{
		controller.Move(horizontalMove * runSpeed * Time.fixedDeltaTime, false);
	}
#endregion

#region Public Functions
	public void OnLanding()
	{
		animator.SetBool("Grounded", true);
	}
#endregion

#region Private Functions
#endregion
}
