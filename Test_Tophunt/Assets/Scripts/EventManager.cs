using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {

    public delegate void HitAction();
    public static event HitAction Hited;

    public void OnHited()
    {
        Hited();
    }
}
