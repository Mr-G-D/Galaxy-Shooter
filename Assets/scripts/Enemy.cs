
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float _enemySpeed = 4f;
    private float _lowerBound = -5.3f;
    private float _rightBound = 9.6f;
    private float _leftBound = -9.6f;
    [SerializeField] private float _enemyBase = 7f;

    private Animator _anim;


    void Start()
    {
        _anim = GetComponent<Animator>();
        if(_anim == null)
        {
            Debug.Log("Animator is null");
        }
    }

    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        if (transform.position.y < _lowerBound)
        {
            Random rnd = new Random();
            transform.position = new Vector3((float)rnd.Next((int)_leftBound, (int)_rightBound), _enemyBase, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            Player player = collider.transform.GetComponent<Player>();
            if (player != null)
            {
                player.damage();
            }
            _enemySpeed = 0;
            _anim.SetTrigger("EnemyBlast");
            Destroy(this.gameObject, 2.8f);
        }

        if(collider.tag == "Laser")
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            player.scoreUp();
            Destroy(collider.gameObject);
            _enemySpeed = 0;
            _anim.SetTrigger("EnemyBlast");
            Destroy(this.gameObject, 2.8f);
        }

    }

}
