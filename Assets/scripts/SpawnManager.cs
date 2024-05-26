using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemy;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject _trhipleShot;

    private Vector3 _spawnLoc;

    private bool _isPlayer = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
        StartCoroutine(tripleShotPower());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawn()
    {
        while (_isPlayer)
        {

            _spawnLoc = new Vector3(Random.Range(-9.6f, 9.6f), 8.5f, 0);
            GameObject enemyObject = Instantiate(_enemy, _spawnLoc, Quaternion.identity);
            enemyObject.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator tripleShotPower()
    {
        while (_isPlayer)
        {
            _spawnLoc = new Vector3(Random.Range(-9.6f, 9.6f), 8.5f, 0);
            Instantiate(_trhipleShot, _spawnLoc, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }

    public void playerDeath()
    {
        _isPlayer = false;
    }
}
