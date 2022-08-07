using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LevelController : MonoBehaviour
{
    public PickerMovement pickerMovement;
    public UIController canvas;
    #region Singleton
    public static LevelController instance;

    void Awake()
    {
        instance = this;
    }
    #endregion
    public void CheckPoint(Transform checkpoint)
    {
        for (int i = 0; i < PickerController.instance.Balls.Count; i++)
        {
            PickerController.instance.Balls[i].rb.AddForce(transform.forward * 3,ForceMode.Impulse);
        }
        DOTween.To(() => PickerMovement.instance.speed, x => PickerMovement.instance.speed = x, 0, 0.5f).OnComplete(() =>
        {         
             StartCoroutine(CheckCoroutine(checkpoint.GetComponent<CheckPoint>()));
        });

    } 
    public IEnumerator CheckCoroutine(CheckPoint cp)
    {
        yield return new WaitForSeconds(3f);
        if (cp.pit.CheckLimit())
        {
            yield return new WaitForSeconds(2f);
            cp.pit.ground.DOMoveY(0.25f, 0.5f).SetEase(Ease.InOutBack).OnComplete(() =>
            {;
                cp.pit.barrier.DORotate(new Vector3(0,0,90),1f);
                DOTween.To(() => PickerMovement.instance.speed, x => PickerMovement.instance.speed = x, PickerMovement.instance.firstSpeed, 1f);
               
            });
        }
        else StateManager.instance.UpdateGameState(GameState.Fail);
    }
    public void Ramp(PickerMovement picker)
    {
        pickerMovement.meshCollider.enabled = false;
        pickerMovement.boxCollider.isTrigger=false;
        pickerMovement.rb.isKinematic = false;
        pickerMovement.rb.constraints = RigidbodyConstraints.None;
        pickerMovement.rb.constraints = RigidbodyConstraints.FreezePositionX;
    }
    public void StartScreen(PickerMovement picker)
    {
        pickerMovement.meshCollider.enabled = true;
        pickerMovement.boxCollider.isTrigger = true;
        pickerMovement.rb.isKinematic = true;
        pickerMovement.rb.constraints = RigidbodyConstraints.FreezeRotationX;
        pickerMovement.rb.constraints = RigidbodyConstraints.FreezeRotationZ;
    }
    public void LevelEnd(int score)
    {
        UIController.instance.inGame.UpdateMoney(score);    

    }
}
