using Assets.Scripts.Other;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    /// <summary>
    /// Enemy camera behaviour
    /// </summary>
    public class EnemyCamera : MonoBehaviour
    {
        public float MaxDetectionAngle = 45f;
        public float MaxDetectionRadius = 15f;
        public bool IsTargetInFieldOfView;
        private GameObject player;

        public RenderTexture lightCheckTexture;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, MaxDetectionRadius);

            Gizmos.color = Color.blue;
            Vector3 leftAngle = Quaternion.AngleAxis(-MaxDetectionAngle, transform.up) * transform.forward * MaxDetectionRadius;
            Vector3 rightAngle = Quaternion.AngleAxis(MaxDetectionAngle, transform.up) * transform.forward * MaxDetectionRadius;
            Gizmos.DrawRay(transform.position, leftAngle);
            Gizmos.DrawRay(transform.position, rightAngle);

            Gizmos.color = Color.black;
            Gizmos.DrawRay(transform.position, transform.forward * MaxDetectionRadius);

            if (IsTargetInFieldOfView)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }

            if (player != null)
            {
                Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * MaxDetectionRadius);
            }
        }

        void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        void Update()
        {
            IsTargetInFieldOfView = Vision.IsInFieldOfView(transform, player.transform, MaxDetectionAngle, MaxDetectionRadius);
        }

        /// <summary>
        /// Calculates the luminance of a texture
        /// </summary>
        /// <returns>Returns a float which indicates the luminance</returns>
        public float GetLuminance()
        {
            RenderTexture tempTexture = RenderTexture.GetTemporary(lightCheckTexture.width, lightCheckTexture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
            Graphics.Blit(lightCheckTexture, tempTexture);
            RenderTexture previous = RenderTexture.active;
            RenderTexture.active = tempTexture;

            Texture2D temp2DTexture = new Texture2D(lightCheckTexture.width, lightCheckTexture.height);
            temp2DTexture.ReadPixels(new Rect(0, 0, tempTexture.width, tempTexture.height), 0, 0);
            temp2DTexture.Apply();

            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(tempTexture);

            Color32[] colors = temp2DTexture.GetPixels32();

            // Calculate the luminance by the brightness of pixels by a mathematic function: https://stackoverflow.com/questions/596216/formula-to-determine-brightness-of-rgb-color
            float luminance = 0f;

            for (int i = 0; i < colors.Length; i++)
            {
                luminance += (0.2126f * colors[i].r) + (0.7152f * colors[i].g) + (0.0722f + colors[i].b);
            }

            return luminance;
        }
    }
}
