using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemy;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject[] _powerups;

    private Vector3 _spawnLoc;


    private bool _isPlayer = true;
    // Start is called before the first frame update
    public void startSpawning()
    {
        StartCoroutine(spawn());
        StartCoroutine(powerUp());

    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(3.0f);
        while (_isPlayer)
        {

            _spawnLoc = new Vector3(Random.Range(-9.6f, 9.6f), 8.5f, 0);
            GameObject enemyObject = Instantiate(_enemy, _spawnLoc, Quaternion.identity);
            enemyObject.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator powerUp()
    {
        yield return new WaitForSeconds(3.5f);
        while (_isPlayer)
        {
            _spawnLoc = new Vector3(Random.Range(-9.6f, 9.6f), 8.5f, 0);
            int num = Random.Range(0, _powerups.Length);
            Instantiate(_powerups[num], _spawnLoc, Quaternion.identity);
            yield return new WaitForSeconds(10f);
        }
    }

    public void playerDeath()
    {
        _isPlayer = false;
    }
}
