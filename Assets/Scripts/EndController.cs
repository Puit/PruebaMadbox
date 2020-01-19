using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{
    public ParticleSystem p1, p2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Emit(bool e)
    {
        if(e)
        {
            //p1.Emit(1);

            p2.Emit(1);
        }
    }
}
