namespace DiamondKata.Tests
{
    public class DiamondKataTest
    {
        [Test]
        public void TestInputAcceptsOnlyLetter()
        {
            var diamond = new DiamondKata();
            var result = diamond.CreateDiamond('1');
            Assert.Throws<ArgumentException>(() => diamond.CreateDiamond('1'));
        }
    }
}