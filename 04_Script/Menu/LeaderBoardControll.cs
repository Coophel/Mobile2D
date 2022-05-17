using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardControll : MonoBehaviour
{
	[SerializeField]
	Text[] leadertexts;

#region Unity Functions
	private void OnEnable()
	{
		GetLeadernums();
	}

	// Init textfield by "0";
	private void OnDisable()
	{
		foreach (Text text in leadertexts)
		{
			text.text = "0";
		}
	}
#endregion

#region Public Functions
	public void GetLeadernums()
	{
		GPGSBinder.Inst.LoadCustomLeaderboardArray(GPGSIds.leaderboard_game_score, 5,
			GooglePlayGames.BasicApi.LeaderboardStart.PlayerCentered, GooglePlayGames.BasicApi.LeaderboardTimeSpan.AllTime,
			(success, scoreData) => 
			{
				Debug.Log("Get LeaderBoard : " + success);
				if (success == false)
					return;
				var scores = scoreData.Scores;
				for (int i = 0; i < scores.Length; i++)
				{
					Debug.Log($"{i}, {scores[i].rank}, {scores[i].value}, {scores[i].date}");
					leadertexts[i].text = $"{scores[i].rank} - {scores[i].value} - {scores[i].date}";
				}

				for (int i = scores.Length; i <= 5; i++)
					leadertexts[i].text = "None";
			});
	}
#endregion
}
