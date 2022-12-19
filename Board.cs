
namespace tic_tac_toe
{
    using Position = Tuple< int, int >;

    abstract class Board
    {
        protected int rows;
        protected int cols;
        public abstract void Set( int x, int y, char sign );
        public abstract char Get( int x, int y );
        public abstract void Clear();

        public override string ToString()
        {
            string[] str_rows = new string[ this.rows ];
            char[] row = new char[ this.cols ];

            for ( int i = 0; i < this.rows; i++ )
            {
                for( int j = 0; j < this.cols; j++ )
                {
                    row[ j ] = Get( j, i );
                }
                str_rows[ i ] = new String( row );
            }

            string res = String.Join(Environment.NewLine, str_rows);
            return res + Environment.NewLine;   // NL at the end
        }
    }

    class FiniteBoard : Board
    {
        // Attributes
        private char[,] board;
        // ---

        // Constructors
        public FiniteBoard( int n )
        {
            this.board = new char[ n, n ];
            this.rows = n;
            this.cols = n;
            Clear();
        }

        public FiniteBoard( int m, int n )
        {
            this.board = new char[ m, n ];
            this.rows = m;
            this.cols = n;
            Clear();
        }
        // ---

        // Public methods
        public override char Get( int x, int y )
        {
            return this.board[ y, x ];
        }

        public override void Set( int x, int y, char sign )
        {
            this.board[ y, x ] = sign;
        }

        public override void Clear()
        {
            for ( int i = 0; i < this.rows; i++ )
            {
                for( int j = 0; j < this.cols; j++ )
                {
                    Set( j, i, Globals.EMPTY );
                }
            }
        }
        // ---

    }

    class InfiniteBoard : Board
    {
        // Attributes
        int margin = 2;
        private Dictionary< Position, char > board;
        // ---

        // Constructors
        public InfiniteBoard()
        {
            this.board = new Dictionary<Position, char>();
            this.rows = margin + 1;
            this.cols = margin + 1;
        }
        public InfiniteBoard( Dictionary< Position, char > d )
        {
            this.board = d;
            foreach ( KeyValuePair< Position, char > kv in d )
            {
                Boundaries( kv.Key.Item1, kv.Key.Item2 );
            }
        }
        // ---

        // Public methods
        public override char Get( int x, int y )
        {
            Position pos = new Position( x, y );
            if ( this.board.ContainsKey( pos ) )
            {
                return this.board[ pos ];
            }
            return Globals.EMPTY;
        }

        public override void Set( int x, int y, char sign )
        {
            Position pos = new Position( x, y );
            this.board[ pos ] = sign;
            Boundaries( x, y );
        }

        public override void Clear()
        {
            this.board = new Dictionary<Position, char>();
            this.rows = margin + 1;
            this.cols = margin + 1;
        }
        // ---

        // Private methods
        private void Boundaries( int x, int y )
        {
            if ( x > this.cols - 1 )
            {
                this.cols = x + 1;
            }
            if ( y > this.rows - 1 )
            {
                this.rows = y + 1;
            }
        }
        // ---

    }

}
