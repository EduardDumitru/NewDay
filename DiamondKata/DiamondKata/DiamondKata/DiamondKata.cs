using System.Text;

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

            if (letter >= 'a' && letter <= 'z')
            {
                letter = (char)(letter - 32);
            }

            if (letter == 'A')
            {
                return "A";
            }

            var diamond = new StringBuilder();
            var size = (letter - 'A') * 2 + 1;
            var middle = size / 2;
            var currentLetter = 'A';
            for (var i = 0; i < size; i++)
            {
                var underlines = Math.Abs(middle - i);
                diamond.Append('_', underlines);
                diamond.Append(currentLetter);
                if (currentLetter != 'A')
                {
                    diamond.Append('_', (size - 2 * underlines - 2));
                    diamond.Append(currentLetter);
                }
                diamond.Append('_', underlines);
                diamond.AppendLine();
                if (i < middle)
                {
                    currentLetter++;
                }
                else
                {
                    currentLetter--;
                }
            }

            return diamond.ToString().Trim();
        }
    }
}