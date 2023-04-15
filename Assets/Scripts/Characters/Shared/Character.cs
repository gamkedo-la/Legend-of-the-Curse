
using System;
using UnityEngine;


public class Character : MonoBehaviour
{
    protected CombatSystem CombatSystem;
    protected AttributeSet AttributeSet;
    protected CharacterMovement CharacterMovement;
    protected virtual void Start()
    {
        CharacterMovement = GetComponent<CharacterMovement>();
        CombatSystem = GetComponent<CombatSystem>();
        AttributeSet = GetComponent<AttributeSet>();
    }
}
