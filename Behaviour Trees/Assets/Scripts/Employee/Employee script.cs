using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employeescript : MonoBehaviour
{
    public float ExploitTime = 0;
    public float UnionExploitTime = 0;
    private float timer = 0;
    private bool inside = false;
    private bool exploited;
    private bool unionized;

    public GameObject Employee;
    public GameObject gameManager;

    public Material defaultMaterial;
    public Material exploitedMaterial;
    public Material UnionizedMaterial;

    private Renderer triggerRender;
    public Renderer employeerender;

    // Start is called before the first frame update
    void Start()
    {
        triggerRender = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //if player is inside of radius
        {
            inside = true;
            timer = 0;
        }
    }
    private void OnTriggerStay(Collider other) //if player stays inside of the radius
    {
        if (inside)
        {
            timer += Time.deltaTime; //start timer
            Debug.Log(timer);

            if(timer >= ExploitTime && unionized != true) //if timer reaches determined time
            {
                timer = 0;
                //exploited = true;
                //gameManager.SendMessage("AddExploitedEmployee");
                //triggerRender.material = exploitedMaterial;
                Exploit(); //exploit worker
            }
            else if(timer >= UnionExploitTime && unionized == true)
            {
                timer = 0;
                Exploit();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        // Reset timer once player leaves radius
        if (other.CompareTag("Player"))
        {
            inside = false;
            timer = 0f; 
            //triggerRender.material = defaultMaterial; 
        }
    }

    public void Unionize() //change to unionized material
    {
        employeerender.material = UnionizedMaterial;
    }

    private void Exploit() //Set the employee as exploited
    {
        exploited = true;
        gameManager.SendMessage("AddExploitedEmployee"); //tells game manager to increase the tally of exploited employees
        triggerRender.material = exploitedMaterial;
    }

    public void Reset() //resets employee to default state
    {
        gameObject.tag = "Untagged";
        exploited = false;
        unionized = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (exploited) //makes sure that if employee is ever exploited they are correctly considered so by the code
        {
            gameObject.tag = "Exploited";
            triggerRender.material = exploitedMaterial;
        }
        if (unionized) //makes sure that if employee is ever unionized they are correctly considered so by the code
        {
            gameObject.tag = "Unionized";
        }
    }
}
