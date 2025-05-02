namespace DiamondKata.Tests
{
    public class DiamondKataTest
    {
        [Test]
        public void TestInputAcceptsOnlyLetter()
        {
            var diamond = new DiamondKata();
            Assert.Throws<ArgumentException>(() => DiamondKata.CreateDiamond('1'));
        }
    }
}