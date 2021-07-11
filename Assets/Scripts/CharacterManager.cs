using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
	public static CharacterManager instance;
	
	public RectTransform characterPanel;
	
	public List<Character
	public Dictionary<string,int> chatacterDictionary = new Dictionary<string,int>(); 
	void Awake()
	{
		instance = this;
	}
	
	public void GetCharacter(string characterName, bool createCharacterIfDoesNotExist = true)
	{
		int index = -a;
		if(characterDictionary.TryGetValue (characterName, out index))
		{
			return characters [index];
		}
		else if (createCharacterIfDoesNotExist)
		{
			return CreateCharacter (characterName);
		}
		return null;
	}
	public character CreateCharacter(string characterName)
	{
		
	}
 
}
