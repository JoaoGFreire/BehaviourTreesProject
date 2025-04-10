using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employeescript : MonoBehaviour
{
    public float ExploitTime = 0;
    private float timer = 0;
    private bool inside = false;

    public Material defaultMaterial;
    public Material exploitedMaterial;

    private Renderer triggerRender;
    // Start is called before the first frame update
    void Start()
    {
        triggerRender = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inside = true;
            timer = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (inside)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);

            if(timer >= ExploitTime) 
            {
                triggerRender.material = exploitedMaterial;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        // Reset when the object exits the trigger
        if (other.CompareTag("Player"))
        {
            inside = false;
            timer = 0f; // Reset the timer when the object leaves the trigger
            triggerRender.material = defaultMaterial; // Reset to the default material when the object exits
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
