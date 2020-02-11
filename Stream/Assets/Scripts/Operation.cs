using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Operation : MonoBehaviour
{
    public abstract void Toggle();
    public abstract void ChangeCondition(Transform button);
    public bool operation_started { get; set; }
}
