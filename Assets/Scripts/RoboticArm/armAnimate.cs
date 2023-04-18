using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class armAnimate : MonoBehaviour
{
    [SerializeField] GameObject robotArm;
    [SerializeField] GameObject robotHand;
    [SerializeField] TMP_Text text;

    private Animator armAnim;
    private Animator leverAnim;
    private Animator handAnim;

    private armController armScript;
    private robothandController handScript;

    private bool lowered = false;
    private bool gripped = false;

    private void Awake()
    {
        armScript = robotArm.GetComponent<armController>();
        handScript = robotHand.GetComponent<robothandController>();

        armAnim = robotArm.GetComponent<Animator>();
        leverAnim = gameObject.GetComponent<Animator>();
        handAnim = robotHand.GetComponent<Animator>();

    }

    void Update()
    {
        
    }

    //Function to decide whether to rise or lower
    public void adjustHeight()
    {
        Debug.Log("Button Function Called");
        Debug.Log(armScript.lowered);
        //If not lowered and animation not currently playing, lower
        if (!(armScript.lowered) && !(armAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1))
        {
            Lower();
            return;
        }

        //If lowered and animation not currently playing, rise
        if ((armScript.lowered) && !(armAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1))
        {
            Rise();
        }
    }

    //Lower the arm
    public void Lower()
    {
        
        armAnim.Play("Lower", 0, 0.0f);
        leverAnim.Play("downLever", 0, 0.0f);
        armScript.lowered = true;
        text.text = "Lowering arm...";
        
       
    }

    //Raise the Arm
    public void Rise()
    {
     
        armAnim.Play("Rise", 0, 0.0f);
        leverAnim.Play("upLever", 0, 0.0f);
        armScript.lowered = false;
        text.text = "Raising arm...";
        
    }

    public void adjustHand()
    {
        
       //If not gripped and animation not currently playing, grip
        if (!(handScript.gripped) && !(handAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1))
        {
            closeHand();
            return;
        }

        //If gripped and animation not currently playing, ungrip
        if ((handScript.gripped) && !(handAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1))
        {
            openHand();
        }
    }

    public void closeHand()
    {
        handAnim.Play("CloseHand", 0, 0.0f);
        handScript.gripped = true;
    }

    public void openHand()
    {
        handAnim.Play("OpenHand", 0, 0.0f);
        handScript.gripped = false;
    }
}
