using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public Animator character1;
    public Animator character2;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            character1.SetTrigger("Action");
            character2.SetTrigger("Action");
        }
    }
}
