using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Testing : MonoBehaviour
{
	DialogueSystem dialogue;
	public GameObject spawnCrewSprite;
	public GameObject crewLocation;
	public GameObject spawnGeneralSprite;
	public GameObject generalLocation;
	public GameObject spawnOceanaSprite;
	public GameObject oceanaLocation;
	
    // Start is called before the first frame update
    void Start()
    {
        dialogue = DialogueSystem.instance;
	
    }

public string[] s = new string[]
	{		
			
		"Sir! Our navigation system is offline!:Crew Member",
			
		"What! How the hell did that happen!?:The General",
		
		"We were having a water gun fight in the navigation room...:Crew Member",
		
		"What the-! Go to the control room and put her in stationary!:The General",
		
		"Ohh... We-we had a water gun fight in that room too…:Crew Member",
		
		"WHAT IN TARNATION! WHAT THE HELL WERE YOU ALL THINKING!?:The General",
		
		"Turn on all exterior lights, and somebody get Sergeant Oceana in here!",
		
		"Ye-sir, yes sir!:Crew Member",
		
		"*excited dolphin noises*:Stg.Oceana’s",
		
		"Okay Sergeant, we are moving into a naval minefield without a radar.So we need you to get out there and navigate, so use your melon to echolocate,:The General",
		
		"NOW STEP UP AND SHOW ME YOUR WAR FACE!",
		
		"*dutiful dolphin noises*:Stg.Oceana’s",
		
		
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
				PlayLine();
				index++;
				lineIndex++;
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
	
	int lineIndex = 0;
	
	void PlayLine()
	{
		if(lineIndex == 0)
		{
			FindObjectOfType<AudioManager>().Play("01");
			Instantiate(spawnCrewSprite, crewLocation.transform);
		}
		if(lineIndex == 1)
		{
			FindObjectOfType<AudioManager>().Stop("01");
			FindObjectOfType<AudioManager>().Play("02");
			Instantiate(spawnGeneralSprite, generalLocation.transform);
		}
		if(lineIndex == 2)
		{
			FindObjectOfType<AudioManager>().Stop("02");
			FindObjectOfType<AudioManager>().Play("03");
		}
		if(lineIndex == 3)
		{
			FindObjectOfType<AudioManager>().Stop("03");
			FindObjectOfType<AudioManager>().Play("04");
		}
		if(lineIndex == 4)
		{
			FindObjectOfType<AudioManager>().Stop("04");
			FindObjectOfType<AudioManager>().Play("05");
		}
		if(lineIndex == 5)
		{
			FindObjectOfType<AudioManager>().Stop("05");
			FindObjectOfType<AudioManager>().Play("06");
		}
		if(lineIndex == 6)
		{
			FindObjectOfType<AudioManager>().Stop("06");
			FindObjectOfType<AudioManager>().Play("07");
		}
		if(lineIndex == 7)
		{
			FindObjectOfType<AudioManager>().Stop("07");
			FindObjectOfType<AudioManager>().Play("08");
		}
		if(lineIndex == 8)
		{
			FindObjectOfType<AudioManager>().Stop("08");
			FindObjectOfType<AudioManager>().Play("09");
			Destroy(crewLocation);
			Instantiate(spawnOceanaSprite, oceanaLocation.transform);
		}
		if(lineIndex == 9)
		{
			FindObjectOfType<AudioManager>().Stop("09");
			FindObjectOfType<AudioManager>().Play("10");
		}
		if(lineIndex == 10)
		{
			FindObjectOfType<AudioManager>().Stop("10");
			FindObjectOfType<AudioManager>().Play("11");
		}
		if(lineIndex == 11)
		{
			FindObjectOfType<AudioManager>().Stop("11");
			FindObjectOfType<AudioManager>().Play("12");
		}
		
		if(lineIndex == 12)
		{
			FindObjectOfType<AudioManager>().Stop("12");
			SceneManager.LoadScene(2);
		}
	}

}

