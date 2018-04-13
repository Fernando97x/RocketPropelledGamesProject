using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText; //GameObject do Canvas com o Nome do NPC
    public Text dialogueText; //GameObject do Canvas com a fala do NPC

    public Animator animator; //Animator para controle das animações de IN and OUT da caixa de dialogo

    private Queue<string> sentences; //Lista de frases //Queue facilita para o controle da ordem das frases dentro da lista;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) //Recebe os dados do dialogo e o inicia
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.npcName;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
            sentences.Enqueue(sentence);

        GoToNextSentence();
    }

    public void GoToNextSentence() //Troca de frase
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        //Se preferir que a frase já seja completamente exposta na tela utilize este metodo
        TypeSentence(sentence);

        //Se preferir que a frase tenha o Efeito para que cada caractere apareça um de cada vez utilize a Coroutine

        //StopAllCoroutines();
        //StartCoroutine(TypeSentence(sentence));
    }

    /*IEnumerator TypeSentence(string sentence) 
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }*/

    void TypeSentence(string sentence)
    {
        dialogueText.text = sentence;
    }

    void EndDialogue() //Termina dialogo
    {
        animator.SetBool("IsOpen", false);
    }

}
