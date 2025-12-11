using UnityEngine;
using System.Collections;

public class Chuck : MonoBehaviour
{
   public SpriteRenderer ChuckSpriteRenderer;
   
   public Sprite NormalSprite;
   public Sprite ParrySprite;
   public Sprite BoostSprite;
   public Sprite PulseSprite;
   public Sprite ShootSprite;
   
   public Game Game;
   public HealthDisplay HP;
   public UI_ParryCooldown ParryCooldownMeter;
   public ChuckAnimator ChuckAnimator;
   public UI_ChuckIcon ChuckIcon;
   
   private float ChuckSpeed = GameParameters.ChuckMoveSpeed;
   private float Health = GameParameters.ChuckHealth;
  
   private bool isParrying = false;
   private bool isBoosting = false;
   private bool isPulsing = false;
   private bool isShooting = false;
   
   private bool canParry = true;
   private bool canBoost = true;
   
   //MOVEMENT
   public void Move(Vector2 direction)
   {
       float yAmount = direction.y * ChuckSpeed * Time.deltaTime;
      
       ChuckSpriteRenderer.transform.Translate(0, yAmount, 0f);
       ChuckSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(ChuckSpriteRenderer);
   }
   
   public void MoveManually(Vector2 direction)
   {
       if (!Game.IsPlaying)
       {
           return;
       }
       Move(direction);
   }

   //PACKAGE LAUNCH 
   
   //!!!
   //UNFINISHED
   public void Shoot()
   {
       isShooting = true;
   }

   IEnumerator MoveToLaunchPos()
   {
       yield return null;
   }


   //PULSING
   public void Pulse()
   {
       if (!isBoosting && !isPulsing && !isShooting && !isParrying && Game.IsPlaying)
       {
           Debug.Log("PULSE");
           //ChangeToPulseSprite();
           ChuckAnimator.StartPulsingAnim();
           StartCoroutine(PulseTimer());
       }
   }


   IEnumerator PulseTimer()
   {
       isPulsing = true;
       ChuckSpeed = GameParameters.ChuckPulseSpeed;
       yield return new WaitForSeconds(GameParameters.ChuckPulseDuration);
       ReturnToNormal();
   }
   
   //PARRYING
   public void Parry()
   {
       if (canParry && Game.IsPlaying)
       {
           //ChangeToParrySprite();
           ChuckAnimator.StartParryingAnim();
           isParrying = true;
           canBoost = false;
           Debug.Log("Parry!");
           canParry = false;
           ParryCooldownMeter.StartCooldown();
           StartCoroutine(ParryTimer());
       }
   }


   IEnumerator ParryTimer()
   {
       ChuckSpeed = GameParameters.ChuckParrySpeed;
       yield return new WaitForSeconds(GameParameters.ChuckParryDuration);
       ReturnFromParry();
   }
   
   public bool getIsParrying()
   {
       return isParrying;
   }

   public void setCanParrying(bool canParry)
   {
       this.canParry = canParry;
   }
   
   private void ReturnFromParry()
   {
       ChangeToNormalAnim();
       ChuckSpeed = GameParameters.ChuckMoveSpeed;
       canBoost = true;
       isParrying = false;

       //ParryCooldownMeter.StartCooldown();
   }
  
   //CHANGING STATES
   private void ReturnToNormal()
   {
       Debug.Log("Returning to Normal");
       ChuckSpeed = GameParameters.ChuckMoveSpeed;
       isPulsing = false;
       isParrying = false;
       isBoosting = false;
       isShooting = false;
       ChangeToNormalAnim();
   }
   
   private void ChangeToParrySprite()
   {
       ChuckSpriteRenderer.sprite = ParrySprite;
   }


   private void ChangeToNormalAnim()
   {
       ChuckAnimator.NormalAnim();
   }
  
   private void ChangeToBoostSprite()
   {
       ChuckSpriteRenderer.sprite = BoostSprite;
   }
  
   private void ChangeToPulseSprite()
   {
       ChuckSpriteRenderer.sprite = PulseSprite;
   }
   
   private void ChangeToShootSprite()
   {
       ChuckSpriteRenderer.sprite = ShootSprite;
       //anim.SetTrigger("shoot");
   }


   //BOOSTING
   
   //!!!
   //Player can boost while boosting, but shouldn't be an issue when we set boost conditions
   public void Boost()
   {
       if (canBoost && Game.IsPlaying)
       {
           //ChangeToBoostSprite();
           ChuckAnimator.StartBoostingAnim();
           Debug.Log("BOOSTING!");
           isBoosting = true;
           StartCoroutine(BoostTimer());
       }
   }
  
   IEnumerator BoostTimer()
   {
       canParry = false;
       ChuckSpeed = GameParameters.ChuckBoostSpeed;
       yield return new WaitForSeconds(GameParameters.ChuckBoostDuration);
       canParry = true;
       ReturnToNormal();
   }
   
   //COLLISION
   public void OnTriggerEnter2D(Collider2D collision)
   {
       Debug.Log("OnTriggerEnter2D");
       if (collision.gameObject.tag == "Obstacle")
       {
           if (isParrying)
           {
               Debug.Log("PARRY KILL");
               Destroy(collision.gameObject);
           }
           else
           {
               if (!isShooting)
               {
                   TakeDamage();
                   HP.DecreaseHealth();
               }
           }
       }
       
       if (collision.gameObject.tag == "Letter")
       {
           ScoreKeeper.AddPoint();
           Destroy(collision.gameObject);
       }
        
       
   }

   public void TakeDamage()
   {
       Health--;
       ChuckIcon.DamageIcon();
   }
}
