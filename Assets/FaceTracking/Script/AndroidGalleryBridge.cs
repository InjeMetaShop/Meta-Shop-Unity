#if UNITY_ANDROID
using UnityEngine;

public class AndroidGalleryBridge : MonoBehaviour
{
    public void SaveImageToGallery(string imagePath)
    {
        AndroidJavaClass galleryUtilClass = new AndroidJavaClass("com.example.galleryutil.GalleryUtil");
        AndroidJavaObject currentActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");

        string savedImagePath = galleryUtilClass.CallStatic<string>("saveImageToGallery", currentActivity, imagePath);

        if (savedImagePath != null)
        {
            Debug.Log("Image saved to gallery: " + savedImagePath);
        }
        else
        {
            Debug.Log("Failed to save image to gallery");
        }
    }
}
#endif
