using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Operation : MonoBehaviour
{
    public abstract void TurnOn();

    public abstract void TurnOff();

    public abstract void SetCondition();
}
