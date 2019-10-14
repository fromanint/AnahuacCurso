using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapFrida : MonoBehaviour
{
    [SerializeField] Animator frida_anim;
    [SerializeField] Animator m_Animator;
    [SerializeField] float movingSpeed;
    int state = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (transform.GetComponent<Collider>().Raycast(ray, out hit, 10000f))
            {
                //Send the message to the Animator to activate the trigger parameter named "Crouch"
                frida_anim.SetTrigger("Tap");
                //Reset the "Jump" trigger

                if (m_Animator.speed == 0 && state == 2)
                {
                    m_Animator.speed = movingSpeed;
                }
                else
                {
                    m_Animator.speed = 0;
                }
                state++;
                if (state > 2)
                { state = 0; }
                //frida_anim.ResetTrigger("Tap");
                Debug.Log("Test1");
            }

        }
    }
}