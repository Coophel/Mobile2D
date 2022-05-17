using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwpon : MonoBehaviour
{
	[SerializeField]
	Transform point;
	[SerializeField]
	GameObject player;

#region Unity Functions
	private void Start()
	{
		Instantiate(player, point);
	}
#endregion
}
