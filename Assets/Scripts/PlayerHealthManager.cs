using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public GameObject[] Hearts;

    public static int _indexDestroyedHearts;

    public GameObject _screenDeath;

    public AudioSource _fireballHit;

    private void Start()
    {
        _indexDestroyedHearts = 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);

            EnemyAttack();

            Destroy(collision.gameObject);
        }
    }

    private void EnemyAttack()
    {
        Destroy(Hearts[_indexDestroyedHearts]);

        _indexDestroyedHearts--;

        _fireballHit.Play();

        if (_indexDestroyedHearts == -1)
        {
            _screenDeath.SetActive(true);
        }
    }
}
