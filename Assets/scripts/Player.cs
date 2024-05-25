

using UnityEngine;
using Random = System.Random;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private float _rightBound = 11.25f;
    private float _leftBound = -11.25f;
    private float _upperBound = 0;
    private float _lowerBound = -4f;

    [SerializeField]
    private GameObject _laser;


    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1;

    [SerializeField] private int _lives = 3;
    private SpawnManager _spawnManager;

    void Start()
    {
        transform.position = Vector3.zero;
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if(_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is NULL");
        }
        
    }

    void Update()
    {
        playerMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_laser, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }

    }

    void playerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontal * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * vertical * _speed * Time.deltaTime);

        if (transform.position.x > _rightBound)
        {
            transform.position = new Vector3(_leftBound, transform.position.y, 0);
        }
        if (transform.position.x < _leftBound)
        {
            transform.position = new Vector3(_rightBound, transform.position.y, 0);
        }
        if (transform.position.y > _upperBound)
        {
            transform.position = new Vector3(transform.position.x, _upperBound, 0);
        }
        if (transform.position.y < _lowerBound)
        {
            transform.position = new Vector3(transform.position.x, _lowerBound, 0);
        }
    }

    public void damage()
    {
        _lives--;
        if (_lives == 0)
        {
            _spawnManager.playerDeath();
            Destroy(this.gameObject);
        }
    }
}
