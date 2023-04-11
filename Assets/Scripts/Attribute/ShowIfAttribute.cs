using System;
using UnityEngine;

public enum ActionOnConditionFail
{
    // If condition(s) are false, don't draw the field at all.
    DontDraw,
    // If condition(s) are false, just set the field as disabled.
    JustDisable,
}

public enum ConditionOperator
{
    // A field is visible/enabled only if all conditions are true.
    And,
    // A field is visible/enabled if at least ONE condition is true.
    Or,
}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class ShowIfAttribute : PropertyAttribute
{
    public ActionOnConditionFail Action {get;private set;}
    public ConditionOperator Operator {get;private set;}
    public string[] Conditions {get;private set;}

    public ShowIfAttribute(ActionOnConditionFail action = ActionOnConditionFail.DontDraw, ConditionOperator conditionOperator = ConditionOperator.Or, params string[] conditions)
    {
        Action  = action;
        Operator = conditionOperator;
        Conditions = conditions;
    }

    
    public ShowIfAttribute(params string[] conditions)
    {
        Action  = ActionOnConditionFail.DontDraw;
        Operator = ConditionOperator.And;
        Conditions = conditions;
    }
}
