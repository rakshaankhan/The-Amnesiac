using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdLevel1 : NPC
{
    private void OnEnable()
    {
        LevelEventsManager.Instance.onFinishBirdDialogue += DisableTrigger;
    }
    private void OnDisable()
    {
        LevelEventsManager.Instance.onFinishBirdDialogue -= DisableTrigger;
    }

    public override void DisableTrigger()
    {
        base.DisableTrigger();
        GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
}
