using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class VehicleControl : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float forceMod;
    [SerializeField] private float rotateDuration;
    [SerializeField] private ForceMode2D forceMode2D;

    #endregion Inspector variables

    #region private variables

    private Tween rotateTweeen;

    #endregion private variables

    #region public functions

    public void PushForward()
    {
        //rigidbody2D.AddForce(new Vector2(0.7f, -0.7f) * forceMod, forceMode2D);
        rigidbody2D.AddForce(Vector2.right * forceMod, forceMode2D);
        Rotate(new Vector3(0, 0, -50), rotateDuration);
    }
    
    public void PushBackward()
    {
        //rigidbody2D.AddForce(new Vector2(-0.7f, 0.7f) * forceMod, forceMode2D);
        rigidbody2D.AddForce(Vector2.right * forceMod, forceMode2D);
        Rotate(new Vector3(0, 0, 50), rotateDuration);
    }

    public void RotateToNormal()
    {
        Rotate(Vector3.zero, rotateDuration);
    }

    #endregion public functions

    #region private functions

    private void Rotate(Vector3 endValue, float rotateDuration)
    {
        if (rotateTweeen != null)
        {
            rotateTweeen.Kill(false);
        }

        rotateTweeen = rigidbody2D.transform.DORotate(endValue, rotateDuration);
    }

    #endregion private functions
}
