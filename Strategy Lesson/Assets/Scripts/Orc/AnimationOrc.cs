using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOrc : MonoBehaviour
{
    private ActiveState _AS;
    private Animator _anim;

    // Use this for initialization
    void Start()
    {
        _AS = gameObject.GetComponent<ActiveState>();
        _anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_AS.animationState == ActiveState.enAnimation.idle)
        {
            _anim.SetBool("Idle", true);
            _anim.SetBool("Walk", false);
            _anim.SetBool("Attack", false);
            _anim.SetBool("Charge", false);
        }
        if (_AS.animationState == ActiveState.enAnimation.move)
        {
            _anim.SetBool("Idle", false);
            _anim.SetBool("Walk", true);
            _anim.SetBool("Attack", false);
            _anim.SetBool("Charge", false);
        }
        if (_AS.animationState == ActiveState.enAnimation.attact)
        {
            _anim.SetBool("Idle", false);
            _anim.SetBool("Walk", false);
            _anim.SetBool("Attack", true);
            _anim.SetBool("Charge", false);
        }
        if (_AS.animationState == ActiveState.enAnimation.charge)
        {
            _anim.SetBool("Idle", false);
            _anim.SetBool("Walk", true);
            _anim.SetBool("Attack", false);
            _anim.SetBool("Charge", true);
        }
    }
}
