
namespace tic_tac_toe
{
    using Position = Tuple< int, int >;

    abstract class Board
    {
        protected Dictionary< Position, char > board;
        protected int rows;
        protected int cols;
        public virtual char Get( int x, int y )
        {
            Position pos = new Position( x, y );
            if ( this.board.ContainsKey( pos ) )
            {
                return this.board[ pos ];
            }
            return Globals.EMPTY;
        }

        public virtual void Set( int x, int y, char sign )
        {
            Position pos = new Position( x, y );
            this.board[ pos ] = sign;
        }
        public virtual void Clear()
        {
            this.board = new Dictionary<Position, char>();
        }

        public override string ToString()
        {
            string res = HorizontalNumbering();
            res += MarginLine();
            for ( int i = 0; i < this.rows; i++ )
            {
                res += StringRow( i );
                res += MarginLine();
            }
            return res;
        }
        public bool Solved( int count )
        {
            for ( int i = 0; i < this.rows; i++ )
            {
                for( int j = 0; j < this.cols; j++ )
                {
                    if ( Get( j, i ) != Globals.EMPTY && CheckSolved( j, i, count ) )
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private string HorizontalNumbering( )
        {
            string res = "   ";
            for ( int i = 0; i < this.cols; i++)
            {
                res += "  " + i.ToString() + " ";
            }
            return res + "\n";
        }
        private string VerticalNumbering( int i )
        {
            string res;
            string num = i.ToString();
            if ( num.Length == 1 )
            {
                res = " " + num + " ";
            }
            else if ( num.Length == 2 )
            {
                res = num + " ";
            }
            else
            {
                res = num;
            }
            return res;
        }
        private string MarginLine( )
        {
            string res = "   +";
            for ( int i = 0; i < this.cols; i++ )
            {
                res += "---+";
            }
            return res + "\n";
        }
        private string StringRow( int i )
        {
            string res = VerticalNumbering( i );
            res += "|";
            for ( int j = 0; j < this.cols; j++ )
            {
                res += " ";
                res += Get( j, i ).ToString();
                res += " |";
            }
            return res + "\n";
        }
        private bool CheckSolved( int x, int y, int r)
        {
            Tuple< int, int >[] dirs = new Tuple< int, int >[]{ new Tuple< int, int >(+1, 0),
                                                                new Tuple< int, int >(-1, 0),
                                                                new Tuple< int, int >(0, +1),
                                                                new Tuple< int, int >(0, -1),
                                                                new Tuple< int, int >(+1, +1),
                                                                new Tuple< int, int >(+1, -1),
                                                                new Tuple< int, int >(-1, +1),
                                                                new Tuple< int, int >(-1, -1) };
    
            foreach (Tuple< int, int > dir in dirs )
            {
                if ( SolvedDir( x, y, dir, r ) )
                {
                    return true;
                }
            }
            return false;
        }
        private bool SolvedDir( int x, int y, Tuple< int, int > dir, int count )
        {
            int have = 0;
            char sign = Get( x, y );

            while ( Inbound( x, y ) && Get( x, y ) == sign )
            {
                have++;
                x += dir.Item1;
                y += dir.Item2;
            }
            return have >= count;
        }
        protected bool Inbound( int x, int y )
        {
            return x >= 0 && x < this.cols && y >= 0 && y < this.rows;
        }

    }

    class FiniteBoard : Board
    {
        // Constructors
        public FiniteBoard( int n )
        {
            this.board = new Dictionary<Position, char>();
            this.rows = n;
            this.cols = n;
            Clear();
        }

        public FiniteBoard( int m, int n )
        {
            this.board = new Dictionary<Position, char>();
            this.rows = m;
            this.cols = n;
            Clear();
        }
        // ---

        // Public methods
        public override char Get( int x, int y )
        {
            if ( !Inbound( x, y ) )
            {
                throw new Exception();
            }

            return base.Get( x, y );
        }

        public override void Set( int x, int y, char sign )
        {
            if ( !Inbound( x, y ) )
            {
                throw new Exception();
            }

            base.Set( x, y, sign );
        }
        // ---

    }

    class InfiniteBoard : Board
    {

        public InfiniteBoard()
        {
            this.board = new Dictionary<Position, char>();
            this.rows = Globals.MARGIN + 1;
            this.cols = Globals.MARGIN + 1;
        }
        public InfiniteBoard( Dictionary< Position, char > d )
        {
            this.board = d;
            foreach ( KeyValuePair< Position, char > kv in d )
            {
                Boundaries( kv.Key.Item1, kv.Key.Item2 );
            }
        }

        public override void Set( int x, int y, char sign )
        {
            base.Set( x, y, sign );
            Boundaries( x, y );
        }

        public override void Clear()
        {
            base.Clear();
            this.rows = Globals.MARGIN + 1;
            this.cols = Globals.MARGIN + 1;
        }

        private void Boundaries( int x, int y )
        {
            if ( x > this.cols - 1 )
            {
                this.cols = x + 1;
                this.cols += Globals.MARGIN;
            }
            if ( y > this.rows - 1 )
            {
                this.rows = y + 1;
                this.rows += Globals.MARGIN;
            }
        }
    }
}
