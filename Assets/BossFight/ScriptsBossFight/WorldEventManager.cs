using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class WorldEventManager : MonoBehaviour
    {
        BossStats boss;

        public bool bossFightIsActive;
        public bool bossHasBeenAwakened;
        public bool bossHasBeenDefeated;



        public void ActivateBossFight()
        {
            bossFightIsActive = true;
        }

    }


}