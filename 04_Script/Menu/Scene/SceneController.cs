using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

	public static SceneController Instance
	{
		get
		{
			if (instance == null)
			{
				var obj = FindObjectOfType<SceneController>();
				if (obj != null)
				{
					instance = obj;
				}
				else
				{
					instance = Create();
				}
			}
			return instance;
		}
	}

	[SerializeField]
	private CanvasGroup canvasGroup;
	[SerializeField]
	private Image progressBar;

	private string loadSceneName;

#region Unity Functions
	private void Awake()
	{
		if (Instance != this)
		{
			Destroy(gameObject);
			return ;
		}
		DontDestroyOnLoad(gameObject);
	}
#endregion

#region Public Functions
	public void LoadScene(string SceneName)
	{
		Debug.Log (SceneName + "Loading Start!~");
		gameObject.SetActive(true);
		SceneManager.sceneLoaded += OnSceneLoaded;
		loadSceneName = SceneName;
		StartCoroutine(LoadSceneProcess());
	}


	#endregion

	#region Private Functions
	private IEnumerator Fade(bool isFadeIn)
	{
		float timer = 0f;
		while (timer <= 1f)
		{
			yield return null;
			timer += Time.unscaledDeltaTime * 3f;
			canvasGroup.alpha = isFadeIn ? Mathf.Lerp(0f, 1f, timer) : Mathf.Lerp(1f, 0f, timer);
		}

		if (!isFadeIn)
		{
			gameObject.SetActive(false);
		}
	}

	private IEnumerator LoadSceneProcess()
	{
		progressBar.fillAmount = 0f;
		yield return StartCoroutine(Fade(true));

		AsyncOperation ao = SceneManager.LoadSceneAsync(loadSceneName);
		ao.allowSceneActivation = false;

		float timer = 0f;
		while (!ao.isDone)
		{
			Debug.Log(loadSceneName + " Loading : " + ao.progress);

			yield return null;
			if (ao.progress < 0.9f)
			{	
				progressBar.fillAmount = ao.progress;
			}
			else
			{
				timer += Time.unscaledDeltaTime;
				progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
				if (progressBar.fillAmount >= 1f)
				{
					ao.allowSceneActivation = true;
					yield break;
				}
			}
		}
	}

	private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
		Debug.Log(arg0.name + "Loaded fin");
		if (arg0.name == loadSceneName)
		{
			StartCoroutine(Fade(false));
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}
	}

	private static SceneController Create()
	{
		return Instantiate(Resources.Load<SceneController>("LoadingCanvas"));
	}
#endregion
}
