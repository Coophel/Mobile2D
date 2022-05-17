using System;
using UnityEngine;

public class ButtonControll : MonoBehaviour
{
	string log;
	public bool login_result = false;

#region Unity Functions
#endregion

#region Public Functions
	// Login Scene Buttons;
	public void Login()
	{
		GPGSBinder.Inst.Login((success, localUser) =>
			login_result = success);

		Debug.Log(login_result);
	}

	public void AfterLoginButton()
	{
		if (login_result)
			GameManager.Instance.PageController.TurnPageOff(PageType.Login_Panel, PageType.Title_Panel);
	}

	// Title Scene Buttons;
	public void StartGame()
	{
		GameManager.Instance.PageController = null;
		SceneController.Instance.LoadScene("GameScene");
		GPGSBinder.Inst.UnlockAchievement("achievement_frist_start", success => log = $"{success}");
	}

	public void StartStory()
	{
		GameManager.Instance.PageController = null;

		// temp to use of test go to GameScene / add Dialog System fot it;
		Debug.Log("Make story mode scene - not ready");
		SceneController.Instance.LoadScene("GameScene");
	}

	public void OptionsPanel()
	{
		GameManager.Instance.PageController.TurnPageOff(PageType.Title_Panel, PageType.Option_Panel);
	}

	public void LeaderPanel()
	{
		GameManager.Instance.PageController.TurnPageOff(PageType.Title_Panel, PageType.LeaderBoard_Panel);
	}

	public void TitlePanel()
	{
		GameManager.Instance.PageController.TurnPageOff(PageType.Option_Panel, PageType.Title_Panel);
	}

	// to get current page then turn off;
	public void TitlePanel(string type)
	{
		foreach (PageType page in Enum.GetValues(typeof(PageType)))
		{
			Debug.Log(page.ToString());
			if (page.ToString() == type)
			{
				GameManager.Instance.PageController.TurnPageOff(page, PageType.Title_Panel);
				break;
			}
		}
	}

	// Game Scene Buttons;
	public void Game_Option()
	{
		GameManager.Instance.PageController.TurnPageOff(PageType.Game_Interface, PageType.Game_Pause);
		Time.timeScale = 0f;
	}

	public void Game_Resume()
	{
		GameManager.Instance.PageController.TurnPageOff(PageType.Game_Pause, PageType.Game_Interface);
		Time.timeScale = 1f;
	}

	public void Game_ToMain()
	{
		Time.timeScale = 1f;
		GameManager.Instance.PageController = null;
		SceneController.Instance.LoadScene("TitleScene");
	}
#endregion

}
