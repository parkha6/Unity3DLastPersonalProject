using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    byte level = 0;
    internal byte Level
    {
        get { return level; }
        set
        {
            if (value > 255) { value = 255; }
            level = value;
        }
    }
}
