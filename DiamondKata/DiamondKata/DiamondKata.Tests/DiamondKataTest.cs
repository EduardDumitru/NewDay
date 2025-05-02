namespace DiamondKata.Tests
{
    public class DiamondKataTest
    {
        [Test]
        public void TestInputAcceptsOnlyLetter()
        {
            Assert.Throws<ArgumentException>(() => DiamondKata.CreateDiamond('1'));
        }

        [Test]
        public void TestKataWorksWithFirstAlphabetUppercaseLetter()
        {
            var result = DiamondKata.CreateDiamond('A');
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void TestKataWorksWithFirstAlphabetLowercaseLetter()
        {
            var result = DiamondKata.CreateDiamond('a');
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void TestKataWorksWithSecondAlphabetUppercaseLetter()
        {
            var result = DiamondKata.CreateDiamond('B');
            Assert.That(result, Is.EqualTo("_A_\r\nB_B\r\n_A_"));
        }

        [Test]
        public void TestKataWorksWithThirdAlphabetUppercaseLetter()
        {
            var result = DiamondKata.CreateDiamond('C');
            Assert.That(result, Is.EqualTo("__A__\r\n_B_B_\r\nC___C\r\n_B_B_\r\n__A__"));
        }

        [Test]
        public void TestInputDoesNotAcceptSpecialCharacters()
        {
            Assert.Throws<ArgumentException>(() => DiamondKata.CreateDiamond('@'));
        }

        [Test]
        public void TestInputDoesNotAcceptWhitespace()
        {
            Assert.Throws<ArgumentException>(() => DiamondKata.CreateDiamond(' '));
        }

        [Test]
        public void TestKataWorksWithLastAlphabetUppercaseLetter()
        {
            var result = DiamondKata.CreateDiamond('Z');
            var lines = result.Split("\r\n");

            // Verify the number of rows matches the expected size
            Assert.That(lines, Has.Length.EqualTo(51)); // 'Z' results in 51 rows

            Assert.Multiple(() =>
            {
                // Verify the first and last rows contain only 'A' with 25 underscores on each side
                Assert.That(lines[0], Is.EqualTo(new string('_', 25) + "A" + new string('_', 25)));
                Assert.That(lines[^1], Is.EqualTo(new string('_', 25) + "A" + new string('_', 25)));

                // Verify the middle row contains 'Z' with no underscores between the letters
                Assert.That(lines[25], Is.EqualTo("Z" + new string('_', 49) + "Z"));
            });

            // Verify symmetry: each row matches its corresponding row from the bottom
            for (int i = 0; i < lines.Length / 2; i++)
            {
                Assert.That(lines[i], Is.EqualTo(lines[^(i + 1)]));
            }
        }
    }
}