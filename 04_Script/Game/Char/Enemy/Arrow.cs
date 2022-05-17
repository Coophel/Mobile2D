using UnityEngine;

public class Arrow : MonoBehaviour
{
	[SerializeField]
	bool isXfilped;

	public float MoveSpeed;
	public float RemainTime;

	int Atkdamge;
	Rigidbody2D myrigi;
	bool faceRight;

#region Unity Functions
	private void Start()
	{
		faceRight = gameObject.GetComponentInParent<CharControll>().m_FacingRight;
		gameObject.GetComponent<SpriteRenderer>().flipX = faceRight;
		Atkdamge = gameObject.GetComponentInParent<EnemyAttack>().Atkdamge;
		myrigi = GetComponent<Rigidbody2D>();
		myrigi.mass = Atkdamge;
	}

    // Update is called once per frame
    void Update()
    {
        if (RemainTime >= 0)
			RemainTime -= Time.deltaTime;
		else
		{
			Destroy(gameObject);
		}
    }

	private void FixedUpdate()
	{
		if (!faceRight)
		{
			gameObject.transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
		}
		else
		{
			gameObject.transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
		}
	}
#endregion

#region Public Functions
	public void Blocked()
	{
		Destroy(gameObject);
	}
#endregion
}
