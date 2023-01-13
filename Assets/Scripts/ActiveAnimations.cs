using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAnimations : MonoBehaviour
{

    public Animation Ani;
    // Start is called before the first frame update
    void Start()
    {
        Ani = GetComponent<Animation>();
        Ani.CrossFade("Thriller");
    }

    // Update is called once per frame
    void Update()
    {
        Ani.CrossFade("Thriller");
    }
}
