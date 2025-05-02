namespace DiamondKata
{
    public static class DiamondKata
    {
        public static string CreateDiamond(char letter)
        {
            if ((letter >= 'a' && letter <= 'z' || letter >= 'A' && letter <= 'Z') is false)
            {
                throw new ArgumentException("Argument must be a letter", nameof(letter));
            }
            if (letter == 'A')
            {
                return "A";
            }
            throw new NotImplementedException("CreateDiamond is not implemented yet");
        }
    }
}