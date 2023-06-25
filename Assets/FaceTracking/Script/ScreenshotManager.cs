using System.Collections;
using UnityEngine;

public class ScreenshotManager : MonoBehaviour
{
    // ĸó�� ī�޶�
    public Camera captureCamera;

    // ĸó ��ư Ŭ�� �� ȣ��� �޼ҵ�
    public void CaptureScreenshot()
    {
        StartCoroutine(TakeScreenshot());
    }

    private IEnumerator TakeScreenshot()
    {
        // �� ������ ���
        yield return new WaitForEndOfFrame();

        // ���� ȭ���� �ؽ�ó�� ĸó
        Texture2D screenshotTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshotTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshotTexture.Apply();

        // �ؽ�ó�� ����Ʈ �迭�� ��ȯ
        byte[] screenshotBytes = screenshotTexture.EncodeToPNG();

        // �ؽ�ó ���� ��� (Android�� ������ ������ ����)
        string screenshotPath = "/DCIM/Camera/screenshot.png";

        // ����Ʈ �迭�� ���Ϸ� ����
        System.IO.File.WriteAllBytes(screenshotPath, screenshotBytes);

        // �������� ������ �߰��ϵ��� �ȵ���̵� �̵�� ��ĵ ��û
        AndroidJavaClass mediaScanner = new AndroidJavaClass("android.media.MediaScannerConnection");
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        mediaScanner.CallStatic("scanFile", currentActivity, new string[] { screenshotPath }, null, null);

        // �޸� ����
        Destroy(screenshotTexture);

        Debug.Log("��ũ������ ����Ǿ����ϴ�: " + screenshotPath);
    }
}
