namespace DiamondKata
{
    public class DiamondKata
    {
        public static string CreateDiamond(char letter)
        {
            if ((letter >= 'a' && letter <= 'z' || letter >= 'A' && letter <= 'Z') is false)
            {
                throw new ArgumentException("Argument must be a letter", nameof(letter));
            }
            throw new NotImplementedException("CreateDiamond is not implemented yet");
        }
    }
}