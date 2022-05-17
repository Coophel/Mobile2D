using UnityEngine.UI;
using UnityEngine;

public class CheckLogin : MonoBehaviour
{
    [SerializeField]
	Button LoginButton;
	[SerializeField]
	Button MovePageButton;

	[SerializeField]
	ButtonControll myButtons;

#region Unity Functions
	private void Update()
	{
		if (myButtons.login_result)
		{
			LoginButton.gameObject.SetActive(false);
			MovePageButton.gameObject.SetActive(true);
		}
		else
		{
			LoginButton.gameObject.SetActive(true);
			MovePageButton.gameObject.SetActive(false);
		}
	}
#endregion
}
