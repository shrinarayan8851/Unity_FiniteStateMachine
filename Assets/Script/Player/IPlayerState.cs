
using UnityEngine.Events;
public interface IPlayerState 
{
    void OnStateEnter(PlayerController startEvent);
    void OnStateExit(PlayerController startEvent);
    public void UpdateState(PlayerController enemy);
}


[System.Serializable]
public class StateEvent : UnityEvent<IPlayerState> { }
