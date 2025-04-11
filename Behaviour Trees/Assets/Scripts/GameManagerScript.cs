using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float ExploitedEmployees = 0;
    public TextMeshProUGUI ExploitedScoreText;

    //public Receiver receiverl;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExploitedScoreText.text ="Exploited Employees: "+ExploitedEmployees.ToString();
    }

    public void AddExploitedEmployee()
    {
        ExploitedEmployees++;
    }
    public void DecreaseExploitedEmployee()
    {
        ExploitedEmployees--;
    }
    public float GetExploitedAmount()
    {
        return ExploitedEmployees;
    }

}
