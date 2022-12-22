using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoal : MonoBehaviour
{
    public ParticleSystem source;



    void OnTriggerEnter(Collider other)
    {

        Debug.Log("you win!");
        source.Play();

    }

    // Start is Called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
