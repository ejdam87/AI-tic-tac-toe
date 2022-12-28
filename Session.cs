
namespace tic_tac_toe
{
    using Position = Tuple< int, int >;

    class Session
    {
        private Board board;
        private Player p1;
        private Player p2;
        private Player? winner = null;
        private Player onMove;
        private int count = 3;

        public Session( Player p1, Player p2 )
        {
            this.board = new InfiniteBoard();
            this.p1 = p1;
            this.p2 = p2;
            this.onMove = p1;
        }

        public Session( Board board, Player p1, Player p2 )
        {
            this.board = board;
            this.p1 = p1;
            this.p2 = p2;
            this.onMove = p1;
        }

        public Session( Board board, Player p1, Player p2, int count )
        {
            this.board = board;
            this.p1 = p1;
            this.p2 = p2;
            this.onMove = p1;
            this.count = count;
        }

        public Player? GetWinner()
        {
            return this.winner;
        }

        public Player GetPlayer( int num )
        {
            if ( num == 1 )
            {
                return this.p1;
            }
            else if ( num == 2 )
            {
                return this.p2;
            }
            else
            {
                throw new PlayerError( Globals.PLAYER_PICK_ERROR );
            }
        }

        public void SetCount( int count )
        {
            this.count = count;
        }

        public void PlayConsole()
        {

            while ( !this.board.Solved( this.count ) )
            {
                Console.Write( this.board );

                Console.WriteLine( "---" );
                Console.WriteLine( "On move:" + this.onMove.GetName() );
                Console.WriteLine( "---" );

                Position xy = this.onMove.Select( this.board.GetMarked() );
                this.board.Set( xy.Item1, xy.Item2, this.onMove.GetSign() );
                this.onMove = GetOtherPlayer();
            }

            this.winner = GetOtherPlayer();
            Console.WriteLine( "---" );
            Console.WriteLine( "Winner: " + this.winner.GetName() );

        }

        private Player GetOtherPlayer()
        {
            if ( this.onMove == this.p1 )
            {
                return this.p2;
            }
            return this.p1;
        }
    }

}
