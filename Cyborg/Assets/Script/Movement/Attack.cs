using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Enemy
{
    public abstract class Attack : EnemyAI
    {
        public abstract void attack();
    }
}

