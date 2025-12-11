using UnityEngine;
using System.Collections;


public class Chuck : MonoBehaviour
{
  public SpriteRenderer ChuckSpriteRenderer;
 
  public Game Game;
  public HealthDisplay HP;
  public UI_Boosting BoostDisplay;
  public UI_ParryCooldown ParryCooldownMeter;
  public ChuckAnimator ChuckAnimator;
  public UI_ChuckIcon ChuckIcon;
  public UI UI;
  public UI_Boosting UI_Boosting;
 
  private float ChuckSpeed = GameParameters.ChuckMoveSpeed;
  private float Health = GameParameters.ChuckHealth;


  private bool isParrying = false;
  private bool isBoosting = false;
  private bool isPulsing = false;
  private bool isShooting = false;
 
  private bool canParry = true;
  private bool canBoost = true;
  private bool canBeDamaged = true;
 
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
  public void Shoot()
  {
      isShooting = true;
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
      StartCoroutine(IFrames());
      ChangeToNormalAnim();
      ChuckIcon.ReturnToNormalIcon();
  }


  IEnumerator IFrames()
  {
      yield return new WaitForSeconds(1.5f);
      canBeDamaged = true;
  }

  public void StartIFramesExternally()
  {
      canBeDamaged = false;
      StartCoroutine(LongIFrames());
  }
  
  IEnumerator LongIFrames()
  {
      yield return new WaitForSeconds(3f);
      canBeDamaged = true;
  }


  private void ChangeToNormalAnim()
  {
      ChuckAnimator.NormalAnim();
  }
  

  

  //BOOSTING
 
  //!!!
  //Player can boost while boosting, but shouldn't be an issue when we set boost conditions
  public void Boost()
  {
      if (BoostDisplay.GetBoost() == 5 && Game.IsPlaying)
      {
          ChuckAnimator.StartBoostingAnim();
          ChuckIcon.MakeBoostingIcon();
          Debug.Log("BOOSTING!");
          BoostDisplay.UseBoost();
          isBoosting = true;
          canBeDamaged = false;
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
          if (isParrying || isBoosting)
          {
              Debug.Log("OBJECT DESTROYED");
              Destroy(collision.gameObject);
          }
          else
          {
              if (canBeDamaged)
              {
                  TakeDamage();
                  HP.DecreaseHealth();
              }
          }
      }
     
      else if (collision.gameObject.tag == "Letter")
      {
          ScoreKeeper.AddPoint();
          UI.SetScoreText();
          Destroy(collision.gameObject);
      }
      else if (collision.gameObject.tag == "Feather")
      {
          //UI_Boosting.Boost++;
          UI_Boosting.IncreaseBoost();
          if (UI_Boosting.Boost > 5)
              UI_Boosting.Boost = 5;
          UI_Boosting.UpdateBoostDisplay();
          Destroy(collision.gameObject);
      }
     
  }


  public void TakeDamage()
  {
      canBeDamaged = false;
      Health--;
      if (Health > 1)
      {
          ChuckIcon.DamageIcon();
      }
      ChuckAnimator.StartDamageAnim();
      StartCoroutine(TakingDamageTimer());
      StartCoroutine(IFrames());
  }

  IEnumerator TakingDamageTimer()
  {
      yield return new WaitForSeconds(GameParameters.ChuckDamageIconDuration);
      ChuckAnimator.NormalAnim();
  }
 
  public void TestIncrease()
  {
       BoostDisplay.IncreaseBoost();
  }
}
