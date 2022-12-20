
namespace tic_tac_toe
{

    using Position = Tuple< int, int >;

    abstract class Player
    {
        protected char sign;
        public abstract Position Choose( Board board );
        public char GetSign()
        {
            return this.sign;
        }

    }

}
