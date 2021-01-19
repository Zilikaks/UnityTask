using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {
	
	public GameObject _currentBuild;
	public LayerMask mask;
	
	private GlobalDB _GDB;

	// Use this for initialization
	void Start () {
		_GDB = GameObject.FindGameObjectWithTag("MainUI").GetComponent<GlobalDB>();
	}
	
	// Update is called once per frame
	void Update () {
		if(_currentBuild != null)
		{
			Ray ray;
			RaycastHit hit;
			
			ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 10000.0f, mask))
			{
				_currentBuild.transform.position = hit.point;
			}
			
			if(Input.GetMouseButtonDown(0))
			{
                _GDB.DeactivationInterface();
                
                if (_GDB.numIntersection != 0)
                {
                    Destroy(_currentBuild);
                    _currentBuild = null;
                    _GDB.numIntersection = 0;
                    _GDB.deactivationTrigger();
                    _GDB.obj.RemoveAt(_GDB.obj.Count - 1);
                }
                else
                {
                    if (_currentBuild.name == "Tower(Clone)" || _currentBuild.name == "OrcTower(Clone)")
                        _currentBuild.GetComponent<Tower>().enabled = true;
                    _currentBuild.tag = "Building";
                    _currentBuild = null;
                    _GDB.deactivationTrigger();
                }
            }
		}
	}
	
	public void setBuild (GameObject go, Shop sh = null)
	{
		_currentBuild = Instantiate(go);
		_currentBuild.tag = "CurBuild";
		if(sh != null)
			sh.curFlag = _currentBuild;
		_GDB.activationTrigger();
	}
}
