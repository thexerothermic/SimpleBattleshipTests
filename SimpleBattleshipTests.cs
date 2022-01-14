using NUnit.Framework;
using SimpleBattleship;
using System;
using System.Collections.Generic;

namespace SimpleBattleshipTests
{
    public class SimpleBattleshipTests
    {
        [Test]
        public void constructorCreatesProperX()
        {
            var coordinate = new Coordinate(-1, -1);
            Assert.AreEqual(-1,coordinate.x);
        }
        [Test]
        public void constructorCreatesProperY()
        {
            var coordinate = new Coordinate(-1, -1);
            Assert.AreEqual(-1,coordinate.y);
        }
        [Test]
        public void parserHandlesZeroValue()
        {
            var coordinate = new Coordinate(0, 0);
            Assert.AreEqual(coordinate, Coordinate.Parse("0,0"));
        }
        [Test]
        public void parserHandlesSmallNegativeValue()
        {
            var coordinate = new Coordinate(-1, -1);
            Assert.AreEqual(coordinate, Coordinate.Parse("-1,-1"));
        }
        [Test]
        public void parserHandlesLargeNegativeValue()
        {
            var coordinate = new Coordinate(-1, -1);
            Assert.AreEqual(coordinate, Coordinate.Parse("-100000,-1000500"));
        }
        [Test]
        public void parserHandlesNormalPositiveValue()
        {
            var coordinate = new Coordinate(50, 47);
            Assert.AreEqual(coordinate, Coordinate.Parse("50,47"));
        }
        [Test]
        public void parserHandlesMaxPositiveValue()
        {
            var coordinate = new Coordinate(99, 99);
            Assert.AreEqual(coordinate, Coordinate.Parse("99,99"));
        }
        [Test]
        public void parserHandlesLargePositiveValue()
        {
            var coordinate = new Coordinate(-1, -1);
            Assert.AreEqual(coordinate, Coordinate.Parse("100000,2352341"));
        }
        [Test]
        public void parserHandlesTooFewCoordinates()
        {
            var coordinate = new Coordinate(-1, -1);
            Assert.AreEqual(coordinate, Coordinate.Parse("8"));
        }
        [Test]
        public void parserHandlesTooManyCoordinates()
        {
            var coordinate = new Coordinate(-1, -1);
            Assert.AreEqual(coordinate, Coordinate.Parse("8,7,5"));
        }
        [Test]
        public void parserHandlesInvalidCharacter()
        {
            var coordinate = new Coordinate(-1, -1);
            Assert.AreEqual(coordinate, Coordinate.Parse("#42$,85"));
        }
        [Test]
        public void getDistanceReturnsCorrectValueWithZeros()
        {
            var coordinate = new Coordinate(0, 0);
            Assert.AreEqual(0, coordinate.getDistance(new Coordinate(0, 0)));
        }
        [Test]
        public void getDistanceReturnsCorrectDecimalValue()
        {
            var coordinate = new Coordinate(1, 1);
            var realDistance = Math.Pow(Math.Pow(15, 2) + Math.Pow(18, 2), .5);
            Assert.AreEqual(realDistance, coordinate.getDistance(new Coordinate(16, 19)));
        }
        [Test]
        public void computerGeneratesCoordinatesWithinRange()
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            for (int k = 0; k < 10000; k++)
            {
                coordinates.AddRange(Game.getComputerCoordinates());
            }
            foreach (Coordinate coordinate in coordinates)
            {
                if (coordinate.x < 0 || coordinate.x > 99 || coordinate.y < 0 || coordinate.y > 99)
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }
    }
}