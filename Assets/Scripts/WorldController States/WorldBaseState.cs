using UnityEngine;

public abstract class WorldBaseState
{
    public abstract void EnterState(WorldController controller);
    public abstract void LeaveState(WorldController controller);
}
