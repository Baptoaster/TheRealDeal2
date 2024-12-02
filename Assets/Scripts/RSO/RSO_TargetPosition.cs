using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSO_TargetPosition", menuName = "Data/RSO/TargetPosition")]
public class RSO_TargetPosition : ScriptableObject
{
    public Action<Vector3> onValueChanged;
    private Vector3 _value;

    public Vector3 Value
    {
        get => _value;
        set
        {
            if (_value == value) return;

            _value = value;
            onValueChanged?.Invoke(_value);
        }
    }
}