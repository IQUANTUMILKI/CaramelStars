using UnityEngine;
using DG.Tweening;

namespace MaxLineScripts
{
    public class CameraTrigger : MonoBehaviour
    {
        public CameraFollower SetCamera;
        public bool ActivePosition = true;
        public Vector3 NewAddPosition = Vector3.zero;
        public bool ActiveRotate = true;
        public Vector3 NewRotate = new Vector3(45f, 60f, 0f);
        public bool ActiveDistance = true;
        public float NewDistance = 25f;
        public bool ActiveSpeed = true;
        public float NewFollowSpeed = 1.2f;
        public float NeedTime = 1f;

        void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<MainLine>() != null)
            {
                if (SetCamera.DoPos != null)
                {
                    SetCamera.DoPos.Kill();
                }
                if (SetCamera.DoRot != null)
                {
                    SetCamera.DoRot.Kill();
                }
                if (SetCamera.DoDis != null)
                {
                    SetCamera.DoDis.Kill();
                }
                if (SetCamera.DoSpe != null)
                {
                    SetCamera.DoSpe.Kill();
                }
                if (ActivePosition)
                {
                    SetCamera.DoPos = DOTween.To(() => SetCamera.AddPosition, a => SetCamera.AddPosition = a, NewAddPosition, NeedTime).SetEase(Ease.InOutSine);
                }
                if (ActiveRotate)
                {
                    SetCamera.DoRot = DOTween.To(() => SetCamera.Rotate, a => SetCamera.Rotate = a, NewRotate, NeedTime).SetEase(Ease.InOutSine);
                }
                if (ActiveDistance)
                {
                    SetCamera.DoDis = DOTween.To(() => SetCamera.DistanceFromObject, a => SetCamera.DistanceFromObject = a, NewDistance, NeedTime).SetEase(Ease.InOutSine);
                }
                if (ActiveSpeed)
                {
                    SetCamera.DoSpe = DOTween.To(() => SetCamera.FollowSpeed, a => SetCamera.FollowSpeed = a, NewFollowSpeed, NeedTime).SetEase(Ease.InOutSine);
                }
            }
        }
    }
}