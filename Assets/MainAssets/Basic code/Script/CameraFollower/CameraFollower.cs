using UnityEngine;
using DG.Tweening;

namespace MaxLineScripts
{
    public class CameraFollower : MonoBehaviour
    {
        public Transform FollowObject;
        private Transform FollowerObject;
        public Vector3 AddPosition = Vector3.zero;
        public Vector3 Rotate = new Vector3(45f, 45f, 0f);
        public float DistanceFromObject = 25f;
        public float FollowSpeed = 1.2f;
        public bool Following = true;
        public Tween DoPos, DoRot, DoDis, DoSpe;

        void Start()
        {
            FollowerObject = transform.GetChild(0);
        }

        void Update()
        {
            if (Time.timeScale == 0)
            {
                Following = false;
            }
            if (Time.timeScale != 0 && !FollowObject.GetComponent<MainLine>().Is_Stop)
            {
                Following = true;
            }
            if (Following)
            {
                transform.eulerAngles = Rotate;
                FollowerObject.localPosition = new Vector3(0f, 0f, -DistanceFromObject);
                Vector3 BaseTransform = FollowObject.position + AddPosition;
                transform.position = Vector3.Lerp(transform.position, BaseTransform, Mathf.Abs(FollowSpeed * Time.deltaTime));
            }
            if (FollowObject.GetComponent<MainLine>() != null)
            {
                if (FollowObject.GetComponent<MainLine>().Is_Stop)
                {
                    Following = false;
                    DoPos.Kill();
                    DoRot.Kill();
                    DoDis.Kill();
                    DoSpe.Kill();
                }
            }
        }
    }
}