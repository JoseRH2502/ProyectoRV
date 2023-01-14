using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptS4 : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource _audio;



    public void OnPointerClick()
    {
        // if (!_audio.isPlaying)
        // _audio.Play();
        //  else
        // _audio.Stop();

        if (this.name == "Enemy1S3(Clone)")
        {
            int _currentEnemies1 = GameObject.Find("GameController(Clone)").GetComponent<spawnEnemiesS4>()._currentEnemies1;
            _currentEnemies1--;
            GameObject.Find("GameController(Clone)").GetComponent<spawnEnemiesS4>()._currentEnemies1 = _currentEnemies1;
            GameObject.Find("GameController(Clone)").GetComponent<spawnEnemiesS4>()._enemiesDefeated += 1;
        }
        if (this.name == "Enemy2S3(Clone)")
        {
            int _currentEnemies2 = GameObject.Find("GameController(Clone)").GetComponent<spawnEnemiesS4>()._currentEnemies2;
            _currentEnemies2--;
            GameObject.Find("GameController(Clone)").GetComponent<spawnEnemiesS4>()._currentEnemies2 = _currentEnemies2;
        }
        StartCoroutine(AutoDestruction());
    }


    IEnumerator AutoDestruction()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
