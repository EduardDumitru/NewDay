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
            var extraCharacter = '_';
            var result = DiamondKata.CreateDiamond('B');
            var lines = result.Split("\r\n");

            Assert.Multiple(() =>
            {
                Assert.That(lines[0], Is.EqualTo(new string(extraCharacter, 1) + "A" + new string(extraCharacter, 1)));
                Assert.That(lines[1], Is.EqualTo("B" + new string(extraCharacter, 1) + "B"));
            });
        }

        [Test]
        public void TestKataWorksWithThirdAlphabetUppercaseLetter()
        {
            var extraCharacter = '_';
            var result = DiamondKata.CreateDiamond('C');
            var lines = result.Split("\r\n");

            Assert.Multiple(() =>
            {
                Assert.That(lines[0], Is.EqualTo(new string(extraCharacter, 2) + "A" + new string(extraCharacter, 2)));
                Assert.That(lines[1], Is.EqualTo(new string(extraCharacter, 1) + "B" + new string(extraCharacter, 1) + "B" + new string(extraCharacter, 1)));
                Assert.That(lines[2], Is.EqualTo("C" + new string(extraCharacter, 3) + "C"));
                Assert.That(lines[0], Is.EqualTo(new string(extraCharacter, 2) + "A" + new string(extraCharacter, 2)));
                Assert.That(lines[1], Is.EqualTo(new string(extraCharacter, 1) + "B" + new string(extraCharacter, 1) + "B" + new string(extraCharacter, 1)));
                Assert.That(lines[2], Is.EqualTo("C" + new string(extraCharacter, 3) + "C"));
            });
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
            var extraCharacter = '_';
            var result = DiamondKata.CreateDiamond('Z');
            var lines = result.Split("\r\n");

            // Verify the number of rows matches the expected size
            Assert.That(lines, Has.Length.EqualTo(51)); // 'Z' results in 51 rows

            Assert.Multiple(() =>
            {
                // Verify the first and last rows contain only 'A' with 25 underscores on each side
                Assert.That(lines[0], Is.EqualTo(new string(extraCharacter, 25) + "A" + new string(extraCharacter, 25)));
                Assert.That(lines[^1], Is.EqualTo(new string(extraCharacter, 25) + "A" + new string(extraCharacter, 25)));

                // Verify the middle row contains 'Z' with no underscores between the letters
                Assert.That(lines[25], Is.EqualTo("Z" + new string(extraCharacter, 49) + "Z"));
            });

            // Verify symmetry: each row matches its corresponding row from the bottom
            for (int i = 0; i < lines.Length / 2; i++)
            {
                Assert.That(lines[i], Is.EqualTo(lines[^(i + 1)]));
            }
        }
    }
}