using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnEnemiesS5 : MonoBehaviour
{
    // Start is called before the first frame update

    public int _currentEnemies1;
    public int _currentEnemies2;
    public int _enemiesDefeated;
    public int _enemiesDefeated2;
    public GameObject _enemy1;
    public GameObject _enemy2;
    bool _isNewEnemy = false;
    bool _isNewEnemy2 = false;
    void Start()
    {
        _currentEnemies1 = 1;
        _currentEnemies2 = 1;
        _enemiesDefeated = 0;
        StartCoroutine(NewEnemy1());
       // StartCoroutine(NewEnemy2());
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentEnemies1 < 10 && !_isNewEnemy && _enemiesDefeated <=10)
            StartCoroutine(NewEnemy1());
        //if (_currentEnemies2 < 2 && !_isNewEnemy2 && _enemiesDefeated2 <=4)
         //   StartCoroutine(NewEnemy2());

    }

    IEnumerator NewEnemy1()
    {
        _isNewEnemy = true;
        Instantiate(_enemy1, new Vector3(RandomPosicion(11.74f, 19.63f), 12.1f, RandomPosicion(86.46f, 93.28f)),Quaternion.identity);
        _currentEnemies1++;
        yield return new WaitForSeconds(5);
        _isNewEnemy = false;
    }

    IEnumerator NewEnemy2()
    {
        _isNewEnemy2 = true;
        Instantiate(_enemy2, new Vector3(RandomPosicion(46.62f,58), 8.41f, RandomPosicion(12.84f, 20.31f)), Quaternion.identity);
        _currentEnemies2++;
        yield return new WaitForSeconds(5);
        _isNewEnemy2 = false;
    }

    float RandomPosicion(float min, float max)
    {
        float pos = Random.Range(min, max);
        return pos;
        
    }
}
