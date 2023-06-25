using UnityEngine;

public class ScreenshotCapture : MonoBehaviour
{
    public void CaptureScreenshot()
    {
        // 스크린샷 캡처
        Texture2D screenshotTexture = ScreenCapture.CaptureScreenshotAsTexture();

        // Android 플러그인 호출
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject galleryManager = new AndroidJavaObject("com.example.GalleryManager", currentActivity);

        // Android 플러그인 함수 호출하여 사진을 갤러리에 저장
        string imagePath = galleryManager.Call<string>("saveImageToGallery", screenshotTexture);

        // 사진 저장 성공 여부 확인
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
