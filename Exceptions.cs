
namespace tic_tac_toe
{
    class TicTacToeError : Exception
    {
        public TicTacToeError( string msg ) : base( msg ) { }
    }
    class OutOfBoundsException : TicTacToeError
    {
        public OutOfBoundsException( string msg ) : base( msg ) { }
    }

    class InputError : TicTacToeError
    {
        public InputError( string msg ) : base( msg ) { }
    }
}
