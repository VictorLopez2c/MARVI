using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Sprite[] spriteGallery;//***//

	public Image displayImage;//***//
	public int i = -1;//***//

	public Animator animator;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}
	void Update()
	{
		displayImage.sprite = spriteGallery[i];//***//
	}
	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		Time.timeScale = 0f;//***//
		Cursor.visible = true;//***//
		Cursor.lockState = CursorLockMode.None;//***//

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
		
	}

    public void DisplayNextSentence ()
	{
		if (i + 1 < spriteGallery.Length)
		{ i++; }//***//

		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		string sentence = sentences.Dequeue();

		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		i = 0;//***//
		Time.timeScale = 1f;//***//
	}

}
