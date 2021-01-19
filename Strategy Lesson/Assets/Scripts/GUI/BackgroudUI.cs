using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackgroudUI : MonoBehaviour 
{
	
	public GUISkin mainUI;
	public int numDepth = 0;
	
	public string nameWindow;
	public Texture2D pictureSelectObject;
    public Sprite pictureSelectObject1;
    public int money;
	public int score;
	
	public Texture2D pictureDefault;
    public Sprite pictureDefault1;
    public RenderTexture map;
	public Material mat;
	
	private GameMenu _GM;
	private GlobalDB _GDB;

    public Image right;
    public Text moneyText;
    public Text scoreText;

	void Start () 
	{
		_GM = gameObject.GetComponent<GameMenu>();
		_GDB = gameObject.GetComponent<GlobalDB>();
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
            _GM.pause = true;
		}
		money = _GDB.money;

        if (pictureSelectObject1 != null)
        {
            if (right.sprite == pictureDefault1)
                right.sprite = pictureSelectObject1;
        }

        moneyText.text = money.ToString();
	}

    public void ButtonMenu ()
    {
        _GM.pause = true;
    }
}
