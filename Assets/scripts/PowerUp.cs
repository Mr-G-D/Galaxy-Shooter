using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    [SerializeField] private float _id;

    [SerializeField] private AudioClip _powerup_clip;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);

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
            AudioSource.PlayClipAtPoint(_powerup_clip, transform.position);
            _speed = 0;
            if (_id == 0)
            {
                player.TripleShotActive();
            }
            else if(_id == 1)
            {
                player.SpeedPowerActive();
            }
            else if(_id == 2)
            {
                player.SheildPowerActive();
            }
            Destroy(this.gameObject, 0.3f);
        }
    }
}
