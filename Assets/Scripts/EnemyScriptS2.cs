using System.Collections;
using UnityEngine;

public class EnemyScriptS2 : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource _audio;



    public void OnPointerClick()
    {
      // if (!_audio.isPlaying)
           // _audio.Play();
     //  else
           // _audio.Stop();
        
       if (this.name == "Enemy1S2(Clone)")
        {
            int _currentEnemies1 = GameObject.Find("GameController(Clone)").GetComponent<spawnEnemiesS2>()._currentEnemies1;
            _currentEnemies1--;
            GameObject.Find("GameController(Clone)").GetComponent<spawnEnemiesS2>()._currentEnemies1 = _currentEnemies1;
            GameObject.Find("GameController(Clone)").GetComponent<spawnEnemiesS2>()._enemiesDefeated +=1;
        }
       if (this.name == "Enemy2S2(Clone)")
        {
            int _currentEnemies2 = GameObject.Find("GameController(Clone)").GetComponent<spawnEnemiesS2>()._currentEnemies2;
            _currentEnemies2--;
            GameObject.Find("GameController(Clone)").GetComponent<spawnEnemiesS2>()._currentEnemies2 = _currentEnemies2;
        }
       StartCoroutine(AutoDestruction());
    }


    IEnumerator AutoDestruction()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

}
