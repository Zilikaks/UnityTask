using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Castle : MonoBehaviour {
	
	public bool visible = false;
	public Texture2D tex;
	public string nameCastle;
	public int xp;
	public int protection;
	public int lvl;
	public int costUp;
	public int costMining;
	public int costTower;
	public int costShop;
	public int costMagic;
	public GameObject mining;
	public GameObject tower;
	public GameObject shop;
	public GameObject magic;
	public GameObject lvl2;
	public GameObject lvl3;
    public Text nameText;
    public Text hpText;
    public Text protectionText;
    public Text lvlText;
    public Text uiCostUp;
    public Text uiCostMining;
    public Text uiCostTower;
    public Text uiCostShop;
    public Text uiCostMagic;
    public GameObject uiObject;
    private GlobalDB _GDB;
	private Select _SEL;

    // Use this for initialization
    void Start () {
		_GDB = GameObject.FindGameObjectWithTag("MainUI").GetComponent<GlobalDB>();
		_SEL = GameObject.FindGameObjectWithTag("MainUI").GetComponent<Select>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        nameText.text = nameCastle;
        hpText.text = xp.ToString();
        protectionText.text = protection.ToString();
        lvlText.text = lvl.ToString();
        if (!visible && uiObject.activeSelf)
            uiObject.SetActive(false);
        else if (visible && !uiObject.activeSelf)
            uiObject.SetActive(true);

        uiCostUp.text = costUp.ToString();
        uiCostMining.text = costMining.ToString();
        uiCostTower.text = costTower.ToString();
        uiCostShop.text = costShop.ToString();
        uiCostMagic.text = costMagic.ToString();
    }
	
	void OnMouseDown ()
	{
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            _SEL.ClearSelect();
            if (_GDB.activeObjectInterface != null)
                _GDB.DeactivationInterface();
            _GDB.activeObjectInterface = gameObject;
            visible = true;
            GameObject.FindGameObjectWithTag("MainUI").GetComponent<BackgroudUI>().pictureSelectObject = tex;
        }
	}
    

    public void ButtonUp ()
    {
        if (_GDB.activeObjectInterface != gameObject)
            return;
        if (_GDB.money >= costUp && lvl < 3)
        {
            if (lvl == 1)
            {
                lvl++;
                lvl2.SetActive(true);
                xp += 500;
                protection += 5;
                costUp += 500;
            }
            else
            if (lvl == 2)
            {
                lvl++;
                lvl3.SetActive(true);
                xp += 700;
                protection += 8;
            }
            _GDB.money -= costUp;
        }
    }

    public void ButtonMine()
    {
        Destroy(Camera.main.GetComponent<BuildManager>()._currentBuild);
        _GDB.numIntersection = 0;
        if (_GDB.money >= costMining)
        {
            Camera.main.GetComponent<BuildManager>().setBuild(mining);
            _GDB.money -= costMining;
        }
    }

    public void ButtonTower()
    {
        Destroy(Camera.main.GetComponent<BuildManager>()._currentBuild);
        _GDB.numIntersection = 0;
        if (_GDB.money >= costTower)
        {
            Camera.main.GetComponent<BuildManager>().setBuild(tower);
            _GDB.money -= costTower;
        }
    }

    public void ButtonShop()
    {
        Destroy(Camera.main.GetComponent<BuildManager>()._currentBuild);
        _GDB.numIntersection = 0;
        if (_GDB.money >= costShop)
        {
            
            Camera.main.GetComponent<BuildManager>().setBuild(shop);
            _GDB.money -= costShop;
        }
    }

    public void ButtonMagic()
    {
        Destroy(Camera.main.GetComponent<BuildManager>()._currentBuild);
        _GDB.numIntersection = 0;
        if (_GDB.money >= costMagic)
        {
            Camera.main.GetComponent<BuildManager>().setBuild(magic);
            _GDB.money -= costMagic;
        }
    }
}
