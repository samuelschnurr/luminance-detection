using UnityEngine;

public class DetectLight : MonoBehaviour
{
    public RenderTexture lightCheckTexture;
    public float Lightlevel;
    public int Light;

    void Update()
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

        Lightlevel = 0;

        for (int i = 0; i < colors.Length; i++)
        {
            Lightlevel += (0.2126f * colors[i].r) + (0.7152f * colors[i].g) + (0.0722f + colors[i].b);
        }

        Debug.Log(Lightlevel);
    }
}
