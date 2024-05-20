
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float _enemySpeed = 4f;
    private float _lowerBound = -5.3f;
    private float _rightBound = 9.6f;
    private float _leftBound = -9.6f;
    [SerializeField] private float _enemyBase = 7f;

    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        if (transform.position.y < _lowerBound)
        {
            Random rnd = new Random();
            transform.position = new Vector3((float)rnd.Next((int)_leftBound, (int)_rightBound), _enemyBase, 0);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "Player")
        {
            Player player = collider.transform.GetComponent<Player>();
            if (player != null)
            {
                player.damage();
            }
            Destroy(this.gameObject);
        }

        if(collider.tag == "Laser")
        {
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }
    }

}
