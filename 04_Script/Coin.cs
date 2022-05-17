using UnityEngine.UI;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public Text coinText;

#region Unity Functions
	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.gameObject.name);
		if (other.transform.tag == "Coin")
		{
			GameManager.Instance.stagegold++;

			coinText.text = GameManager.Instance.stagegold.ToString();

			Destroy(other.gameObject);
		}
	}
#endregion

#region Public Functions

#endregion
}
