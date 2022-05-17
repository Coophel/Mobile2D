using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public PageController PageController;

	[SerializeField]
	public TouchControlls TouchControll;


	public bool startflag;
	public int gamepoint;
	public int stagegold = 0;


#region Unity Functions
	private void Awake()
	{
		TouchControll = new TouchControlls();
	}

    private void Start()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	private void Update()
	{
		if (!startflag)
			return ;
		else
		{
			gamepoint += (int)Time.deltaTime;
		}
	}
#endregion

#region Public Functions
	public void GetStartScore()
	{
		startflag = true;
		gamepoint = 0;
		stagegold = 5;
	}

	public void GetFinalScore()
	{
		startflag = false;
		gamepoint += stagegold;
		GPGSBinder.Inst.ReportLeaderboard(GPGSIds.leaderboard_game_score, gamepoint,
			success => Debug.Log("Upload leaderBoard" + success));
	}
#endregion
}
