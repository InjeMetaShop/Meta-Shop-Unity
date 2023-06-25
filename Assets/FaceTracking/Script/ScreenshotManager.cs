using System.Collections;
using UnityEngine;

public class ScreenshotManager : MonoBehaviour
{
    // 캡처할 카메라
    public Camera captureCamera;

    // 캡처 버튼 클릭 시 호출될 메소드
    public void CaptureScreenshot()
    {
        StartCoroutine(TakeScreenshot());
    }

    private IEnumerator TakeScreenshot()
    {
        // 한 프레임 대기
        yield return new WaitForEndOfFrame();

        // 현재 화면을 텍스처로 캡처
        Texture2D screenshotTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshotTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshotTexture.Apply();

        // 텍스처를 바이트 배열로 변환
        byte[] screenshotBytes = screenshotTexture.EncodeToPNG();

        // 텍스처 저장 경로 (Android의 갤러리 폴더로 지정)
        string screenshotPath = "/DCIM/Camera/screenshot.png";

        // 바이트 배열을 파일로 저장
        System.IO.File.WriteAllBytes(screenshotPath, screenshotBytes);

        // 갤러리에 사진을 추가하도록 안드로이드 미디어 스캔 요청
        AndroidJavaClass mediaScanner = new AndroidJavaClass("android.media.MediaScannerConnection");
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        mediaScanner.CallStatic("scanFile", currentActivity, new string[] { screenshotPath }, null, null);

        // 메모리 해제
        Destroy(screenshotTexture);

        Debug.Log("스크린샷이 저장되었습니다: " + screenshotPath);
    }
}
