using UnityEngine;

public class PlayButtonClick : ButtonChangeStateGame
{
    protected override void OnButtonClick()
    {
        ChangedStateGame?.Invoke();
        Game.Play();
    }
}
