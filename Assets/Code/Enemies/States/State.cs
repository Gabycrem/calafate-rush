using System.Collections;
using System.Collections.Generic;
using Enemies.Controller;
using UnityEngine;

namespace Enemies.States
{

public class State
{
    public virtual void EnterState(EnemyController controller)
    {

    }

    public  virtual void UpdateState(EnemyController controller)
    {
        
    }

    public  virtual void ExitState(EnemyController controller)
    {
        
    }
}
}