using System.Collections;
using UnityEngine;

public enum PageType
{
	None,
	Login_Panel,
	Title_Panel,
	Option_Panel,
	LeaderBoard_Panel,
	Game_Interface,
	Game_Pause,
	Game_Over
}

public class Page : MonoBehaviour
{
    public PageType type;
}
