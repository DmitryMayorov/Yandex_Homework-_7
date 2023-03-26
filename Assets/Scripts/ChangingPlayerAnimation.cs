using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingPlayerAnimation : MonoBehaviour
{
    [SerializeField] public Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ChangPlayerAnimation(1);

            Invoke("FinishAnimationAtacka_1", 1f);
        }
    }

    private void FinishAnimationAtacka_1()
    {
        _animator.SetBool("Atacka_1", false);

        ChangPlayerAnimation(0);
    }

    private void FinishAnimationJump()
    {
        _animator.SetBool("Jump", false);

        ChangPlayerAnimation(0);
    }

    public void ChangPlayerAnimation(int _changingAnimation)
    {
        if (_changingAnimation == 0)
        {
            _animator.SetBool("Idle", true);
        }
        else if (_changingAnimation == 1)
        {
            _animator.SetBool("Atacka_1", true);

            _animator.SetBool("Idle", false);
        }
        else if (_changingAnimation == 2)
        {
            _animator.SetBool("Jump", true);

            _animator.SetBool("Idle", false);
        }
    }
}
