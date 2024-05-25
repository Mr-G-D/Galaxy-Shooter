using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemy;
    [SerializeField] private GameObject _enemyContainer;

    private bool _isPlayer = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawn()
    {
        while (_isPlayer)
        {
            Vector3 vector = new Vector3(Random.Range(-9.6f, 9.6f), 8.5f, 0);
            GameObject enemyObject = Instantiate(_enemy, vector, Quaternion.identity);
            enemyObject.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void playerDeath()
    {
        _isPlayer = false;
    }
}
