using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    [SerializeField] private float _id;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -5.8f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            Player player = collider.transform.GetComponent<Player>();
            if(_id == 0)
            {
                player.TripleShotActive();
            }
            else if(_id == 1)
            {
                player.SpeedPowerActive();
            }
            Destroy(this.gameObject);
        }
    }
}
