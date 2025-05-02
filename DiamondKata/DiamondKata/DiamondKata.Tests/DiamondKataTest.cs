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
    }
}