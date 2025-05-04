using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameWon = false;

    public int[,] gameBoard = new int[3, 3]; // Assuming this is a 2D array for the game board.

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void WinGame()
    {
        isGameWon = true;
        Debug.Log("You win!");
        // Add any additional win logic here, such as showing a UI or transitioning to a new scene.
    }

    public void FillBox(int gridX, int gridY, int value)
    {
        // Logic to fill the box goes here.
        // This could involve changing the color of the box, playing an animation, etc.
        gameBoard[gridX,gridY] = value;
        PrintGameBoard();
    }

    // Print out gameboard for ease of debugging
    public void PrintGameBoard()
    {
        Debug.Log("X Length: " + gameBoard.GetLength(0) + " Y Length: " + gameBoard.GetLength(1));
        string table = "Game Board:\n";
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            table += i + " -> ";
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                table += "" + gameBoard[i,j];
            }
            table += "\n";
        }
        Debug.Log(table);
    }
}
