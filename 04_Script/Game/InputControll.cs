using UnityEngine.EventSystems;
using UnityEngine;

public class InputControll : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField]
	PlayerMove player;
	bool ispressed = false;
	[SerializeField]
	bool left_true;

#region Unity Functions
	private void Update()
	{
		if (!ispressed)
		{
			return ;
		}

		if (!left_true)
		{
			player.horizontalMove = 20f;
		} else {
			player.horizontalMove = -20f;
		}
	}
#endregion

#region Public Functions
	public void OnPointerDown(PointerEventData eventData)
	{
		ispressed = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		ispressed = false;
		player.horizontalMove = 0f;
	}
#endregion
}
