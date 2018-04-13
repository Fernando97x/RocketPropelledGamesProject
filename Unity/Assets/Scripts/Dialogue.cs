using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Habiitando edição através do inspetor da Unity
public class Dialogue
{

    public string npcName;

    [TextArea(3, 10)] //Quantidade de frases
    public string[] sentences;

}
