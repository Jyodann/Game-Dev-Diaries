using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterLines
{
    public Character Character;

    [TextArea(2, 5)] public string text;
}
