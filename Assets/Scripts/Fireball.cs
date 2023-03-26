using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float _speed = 7;

    private string _side;

    void Start()
    {
        if (transform.position.x < 0)
        {
            _side = "Lefthand";
        }
        else if (transform.position.x > 0)
        {
            _side = "Right";

            Flip();
        }

        Invoke("Selfdestruct", 3);
    }

    private void Update()
    {
        if (_side == "Lefthand")
        {
            transform.position = transform.position + new Vector3(_speed * Time.deltaTime, 0, 0);
        }
        else if (_side == "Right")
        {
            transform.position = transform.position - new Vector3(_speed * Time.deltaTime, 0, 0);
        }
    }

    private void Flip()
    {
        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

    private void Selfdestruct()
    {
        Destroy(gameObject);
    }
}