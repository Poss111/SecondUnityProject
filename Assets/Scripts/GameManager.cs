using UnityEngine;
using System.Collections.Generic;
using TMPro; // Assuming you are using TextMeshPro for UI text

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameWon = false;

    public int[,] gameBoard = new int[3, 3]; // Assuming this is a 2D array for the game board.

    private List<GameObject> gameObjects;

    public PlayerEnum currentPlayer = PlayerEnum.PlayerX; // Assuming you have a Player enum defined somewhere.
    
    public TMP_Text turnText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            gameObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("BoardCell"));
            Debug.Log("Found " + gameObjects.Count + " game objects in TopLeft folder.");
            UpdateTurnText();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateTurnText()
    {
        if (turnText != null)
        {
            turnText.text = "Current Player: " + currentPlayer.ToString();
        }
        else
        {
            Debug.LogError("Turn text is not assigned in the inspector.");
        }
    }

    public void NextTurn()
    {
        // Logic to switch turns between players
        if (currentPlayer == PlayerEnum.PlayerX)
        {
            currentPlayer = PlayerEnum.PlayerO;
        }
        else
        {
            currentPlayer = PlayerEnum.PlayerX;
        }
        UpdateTurnText();
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
        CheckIfGameWon();
        NextTurn();
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


    // Check if the Tic Tac Toe game is won
    public void CheckIfGameWon()
    {
        // Check rows, columns, and diagonals for a win condition
        for (int i = 0; i < 3; i++)
        {
            if (gameBoard[i, 0] == gameBoard[i, 1] && gameBoard[i, 1] == gameBoard[i, 2] && gameBoard[i, 0] != 0)
            {
                WinGame();
                return;
            }
            if (gameBoard[0, i] == gameBoard[1, i] && gameBoard[1, i] == gameBoard[2, i] && gameBoard[0, i] != 0)
            {
                WinGame();
                return;
            }
        }
        if (gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2] && gameBoard[0, 0] != 0)
        {
            WinGame();
            return;
        }
        if (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 0] && gameBoard[0, 2] != 0)
        {
            WinGame();
            return;
        }
    }

    void OnGUI()
    {
        if (GameManager.Instance.isGameWon == true)
        {
            Debug.Log("Game is won, no reset button available.");
            // Create a button at position (10, 10) with size (100, 30)
            if (GUI.Button(new Rect(10, 10, 100, 30), "Reset"))
            {
                ResetGame();
            }
        }
    }

    void ResetGame()
    {
        // Logic to reset the game
        Debug.Log("Game has been reset!");
        // Add your reset logic here
        for (int i = 0; i < gameObjects.Count; i++)
        {
            // Reset game object sprite
            GameObject gameObject = gameObjects[i];
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = null; // Reset to default sprite or assign a specific sprite
            }
        }
        isGameWon = false;
    }
    
}
