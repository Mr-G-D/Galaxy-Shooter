

using System.Collections;
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
    [SerializeField] private GameObject _tripleShot;
    private bool _tripleshotpower;
    private bool _speedpower;

    [SerializeField] private GameObject _sheildObject;
    private bool _sheildpower = false;


    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1;

    [SerializeField] private int _lives = 3;
    private SpawnManager _spawnManager;
    private UIManager _uiManager;

    [SerializeField] private int _score;

    [SerializeField] private GameObject _rightEngine;
    [SerializeField] private GameObject _leftEngine;

    [SerializeField] private AudioSource _laser_audio;


    void Start()
    {
        _score = 0;
        _sheildObject.SetActive(false);
        transform.position = Vector3.zero;

        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is NULL");
        }

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uiManager == null)
        {
            Debug.Log(" UI Manager is null");
        }

        _tripleshotpower = false;




    }

    void Update()
    {
        playerMovement();

        fire();

    }

    void fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            if (_tripleshotpower == true)
            {
                Instantiate(_tripleShot, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);

            }
            else
            {
                Instantiate(_laser, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            }

            _laser_audio.Play(0);

        }
    }

    void playerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontal * _speed * Time.deltaTime * (_speedpower == true ? 2 : 1));
        transform.Translate(Vector3.up * vertical * _speed * Time.deltaTime * (_speedpower==true? 2 : 1));

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

        if(_sheildpower == true)
        {
            _sheildObject.SetActive(false);
            _sheildpower = false;
            return;
        }
        _lives--;
        if(_lives == 2)
        {
            _rightEngine.SetActive(true);
        }
        if(_lives == 1)
        {
            _leftEngine.SetActive(true);
        }
        _uiManager.updateLives(_lives);
        if (_lives == 0)
        {
            _spawnManager.playerDeath();
            Destroy(this.gameObject);
        }
    }

    public void scoreUp()
    {
        _score += 10;
        _uiManager.updateScore(_score);

    }


    public void TripleShotActive()
    {
        _tripleshotpower = true;
        StartCoroutine(TripleShotPowerDown());
    }

    public void SpeedPowerActive()
    {
        _speedpower = true;
        StartCoroutine(SpeedPowerDown());
    }

    public void SheildPowerActive()
    {
        _sheildObject.SetActive(true);
        _sheildpower = true;
    }

    IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(5);
        _tripleshotpower = false;
    }

    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(5);
        _speedpower = false;
    }

}
