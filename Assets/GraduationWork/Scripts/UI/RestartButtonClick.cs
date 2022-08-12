using UnityEngine;

public class RestartButtonClick : ButtonChangeStateGame
{
    protected override void OnButtonClick()
    {
        ChangedStateGame?.Invoke();
        Game.Restart();
    }
}
