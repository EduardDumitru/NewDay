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
        public void TestKataWorksWithLetterA()
        {
            var result = DiamondKata.CreateDiamond('A');
            Assert.That(result, Is.EqualTo("A"));
        }
    }
}