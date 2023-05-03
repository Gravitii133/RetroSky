using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeBarController : MonoBehaviour
{
   public float life = 2;
   public float lifeMax = 14;

   public Image lifeBar;

   private void Update() {
     UpdateLifeBar();
   }
    
    private void UpdateLifeBar() {
      lifeBar.fillAmount = life / lifeMax;
    }
}
