using Android.Service.Controls;
using MAUITicTacToe.MVVM.View;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;

namespace MAUITicTacToe.MVVM.ViewModel;

public class TicTacToeVM
{
    // Create a 3x3 string array to represent the game board
    string[,] game_board = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };

    // Keep track of the current player
    string current_player = "X";

    // Create event handlers for each button click
    Button1.Click += button_click;
    Button2.Click += button_click;
    Button3.Click += button_click;
    Button4.Click += button_click;
    Button5.Click += button_click;
    Button6.Click += button_click;
    Button7.Click += button_click;
    Button8.Click += button_click;
    Button9.Click += button_click;

    // Define the button_click method to handle button clicks
    void button_click(object sender, EventArgs e)
    {
        // Cast the sender object to a Button
        Button button = (Button)sender;

        // Update the game board with the current player's symbol
        int row, col;
        if (button == Button1) { row = 0; col = 0; }
        else if (button == Button2) { row = 0; col = 1; }
        else if (button == Button3) { row = 0; col = 2; }
        else if (button == Button4) { row = 1; col = 0; }
        else if (button == Button5) { row = 1; col = 1; }
        else if (button == Button6) { row = 1; col = 2; }
        else if (button == Button7) { row = 2; col = 0; }
        else if (button == Button8) { row = 2; col = 1; }
        else { row = 2; col = 2; }
        game_board[row, col] = current_player;

        // Update the button text to display the current player's symbol
        button.Text = current_player;

        // Check for a win or tie
        string winner = check_for_win();
        if (winner != "")
        {
            MessageBox.Show(winner + " wins!");
            reset_game();
            return;
        }
        if (check_for_tie())
        {
            MessageBox.Show("Tie game!");
            reset_game();
            return;
        }

        // Switch to the other player
        if (current_player == "X")
        {
            current_player = "O";
        }
        else
        {
            current_player = "X";
        }
    }





    string check_for_win()
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (game_board[i, 0] == game_board[i, 1] && game_board[i, 1] == game_board[i, 2] && game_board[i, 0] != "")
            {
                return game_board[i, 0];
            }
        }

        // Check columns
        for (int j = 0; j < 3; j++)
        {
            if (game_board[0, j] == game_board[1, j] && game_board[1, j] == game_board[2, j] && game_board[0, j] != "")
            {
                return game_board[0, j];
            }
        }

        // Check diagonals
        if (game_board[0, 0] == game_board[1, 1] && game_board[1, 1] == game_board[2, 2] && game_board[0, 0] != "")
        {
            return game_board[0, 0];
        }

        if (game_board[0, 2] == game_board[1, 1] && game_board[1, 1] == game_board[2, 0] && game_board[0, 2] != "")
        {
            return game_board[0, 2];
        }

        return "";
    }


    bool check_for_tie()
    {
        // Check if all buttons have been clicked
        foreach (Control control in Controls)
        {
            if (control is Button && control.Enabled)
            {
                return false;
            }
        }

        return true;
    }

    void reset_game()
    {
        // Reset the game board and button text
        game_board = new string[3, 3] { { "", "", "" }, { "", "", "" }, { "", "", "" } };
        foreach (Control control in Controls)
        {
            if (control is Button)
            {
                control.Enabled = true;
                control.Text = "";
            }
        }

        // Switch back to the first player
        current_player = "X";
    }
    

}
