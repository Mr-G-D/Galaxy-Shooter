
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    private float _rightBound = 11.25f;
    private float _leftBound = -11.25f;
    private float _upperBound = 0;
    private float _lowerBound = -4f;

    void Start()
    {
        transform.position = Vector3.zero;
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontal * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * vertical * _speed * Time.deltaTime);

        if(transform.position.x > _rightBound)
        {
            transform.position = new Vector3(_leftBound, transform.position.y, 0);
        }
        if(transform.position.x < _leftBound)
        { 
            transform.position = new Vector3(_rightBound, transform.position.y, 0);
        }
        if(transform.position.y > _upperBound)
        {
            transform.position = new Vector3(transform.position.x, _upperBound, 0);
        }
        if(transform.position.y < _lowerBound)
        {
            transform.position = new Vector3(transform.position.x, _lowerBound, 0);
        }
    }
}
