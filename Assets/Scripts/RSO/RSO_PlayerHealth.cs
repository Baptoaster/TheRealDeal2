using System;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "RSO_PlayerHealth", menuName = "Data/RSO/PlayerHealth")]
public class RSO_PlayerHealth : ScriptableObject
{
    public Action<int> onValueChanged;

    [ShowInInspector]
    private int _value;

    public int Value
    {
        get => _value;
        set
        {
            if (_value == value) return;

            _value = value;
            onValueChanged?.Invoke(_value);
        }
    }

    [Button]
    private void Add()
    {
        Value++;
    }

    [Button]
    private void Remove()
    {
        if (Value > 0) Value--;
    }
}