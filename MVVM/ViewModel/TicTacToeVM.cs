﻿using MAUITicTacToe.MVVM.View;

namespace MAUITicTacToe.MVVM.ViewModel;

public class TicTacToeVM 
{
    bool isXorO = false;
    int scoreCount = 0;

    void buttonIsDisabled()
    {
        //disable all buttons
        Button1.IsEnabled = false;
    }
}