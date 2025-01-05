using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField] private GameObject _asteroid;

    [SerializeField] private GameObject _explosion;

    private SpawnManager _spawnmanager;

    // Start is called before the first frame update
    void Start()
    {
        _spawnmanager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if(_spawnmanager == null)
        {
            Debug.Log("SpawnManager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        _asteroid.transform.Rotate(Vector3.forward * 3 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Laser")
        {
            Destroy(collider.gameObject);
            Vector3 position = this.gameObject.transform.position;
            Instantiate(_explosion, position, Quaternion.identity);
            _spawnmanager.startSpawning();
            Destroy(this.gameObject, 0.25f);
        }
    }
}
