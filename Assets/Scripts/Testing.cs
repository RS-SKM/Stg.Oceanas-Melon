using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
	DialogueSystem dialogue;
	
    // Start is called before the first frame update
    void Start()
    {
        dialogue = DialogueSystem.instance;
    }

public string[] s = new string[]
	{		
		"Sir! Our radar navigation system is offline!:Crew Member",
		"What! How the hell did that happen!?:The General",
		"We were having a water gun fight in the navigation room...:Crew Member",
		"What the-!:The General",
		"Go to the control room and put her in stationary!",
		"Ohh... We-we had a water gun fight in that room too…:Crew Member",
		"GOD DAMN IT! WHAT THE HELL ARE YOU ALL THINKING!?:The General",
		"Turn on all exterior lights, and get Sergeant Oceana in here!",
		"Ye-yes sir!:Crew Member",
		"*excited dolphin noises*:Stg.Oceana’s",
		"Okay Sergeant, we are moving into a naval minefield without a radar.So we need you to get out there and navigate, use your melon to echolocate,:The General",
		"NOW STEP UP AND SHOW ME YOUR WAR FACE!",
		"*dutiful dolphin noises*:Stg.Oceana’s"
		
	};

	int index = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
			{
				if(index>= s.Length)
				{
					return;
				}
				
				Say(s[index]);
				index++;
				
			}
		}
    }

	void Say(string s)
	{
		string[] parts = s.Split(':');
		string speech = parts[0];
		string speaker = (parts.Length >= 2)? parts[1] : "";
		
		dialogue.Say(speech, speaker);
	}


}

