using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerCombat : MonoBehaviour
{
	[SerializeField]
	CharControll p_controll;
	public Animator animator;
	public Transform attackPoint;
	public Transform blockPoint;
	public LayerMask enemyLayers;
	public LayerMask enemyAttacks;
	public AudioClip attackclip;
	public AudioClip blockclip;

	[Header("Status")]
	public float attackRange = 0.4f;
	public Vector2 blockRange = new Vector2(0.5f, 4.5f);
    public int MaxHp = 10;
	public int CurrentHp;
	public float MaxMp = 100f;
	public float CurrentMp;
	public int AttackDamge;

	// hit collider
	private BoxCollider2D m_collider2D;

	private InputAction AtkButton;
	private InputAction BlkButton;

	public UnityEvent OnBlockEvent;

	// to used GetKey in New InputSystem;
	bool blockpress;

#region Unity Functions
	private void Awake()
	{
		m_collider2D = gameObject.GetComponent<BoxCollider2D>();

		AtkButton = GameManager.Instance.TouchControll.Player.Atk;
		BlkButton = GameManager.Instance.TouchControll.Player.Block;

		if (OnBlockEvent == null)
			OnBlockEvent = new UnityEvent();
	}

	private void Start()
	{
		CurrentHp = MaxHp;
		CurrentMp = MaxMp;
		AttackDamge = 1;
		Hpbar.Instance.signHpbar();
		Hpbar.Instance.signMpbar();

		GameManager.Instance.GetStartScore();
	}

	private void OnEnable()
	{
		AtkButton.performed += DoAttack;
		AtkButton.Enable();

		BlkButton.started += StartBlock;
		BlkButton.performed += Blocking;
		BlkButton.canceled += ReleseBlock;
		BlkButton.Enable();
	}
	private void OnDisable()
	{
		AtkButton.Disable();
		BlkButton.Disable();
	}

	private void ReleseBlock(InputAction.CallbackContext obj)
	{
		blockpress = false;
		if (!animator)
			return ;

		animator.SetBool("IdleBlock", false);
		m_collider2D.enabled = true;
	}

	private async void Blocking(InputAction.CallbackContext obj)
	{
		while (blockpress)
		{
			if (!blockPoint)
				return ;
			Collider2D[] hitAttacks = Physics2D.OverlapBoxAll(blockPoint.position, blockRange, 0f, enemyAttacks);

			if (hitAttacks.Length != 0)
				OnBlockEvent.Invoke();

			// for fewer function calls ;
			await System.Threading.Tasks.Task.Delay(50);
		}
	}

	private void StartBlock(InputAction.CallbackContext obj)
	{
		blockpress = true;

		if (!animator)
			return ;

		animator.SetBool("IdleBlock", true);
		m_collider2D.enabled = false;
		Block();
	}



	private void OnTriggerEnter2D(Collider2D other)
	{
		// do not hit at death;
		if (CurrentHp <= 0)
			return ;

		// check hit and take damge
		if (other.gameObject.layer == LayerMask.NameToLayer("EnemyAttack"))
		{
			Debug.Log(other.gameObject.name);
			var enemyAtk = other.GetComponent<Rigidbody2D>();
			TakeDamage((int)enemyAtk.mass);

			Destroy(other.gameObject);
		}
	}
#endregion

#region Public Functions
	public void TakeDamage(int damage)
	{
		CurrentHp -= damage;
		Hpbar.Instance.signHpbar();
		animator.SetTrigger("Hurt");

		if (CurrentHp <= 0)
			StartCoroutine("Death");
	}

	public void DoAttack(InputAction.CallbackContext obj)
	{
		Attack();
	}

	public void GetLight()
	{
		var light = gameObject.GetComponentInChildren<Light2D>();
		
		if (light.enabled)
			light.enabled = false;
		else
			light.enabled = true;
	}

#endregion

#region Private Functions

	public void Attack()
	{
		if (!animator)
			return ;
		animator.SetTrigger("Attack1");

		SoundManager.Instance.PlaySFXSound("Attack", attackclip);

		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
		foreach (var enemy in hitEnemies)
		{
			Debug.Log(enemy.name + "Hit");
			enemy.GetComponent<Enemy>().TakeDamage(AttackDamge);
		}
	}

	public void Block()
	{
		Debug.Log("Blocking");
		// Check enemy attack then "isBlocked" set;
		Collider2D[] hitAttacks = Physics2D.OverlapBoxAll(blockPoint.position, blockRange, 0f, enemyAttacks);

		if (hitAttacks.Length == 0)
			animator.SetBool("isBlocked", false);


		foreach (Collider2D attack in hitAttacks)
		{
			SoundManager.Instance.PlaySFXSound("Block", blockclip);

			Destroy(attack.gameObject);
			animator.SetBool("isBlocked", true);
		}

		animator.SetTrigger("Block");
	}

	// when player death Coroutine;
	private IEnumerator Death()
	{
		animator.SetTrigger("Death");

		p_controll.m_CanControl = false;
		AtkButton.Disable();
		BlkButton.Disable();
		yield return new WaitForSeconds(4.5f);
		
		GameManager.Instance.PageController.TurnPageOff(PageType.Game_Interface, PageType.Game_Over);
		GameManager.Instance.GetFinalScore();

		yield return new WaitForSeconds(2.5f);

		GameManager.Instance.PageController = null;
		// UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("TitleScene", UnityEngine.SceneManagement.LoadSceneMode.Additive);
		SceneController.Instance.LoadScene("TitleScene");
	}

	// Draw range of attack
	private void OnDrawGizmosSelected()
	{
		if (attackPoint == null)
			return ;

		if (blockPoint == null)
			return ;

		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
		Gizmos.DrawWireCube(blockPoint.position, blockRange);
	}
#endregion
}
