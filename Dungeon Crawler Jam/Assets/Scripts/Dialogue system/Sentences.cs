using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Sentences
{
    public string name;
    public Sprite speakerSprite;
    [TextArea(3, 10)]
    public string[] sentenceHolder;
}
