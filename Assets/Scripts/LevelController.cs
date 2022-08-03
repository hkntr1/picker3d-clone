using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LevelController : MonoBehaviour
{
    #region Singleton
    public static LevelController instance;

    void Awake()
    {
        instance = this;
    }
    #endregion
    public void CheckPoint(Transform checkpoint)
    {
        DOTween.To(() => PickerMovement.instance.speed, x => PickerMovement.instance.speed = x, 0, 1f).OnComplete(() =>
        {
            for (int i = 0; i < PickerController.instance.Balls.Count-1; i++)
            {
                PickerController.instance.Balls[i].rb.AddForce(transform.forward * 10);
                
               
            }
             StartCoroutine(CheckCoroutine(checkpoint.GetComponent<CheckPoint>()));
        });

    } 
    public IEnumerator CheckCoroutine(CheckPoint cp)
    {
        yield return new WaitForSeconds(5f);
        if (cp.pit.CheckLimit())
        {
            yield return new WaitForSeconds(2f);
            cp.pit.ground.DOMoveY(0.25f, 0.5f).SetEase(Ease.InOutBack).OnComplete(() =>
            {;
                cp.pit.barrier.DORotate(new Vector3(0,0,90),1f);
                DOTween.To(() => PickerMovement.instance.speed, x => PickerMovement.instance.speed = x, 3, 1f);
               
            });
        }
        else Debug.Log("false");
    }
}
