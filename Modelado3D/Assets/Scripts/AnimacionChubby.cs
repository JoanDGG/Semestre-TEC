using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionChubby : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Gestures", -1);
    }

    // Update is called once per frame
    void Update()
    {
        for( int i = (int) KeyCode.Alpha0 ; i <= (int) KeyCode.Alpha9 ; ++i )
        {
            if( Input.GetKeyDown( (KeyCode) i ))
            {
                animator.SetInteger("Gestures", i - ((int) KeyCode.Alpha0 ));
                StartCoroutine(Reset());
            }
        }
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetInteger("Gestures", -1);
    }
}
