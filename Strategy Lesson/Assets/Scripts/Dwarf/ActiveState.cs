using UnityEngine;
using System.Collections;

public class ActiveState: MonoBehaviour {

    public enum enAnimation
    {
        idle,
        move,
        attact,
        charge
    }
    public enAnimation animationState;

    private Stats _st;

    private UnityEngine.AI.NavMeshAgent _agent;

    private int _damage;
    
	void Start () {
        _st = gameObject.GetComponent<Stats>();
        _agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        _damage = gameObject.GetComponent<Stats>().damage;
	}
	
	void Update () 
    {
	    if (_st.instruction == Stats.enInstruction.idle)
        {
            animationState = enAnimation.idle;
        }
        else if (_st.instruction == Stats.enInstruction.move)
        {
            animationState = enAnimation.move;
            if (Vector3.Distance(_st.targetVector, transform.position) > 1)
            {
                _agent.SetDestination(_st.targetVector);
            }
            else
            {
                _agent.Stop();
                _agent.ResetPath();
                _st.instruction = Stats.enInstruction.idle;
            }
        }
        else if (_st.instruction == Stats.enInstruction.attack)
        {
            if (_st.targetTransform == null)
            {
                _st.instruction = Stats.enInstruction.idle;
                _agent.Stop();
                _agent.ResetPath();
            }
            else
            {
                if (Vector3.Distance(_st.targetTransform.position, transform.position) > 2)
                {
                    _agent.SetDestination(_st.targetTransform.position);
                    animationState = enAnimation.move;
                }
               
                else
                {
                    _agent.Stop();
                    _agent.ResetPath();
                    animationState = enAnimation.attact;
                    if (!IsInvoking("Attack"))
                    {
                        Invoke("Attack",0.9f);
                    }
                }
            }
        }
	}

    void Attack()
    {
        _st.targetTransform.gameObject.GetComponent<Stats>().ReceivingDamage(_damage);
    }
}
