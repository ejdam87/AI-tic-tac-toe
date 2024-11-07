
namespace tic_tac_toe
{
    class ConsoleGame
    {

        // TODO: Parsers
        public static Player ParsePlayer( string param )
        {
            return new HumanConsole( 'O' );
        }

        public static Board ParseBoard( string param )
        {
            return new InfiniteBoard();
        }

        public static int ParseCount( string param )
        {
            return -1;
        }

        /*
        public static void Main( string[] argv )
        {

            if ( argv.Length == 2 && argv[ 1 ] == "-help" )
            {
                Console.WriteLine( Globals.CONSOLE_HELP );
            }

            Player p1 = new HumanConsole( Globals.DEFAULT_PLAYER1_SING, Globals.DEFAULT_PLAYER1_NAME );
            Player p2 = new HumanConsole( Globals.DEFAULT_PLAYER2_SING, Globals.DEFAULT_PLAYER2_NAME );
            Board board = new InfiniteBoard();
            int count = Globals.DEFAULT_WIN_COUNT;

            foreach ( string param in argv )
            {
                if ( param.Contains( "-p1" ) )
                {
                    p1 = ParsePlayer( param );
                }

                else if ( param.Contains( "-p2" ) )
                {
                    p2 = ParsePlayer( param );
                }

                else if ( param.Contains(  "-board" ) )
                {
                    board = ParseBoard( param );
                }

                else if ( param.Contains( "-count" ) )
                {
                    count = ParseCount( param );
                }

                else
                {
                    throw new ConsoleArgumentException( "Invalid argument provided! ( try -help )" );
                }
            }

            Session session = new Session( board, p1, p2, count );
            session.PlayConsole();

        }
        */
    }
}
