using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial Instance;
    public bool hasClickedOnHome = false;
    public bool showPhoneFunctionality;
    public bool hasClickedOnSchool;
    public bool hasClickedCafe;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void CheckEndOfConvos()
    {
        if (hasClickedOnHome && showPhoneFunctionality && hasClickedOnSchool && hasClickedCafe)
        {
            DialogManager.Instance.FindQueueConversation("FairyEndTutorial", GameStaticData.Instance.Conversations);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickedOnHome()
    {
        if (hasClickedOnHome) return;
        hasClickedOnHome = true;
        DialogManager.Instance.FindAndStartConversation("HouseClick", GameStaticData.Instance.Conversations);
        CheckEndOfConvos();
    }

    public void PromptToClickPhone()
    {
        if (showPhoneFunctionality) return;
        showPhoneFunctionality = true;
        DialogManager.Instance.FindAndStartConversation("PromptShowPhone", GameStaticData.Instance.Conversations);
        CheckEndOfConvos();
    }
    
    public void ClickedOnSchool()
    {
        if (hasClickedOnSchool) return;
        hasClickedOnSchool = true;
        DialogManager.Instance.FindAndStartConversation("ClickedOnSchool", GameStaticData.Instance.Conversations);
        CheckEndOfConvos();
    }
    
    public void ClickOnCafe()
    {
        if (hasClickedCafe) return;
        hasClickedCafe = true;
        DialogManager.Instance.FindAndStartConversation("CafeLines", GameStaticData.Instance.Conversations);
        CheckEndOfConvos();
    }
}
