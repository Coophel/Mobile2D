using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System;

public class LightControll : MonoBehaviour
{
	[SerializeField]
    Light2D lamp_light;

	// public bool touchflag;
	public int lamp_onCoin;

#region Unity Functions
	private void Start()
	{
		lamp_light.intensity = 1.5f;
	}

	private void Update()
	{
		if (lamp_light.intensity <= 0)
			return;
		lamp_light.intensity -= Time.deltaTime * 0.1f;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			// var myevent = other.gameObject.GetComponent<PlayerAction>();
			PlayerAction.OnActionevent += trunOnLamp;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			// var myevent = other.gameObject.GetComponent<PlayerAction>();
			PlayerAction.OnActionevent -= trunOnLamp;
		}
	}
#endregion

#region Public Functions
	public void trunOnLamp()
	{
		Debug.Log("Get event by light");
		lamp_light.intensity = 1.5f;
	}

	// public void trunOnLamp(int coin)
	// {
	// 	if (coin < lamp_onCoin)
	// 		return;

	// 	GameManager.Instance.stagegold -= lamp_onCoin;
	// 	lamp_light.intensity = 1.5f;
	// }
#endregion

#region Private Functions

#endregion
}
