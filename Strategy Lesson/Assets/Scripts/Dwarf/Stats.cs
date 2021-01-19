using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Stats : MonoBehaviour {
	
	public float curHealth;
	public float maxHealth;
	public float lengthHealth;
	public int protect;
	public int damage;
	
	public Texture2D icon;

    public enum enInstruction
    {
        idle,
        move,
        attack,
        charge
    }
    public enInstruction instruction;
    public Transform targetTransform;
    public Vector3 targetVector;
	
	private GlobalDB _GDB;



	// Use this for initialization
	void Start () 
	{
		_GDB = GameObject.FindGameObjectWithTag("MainUI").GetComponent<GlobalDB>();
		_GDB.enemyList.Add(gameObject);
        _GDB.dwarfList.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0)
        {
            gameObject.tag = "Terrain";
            _GDB.enemyList.Remove(gameObject);
            _GDB.dwarfList.Remove(gameObject);
            gameObject.GetComponent<Animator>().SetBool("Death", true);
            Invoke("Dead", 0);
        }
    }

    void Dead()
    {
        // gameObject.GetComponent<Animator>().enabled = false;
        if (TryGetComponent(out AnimationOrc help))
        {
            help.enabled = false;
        }
        if (TryGetComponent(out AnimationDwarf help2))
        {
            help2.enabled = false;
        }
        gameObject.GetComponent<CharacterController>().enabled = false;
        gameObject.GetComponent<Stats>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        gameObject.GetComponent<ActiveState>().enabled = false;
       // gameObject.transform.position = new Vector3(0, -100, 0);
    }

    public void SelectPlayer ()
	{
		Projector proj = transform.Find("Projector").GetComponent<Projector>();
		if(proj.enabled == false)
		{
			proj.enabled = true;
			_GDB.selectList.Add(gameObject);
		}
		else 
		{
			proj.enabled = false;
		}
	}

    public void ReceiptDamage (int dam)
    {
        curHealth = Mathf.Max(curHealth - (dam - protect), 0);
    }

    public void Healing(int health)
    {
        curHealth = Mathf.Min(curHealth + health, maxHealth);
    }

    public void ReceivingDamage(int recDamage)
    {
        curHealth -= recDamage * ((100 - protect) / 100f);
    }
}
