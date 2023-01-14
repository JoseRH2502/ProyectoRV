using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject _GameController;
    void Start()
    {
        StartCoroutine(StartG());
    }

    IEnumerator StartG()
    {
        
        yield return new WaitForSeconds(5);
        Instantiate(_GameController);

    }
}
