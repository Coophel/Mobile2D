using UnityEngine.EventSystems;
using UnityEngine;

public class AtkBckControll : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
	bool attck_true;
	[SerializeField]
	PlayerCombat player;

	public bool ispressed;

#region Public Functions
	public void OnPointerDown(PointerEventData eventData)
	{
		ispressed = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		ispressed = false;
	}
#endregion
}
