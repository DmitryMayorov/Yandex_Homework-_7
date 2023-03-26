using UnityEngine;
using TMPro;

public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private GameObject _screenVictory;

    public GameObject[] enemy;

    public GameObject[] spawnposision;

    public float TimerTimer;

    private float Timer;

    private int random;

    private int randomPosition;

    private int CounterProjectilesFired = 10;

    private void Start()
    {
        Timer = TimerTimer;
    }

    private void Update()
    {
        if (Timer <= 0 && PlayerHealthManager._indexDestroyedHearts != -1 && CounterProjectilesFired != 0)
        {
            random = Random.Range(0, enemy.Length);

            randomPosition = Random.Range(0, spawnposision.Length);

            Instantiate(enemy[random], spawnposision[randomPosition].transform.position, Quaternion.identity);

            Timer = TimerTimer;

            Invoke("ReduceCounterProjectilesFired", 1.5f);
        }
        else
        {
            Timer -= Time.deltaTime;
        }
    }

    private void ReduceCounterProjectilesFired()
    {
        CounterProjectilesFired--;

        UpdatingText();

        if (CounterProjectilesFired == 0)
        {
            _screenVictory.SetActive(true);
        }
    }

    private void UpdatingText()
    {
        _text.text = "осталость пережить: " + CounterProjectilesFired;
    }
}
