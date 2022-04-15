using UnityEngine;

public class CamerasManager : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] Camera camera;
    Camera[] cameras;
    GameObject[] players;
    int numberOfCameras;
    double aspectRatio;

    void Start()
    {
        SetupCameras();
    }

    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        int numberOfPlayers = players.Length;

        if (numberOfCameras < numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers - numberOfCameras; i++)
            {
                Instantiate(camera, new Vector3(0, 0, 0), Quaternion.identity);
            }

            cameras = Camera.allCameras;
        }

        for (int i = 0; i < numberOfCameras; i++)
        {
            Camera camera = cameras[i];
            GameObject player = players[i];
            camera.transform.position = player.transform.position + offset;
        }





        if (numberOfCameras == Camera.allCameras.Length &&
            aspectRatio == (double)Screen.width / (double)Screen.height) { return; }
        SetupCameras();
    }

    void SetupCameras()
    {
        cameras = Camera.allCameras;
        numberOfCameras = cameras.Length;
        aspectRatio = (double)Screen.width / (double)Screen.height;

        Debug.Log("Setting up cameras");
        Debug.Log($"Number of cameras: {numberOfCameras}");
        Debug.Log($"Screen aspect ratio: {aspectRatio}");

        // Get division of screens
        int[] numberOfColumnsPerRow = GetNumberOfColumnsPerRow();

        // Get number non empty rows
        int numberOfRows = 0;
        foreach (int numberOfColumns in numberOfColumnsPerRow)
        {
            if (numberOfColumns > 0) { numberOfRows++; }
        }

        Debug.Log($"Number of rows: {numberOfRows}");

        // Setup each camera
        int cameraIndex = 0;
        float individualHeight = 1 / (float)numberOfRows;
        Debug.Log($"Individual height for all screens is: {individualHeight}");
        for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
        {
            int numberOfColumns = numberOfColumnsPerRow[rowIndex];
            float individualWidth = 1 / (float)numberOfColumns;

            Debug.Log($"Individual width for screens at row: {rowIndex} is: {individualWidth}");

            for (int columnIndex = 0; columnIndex < numberOfColumns; columnIndex++)
            {
                Camera camera = cameras[cameraIndex];
                Rect newRect = camera.rect;
                Vector2 newPosition = newRect.position;

                if (1f - (individualHeight * ((float)rowIndex + 1)) >= 1)
                {
                    Debug.Log("Shit wtf?");
                    Debug.Log($"individual height {individualHeight}");
                    Debug.Log($"(float)rowIndex) {(float)rowIndex}");
                    Debug.Log($"individual height * (float)rowIndex {individualHeight * (float)rowIndex}");
                    Debug.Log($"1f - individual height * (float)rowIndex {1f - (individualHeight * (float)rowIndex)}");
                }

                float horizontalPosition = individualWidth * (float)columnIndex;
                float verticalPosition = 1f - (individualHeight * ((float)rowIndex + 1));

                Debug.Log($"Camera Number: {cameraIndex}");
                Debug.Log($"HorizontalPosition for screen at row: {rowIndex} and column: {columnIndex} is: {horizontalPosition}");
                Debug.Log($"VerticalPosition for screen at row: {rowIndex} and column: {columnIndex} is: {verticalPosition}");

                newRect.width = individualWidth;
                newRect.height = individualHeight;
                newPosition.x = horizontalPosition;
                newPosition.y = verticalPosition;
                newRect.position = newPosition;

                camera.rect = newRect;


                cameraIndex++;
            }
        }
    }

    int[] GetNumberOfColumnsPerRow()
    {
        int[] numberOfColumnsPerRow = new int[numberOfCameras];

        switch (numberOfCameras)
        {
            case 1:
                numberOfColumnsPerRow[0] = 1;
                break;
            case 2:
                numberOfColumnsPerRow[0] = 1;
                numberOfColumnsPerRow[1] = 1;
                break;
            case 3:
                numberOfColumnsPerRow[0] = 1;
                numberOfColumnsPerRow[1] = 2;
                break;
            case 4:
                numberOfColumnsPerRow[0] = 2;
                numberOfColumnsPerRow[1] = 2;
                break;
            case 5:
                numberOfColumnsPerRow[0] = 2;
                numberOfColumnsPerRow[1] = 3;
                break;
            case 6:
                numberOfColumnsPerRow[0] = 3;
                numberOfColumnsPerRow[1] = 3;
                break;
            case 7:
                numberOfColumnsPerRow[0] = 3;
                numberOfColumnsPerRow[1] = 4;
                break;
            case 8:
                numberOfColumnsPerRow[0] = 4;
                numberOfColumnsPerRow[1] = 4;
                break;
            case 9:
                numberOfColumnsPerRow[0] = 3;
                numberOfColumnsPerRow[1] = 3;
                numberOfColumnsPerRow[2] = 3;
                break;
            case 10:
                numberOfColumnsPerRow[0] = 3;
                numberOfColumnsPerRow[1] = 3;
                numberOfColumnsPerRow[2] = 4;
                break;
            case 11:
                numberOfColumnsPerRow[0] = 3;
                numberOfColumnsPerRow[1] = 4;
                numberOfColumnsPerRow[2] = 4;
                break;
            case 12:
                numberOfColumnsPerRow[0] = 4;
                numberOfColumnsPerRow[1] = 4;
                numberOfColumnsPerRow[2] = 4;
                break;
            case 13:
                numberOfColumnsPerRow[0] = 4;
                numberOfColumnsPerRow[1] = 4;
                numberOfColumnsPerRow[2] = 5;
                break;
            case 14:
                numberOfColumnsPerRow[0] = 4;
                numberOfColumnsPerRow[1] = 5;
                numberOfColumnsPerRow[2] = 5;
                break;
            case 15:
                numberOfColumnsPerRow[0] = 5;
                numberOfColumnsPerRow[1] = 5;
                numberOfColumnsPerRow[2] = 5;
                break;
            case 16:
                numberOfColumnsPerRow[0] = 4;
                numberOfColumnsPerRow[1] = 4;
                numberOfColumnsPerRow[2] = 4;
                numberOfColumnsPerRow[3] = 4;
                break;
            case 17:
                numberOfColumnsPerRow[0] = 4;
                numberOfColumnsPerRow[1] = 4;
                numberOfColumnsPerRow[2] = 4;
                numberOfColumnsPerRow[3] = 5;
                break;
            case 18:
                numberOfColumnsPerRow[0] = 4;
                numberOfColumnsPerRow[1] = 4;
                numberOfColumnsPerRow[2] = 5;
                numberOfColumnsPerRow[3] = 5;
                break;
            case 19:
                numberOfColumnsPerRow[0] = 4;
                numberOfColumnsPerRow[1] = 5;
                numberOfColumnsPerRow[2] = 5;
                numberOfColumnsPerRow[3] = 5;
                break;
            case 20:
                numberOfColumnsPerRow[0] = 5;
                numberOfColumnsPerRow[1] = 5;
                numberOfColumnsPerRow[2] = 5;
                numberOfColumnsPerRow[3] = 5;
                break;
            case 21:
                numberOfColumnsPerRow[0] = 5;
                numberOfColumnsPerRow[1] = 5;
                numberOfColumnsPerRow[2] = 5;
                numberOfColumnsPerRow[3] = 6;
                break;
            case 22:
                numberOfColumnsPerRow[0] = 5;
                numberOfColumnsPerRow[1] = 5;
                numberOfColumnsPerRow[2] = 6;
                numberOfColumnsPerRow[3] = 6;
                break;
            case 23:
                numberOfColumnsPerRow[0] = 5;
                numberOfColumnsPerRow[1] = 6;
                numberOfColumnsPerRow[2] = 6;
                numberOfColumnsPerRow[3] = 6;
                break;
            case 24:
                numberOfColumnsPerRow[0] = 6;
                numberOfColumnsPerRow[1] = 6;
                numberOfColumnsPerRow[2] = 6;
                numberOfColumnsPerRow[3] = 6;
                break;
            case 25:
                numberOfColumnsPerRow[0] = 5;
                numberOfColumnsPerRow[1] = 5;
                numberOfColumnsPerRow[2] = 5;
                numberOfColumnsPerRow[3] = 5;
                numberOfColumnsPerRow[4] = 5;
                break;
            case 26:
                numberOfColumnsPerRow[0] = 5;
                numberOfColumnsPerRow[1] = 5;
                numberOfColumnsPerRow[2] = 5;
                numberOfColumnsPerRow[3] = 5;
                numberOfColumnsPerRow[4] = 6;
                break;
            case 27:
                numberOfColumnsPerRow[0] = 5;
                numberOfColumnsPerRow[1] = 5;
                numberOfColumnsPerRow[2] = 5;
                numberOfColumnsPerRow[3] = 6;
                numberOfColumnsPerRow[4] = 6;
                break;
            case 28:
                numberOfColumnsPerRow[0] = 5;
                numberOfColumnsPerRow[1] = 5;
                numberOfColumnsPerRow[2] = 6;
                numberOfColumnsPerRow[3] = 6;
                numberOfColumnsPerRow[4] = 6;
                break;
            case 29:
                numberOfColumnsPerRow[0] = 5;
                numberOfColumnsPerRow[1] = 6;
                numberOfColumnsPerRow[2] = 6;
                numberOfColumnsPerRow[3] = 6;
                numberOfColumnsPerRow[4] = 6;
                break;
            case 30:
                numberOfColumnsPerRow[0] = 6;
                numberOfColumnsPerRow[1] = 6;
                numberOfColumnsPerRow[2] = 6;
                numberOfColumnsPerRow[3] = 6;
                numberOfColumnsPerRow[4] = 6;
                break;
            case 31:
                numberOfColumnsPerRow[0] = 5;
                numberOfColumnsPerRow[1] = 5;
                numberOfColumnsPerRow[2] = 5;
                numberOfColumnsPerRow[3] = 5;
                numberOfColumnsPerRow[4] = 5;
                numberOfColumnsPerRow[5] = 6;
                break;
            case 32:
                numberOfColumnsPerRow[0] = 8;
                numberOfColumnsPerRow[1] = 8;
                numberOfColumnsPerRow[2] = 8;
                numberOfColumnsPerRow[3] = 8;
                break;
        }
        return numberOfColumnsPerRow;
    }
}
