using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueHandler 
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentances;
}
