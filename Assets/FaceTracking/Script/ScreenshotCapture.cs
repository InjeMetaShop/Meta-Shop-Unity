using UnityEngine;

public class ScreenshotCapture : MonoBehaviour
{
    public void CaptureScreenshot()
    {
        // ��ũ���� ĸó
        Texture2D screenshotTexture = ScreenCapture.CaptureScreenshotAsTexture();

        // Android �÷����� ȣ��
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject galleryManager = new AndroidJavaObject("com.example.GalleryManager", currentActivity);

        // Android �÷����� �Լ� ȣ���Ͽ� ������ �������� ����
        string imagePath = galleryManager.Call<string>("saveImageToGallery", screenshotTexture);

        // ���� ���� ���� ���� Ȯ��
        if (!string.IsNullOrEmpty(imagePath))
        {
            Debug.Log("Screenshot saved to Gallery: " + imagePath);
        }
        else
        {
            Debug.Log("Failed to save screenshot to Gallery");
        }
    }
}
