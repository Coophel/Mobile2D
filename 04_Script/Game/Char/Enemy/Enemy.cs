using System.Collections;
using UnityEngine;


// To Do List
// Separate State Object to class

public class Enemy : MonoBehaviour
{
	[SerializeField]
	GameObject Coin;

	GameObject player;
	[SerializeField]
	EnemyAttack e_attack;
	[SerializeField]
	public EnemyModule e_style; 	// Choose Fight style by type;

	public CharControll e_Controll;
	public Animator animator;

	[Header("About Status")]
	public float AttackRange;
	public float AttackDelay;
	public float CurrentDelay;
	public float e_MoveSpeed;
	public int MaxHp;
	public int CurrentHp;
	public int Atkdamge;
	public string UsedWeopon;
	public EnemyType eType;

	private float e_Distance;
	private float e_horzion;

 #region Unity Functions
	private void Awake()
	{
		SetEnemy(e_style);
	}

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		CurrentHp = MaxHp;
		CurrentDelay = AttackDelay;
	}

	private void Update()
	{
		e_Distance = Vector2.Distance(player.transform.position, this.transform.position);

		if (e_Distance <= AttackRange + 0.2f)
		{
			CurrentDelay -= Time.deltaTime;
			e_horzion = 0;

			animator.SetInteger("AnimState", 0);
			// if (eType == EnemyType.Archer)
			// {
			// 	e_Controll.m_Rigidbody2D.gravityScale = 0;
			// 	this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
			// }
		}
		else if (player.transform.position.x < transform.position.x)
		{
			e_horzion = -20f;
			animator.SetInteger("AnimState", 2);
		}
		else
		{
			e_horzion = 20f;
			animator.SetInteger("AnimState", 2);
		}
	}

	private void FixedUpdate()
	{
		if (CurrentHp <= 0)
			return ;

		if (CurrentDelay <= 0)
			StartCoroutine("Attack", eType);
		else
			e_Controll.Move(e_horzion * e_MoveSpeed * Time.deltaTime, false);
	}
 #endregion

 #region Public Functions
	public void TakeDamage(int damage)
	{
		animator.SetTrigger("Hurt");
		CurrentHp -= damage;

		if (CurrentHp <= 0)
			StartCoroutine("Death");
	}
 #endregion

 #region Private Functions
	// make Coin
	private void DropCoin()
	{
		int coins = Random.Range(2, 4);
		for (int i = 0; i < coins; i++)
			Instantiate(Coin, this.gameObject.transform.position,Quaternion.identity);
	}
	// Check enemy attack delay && type
	private IEnumerator Attack(EnemyType etype)
	{
		animator.SetTrigger("Attack");
		Debug.Log(gameObject.name + " : Enemy Attack");
		CurrentDelay = AttackDelay;
		yield return new WaitForSeconds(0.3f);
		e_attack.attacking(UsedWeopon);
	}

	private IEnumerator Death()
	{
		var rigi = gameObject.GetComponent<Rigidbody2D>();
		this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
		rigi.gravityScale = 0;
		rigi.bodyType = RigidbodyType2D.Static;

		animator.SetTrigger("Death");
		DropCoin();

		yield return new WaitForSeconds(3f);

		// have to change if use objectpool
		Destroy(this.gameObject);
		// ObjectManager.Instance.KillObject(this);
	}

	private void SetEnemy(EnemyModule temp)
	{
		this.eType = temp.e_type;
		this.MaxHp = temp.MaxHp;
		this.Atkdamge = temp.Attackdamge;
		this.AttackRange = temp.AttackRange;
		this.UsedWeopon = temp.Weapon;
		this.AttackDelay = temp.AttackDelay;
		this.e_MoveSpeed = temp.Move_Speed;
	}

 #endregion
}
