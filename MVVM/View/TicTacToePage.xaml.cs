using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUITicTacToe.MVVM.ViewModel;

namespace MAUITicTacToe.MVVM.View;

public partial class TicTacToePage : ContentPage
{
    public TicTacToePage()
    {
        InitializeComponent();
        
        //bind the view model to the view
        BindingContext = new TicTacToeVM();
    }
}