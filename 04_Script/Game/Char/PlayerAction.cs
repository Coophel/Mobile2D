using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    public InputAction playerAction;

	public static Action OnActionevent;

#region Unity Functions
	private void Start()
	{
		playerAction = GameManager.Instance.TouchControll.Player.Act;
	}
	private void OnEnable()
	{
		playerAction.performed += PressAction;
	}
	private void Update()
	{
		// Debug.Log("Events : " + OnActionevent.);
		Keyboard kb = InputSystem.GetDevice<Keyboard>();
		if (kb.fKey.wasPressedThisFrame)
		{
			Debug.Log("input key : [F]");
			OnActionevent?.Invoke();
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Action"))
		{
			playerAction.Enable();
		}
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Action"))
		{
			playerAction.Disable();
		}
	}
#endregion

#region Public Functions

#endregion

#region Private Functions
	private void PressAction(InputAction.CallbackContext obj)
	{
		Debug.Log("Get Input : button [action]");
		OnActionevent?.Invoke();
	}
#endregion
}
