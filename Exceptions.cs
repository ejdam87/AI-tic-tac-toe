
namespace tic_tac_toe
{
    class TicTacToeException : Exception
    {
        public TicTacToeException( string msg ) : base( msg ) { }
    }
    class OutOfBoundsException : TicTacToeException
    {
        public OutOfBoundsException( string msg ) : base( msg ) { }
    }

    class InputException : TicTacToeException
    {
        public InputException( string msg ) : base( msg ) { }
    }

    class PlayerException : TicTacToeException
    {
        public PlayerException( string msg ) : base( msg ) { }
    }

    class ConsoleArgumentException : TicTacToeException
    {
        public ConsoleArgumentException( string msg ) : base( msg ) { }
    }
}
