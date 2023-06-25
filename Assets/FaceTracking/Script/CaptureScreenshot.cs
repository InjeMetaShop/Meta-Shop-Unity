using UnityEngine;

public class CaptureScreenshot : MonoBehaviour
{
    public string screenshotFolder = "Screenshots";
    public string screenshotPrefix = "Screenshot";

    public void OnCaptureButtonClick()
    {
        string fileName = screenshotPrefix + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
        string folderPath = Application.persistentDataPath + "/" + screenshotFolder;

        // Create the screenshot folder if it doesn't exist
        if (!System.IO.Directory.Exists(folderPath))
        {
            System.IO.Directory.CreateDirectory(folderPath);
        }

        // Capture screenshot and save it
        string imagePath = System.IO.Path.Combine(folderPath, fileName);
        ScreenCapture.CaptureScreenshot(imagePath);

        // Call the Android plugin to save the image to gallery
        #if UNITY_ANDROID
        AndroidGalleryBridge galleryBridge = FindObjectOfType<AndroidGalleryBridge>();
        if (galleryBridge != null)
        {
            galleryBridge.SaveImageToGallery(imagePath);
        }
        #endif
    }
}
