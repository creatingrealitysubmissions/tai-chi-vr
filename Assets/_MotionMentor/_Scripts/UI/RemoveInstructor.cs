using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveInstructor : TaiChiIcon
{
    public override void Select()
    {
        base.Select();
        Game.Instance.RepositionInstructors(Game.Instance.Instructors.Count - 1);
    }
}
