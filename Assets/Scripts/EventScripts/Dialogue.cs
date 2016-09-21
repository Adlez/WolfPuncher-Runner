using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour
{
	public GameObject d_ContinueIcon;
	public GameObject d_StopIcon;

	private Text _textComponent;

	public List<string> d_DialogueStrings;

	public float d_SecondsBetweenCharacters = 0.15f; // =0.15f;
	public float d_CharacterRateMultiplier = 0.5f; // 0.5f

	public KeyCode d_DialogueInput = KeyCode.Return;

	private bool _isStringBeingRevealed = false; //default is false
	private bool _isEndOfDialogue = false;
	private bool _isDialoguePlaying = false;
	// Use this for initialization
	void Start()
	{
		_textComponent = GetComponent<Text>();
		_textComponent.text = "";

		HideIcons();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (!_isDialoguePlaying)
			{
				_isDialoguePlaying = true;
				StartCoroutine(StartDialogue());
			}
		}
	}

	private void HideIcons()
	{
		d_ContinueIcon.SetActive(false);
		d_StopIcon.SetActive(false);
	}

	private void ShowIcons()
	{
		if (_isEndOfDialogue)
		{
			d_StopIcon.SetActive(true);
			d_ContinueIcon.SetActive(false);
			return;
		}

		d_ContinueIcon.SetActive(true);
	}

	private IEnumerator StartDialogue()
	{
		int dialogueLength = d_DialogueStrings.Count;
		int currenDialogueIndex = 0;

		while (currenDialogueIndex < dialogueLength || !_isStringBeingRevealed)
		{
			if (!_isStringBeingRevealed)
			{
				_isStringBeingRevealed = true;
				StartCoroutine(DisplayText(d_DialogueStrings[currenDialogueIndex++]));

				if (currenDialogueIndex >= dialogueLength)
				{
					//_isStringBeingRevealed = false;
					_isEndOfDialogue = true;
				}
			}

			yield return 0;
		}

		while (true)
		{
			if (Input.GetKeyDown(d_DialogueInput))
			{
				break;
			}

			yield return 0; //pauses dialogue once completely revealed until the return key is pressed again
		}

		HideIcons();
		//_isEndOfDialogue = false;
		_isDialoguePlaying = false;
	}

	private IEnumerator DisplayText(string textToShow)
	{
		HideIcons();
		int textLength = textToShow.Length;
		int curCharacterIndex = 0; //start of string

		_textComponent.text = ""; //clear before showing new text

		while (curCharacterIndex < textLength)
		{
			_textComponent.text += textToShow[curCharacterIndex];
			curCharacterIndex++;

			if (curCharacterIndex < textLength)
			{
				if (Input.GetKey(d_DialogueInput))
				{
					yield return new WaitForSeconds(d_SecondsBetweenCharacters * d_CharacterRateMultiplier);
				}
				else
				{
					yield return new WaitForSeconds(d_SecondsBetweenCharacters);
					//Depends on Time.timeScale, which is set to 0 when the Dialogue Event starts
					//Should work just fine after we create an actual pause function that stops all the updating of the game objects
				}
			}
			else
			{
				break;
			}
		}

		ShowIcons();

		while (true)
		{
			if (Input.GetKeyDown(d_DialogueInput))
			{
				break;
			}

			yield return 0; //pauses dialogue once completely revealed until the return key is pressed again
		}

		HideIcons();
		_isStringBeingRevealed = false;
		_textComponent.text = "";
	}
}