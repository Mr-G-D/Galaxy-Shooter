using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField]
    private float _speed = 8;

    [SerializeField]
    private float _upperBound = 8;

    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if(transform.position.y > _upperBound)
        {
            Destroy(this.gameObject);
        }
    }
}
