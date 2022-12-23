
namespace tic_tac_toe
{

    using Position = Tuple< int, int >;

    abstract class Player
    {
        protected char sign;
        protected string name = Globals.DEFAULT_PLAYER_NAME;
        public abstract Position Select( Dictionary< Position, char > marked );
        public string GetName()
        {
            return this.name;
        }
        public char GetSign()
        {
            return this.sign;
        }

    }

    class HumanConsole : Player
    {
        public HumanConsole( char sign )
        {
            this.sign = sign;
        }
        public HumanConsole( char sign, string name )
        {
            this.sign = sign;
            this.name = name;
        }
        public override Position Select( Dictionary<Position, char> marked )
        {
            Console.Write("Select cell ( x y ): ");
            string? input = Console.ReadLine();

            if ( input == null )
            {
                throw new InputError( Globals.READING_ERROR );
            }
            return ParseLine( input );
        }

        private Position ParseLine( string line )
        {
            string[] coords = line.Split(' ');
            if ( coords.Length != 2 )
            {
                throw new InputError( Globals.INPUT_ERROR );
            }

            int x;
            int y;

            bool success = Int32.TryParse( coords[0], out x );
            if ( !success )
            {
                throw new InputError( Globals.INPUT_ERROR );
            }

            success = Int32.TryParse( coords[1], out y );
            if ( !success )
            {
                throw new InputError( Globals.INPUT_ERROR );
            }

            return new Position( x, y );
        }
    }

}
