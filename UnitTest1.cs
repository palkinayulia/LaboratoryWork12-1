using ClassLibrary10Lab;
using Лабораторная_работа_12._1;
namespace Lab12.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddToBegin() //добавление в начало списка
        {
            //Arrange
            MyList<Watch> list = new MyList<Watch>();
            //Act
            Watch clock = new Watch();
            clock.RandomInit();
            list.AddToBegin(clock);
            list.AddToBegin(clock);
            //Assert
            Assert.AreEqual(2, list.Count);
        }
        [TestMethod]
        public void TestAddToEnd() //добавление в конец списка
        {
            //Arrange
            MyList<Watch> list = new MyList<Watch>();
            //Act
            Watch clock = new Watch();
            clock.RandomInit();
            list.AddToEnd(clock);
            list.AddToEnd(clock);
            //Assert
            Assert.AreEqual(2, list.Count);
        }
        [TestMethod]
        public void TestAddToSelectNumber() //добавление в середину списка
        {
            //Arrange
            MyList<Watch> list = new MyList<Watch>(3);
            //Act
            Watch clock = new Watch();
            clock.RandomInit();
            list.AddToSelectNumber(clock, 3);
            //Assert
            Assert.AreEqual(4, list.Count);
        }
        [TestMethod]
        public void TestRemoveItemFirst() //удаление первого элемента
        {
            //Arrange
            MyList<Watch> list = new MyList<Watch>();
            //Act
            Watch clock1 = new Watch();
            Watch clock2 = new Watch();
            Watch clock3 = new Watch();
            clock1.RandomInit();
            list.AddToEnd(clock1);
            clock2.RandomInit();
            list.AddToEnd(clock2);
            clock3.RandomInit();
            list.AddToEnd(clock3);
            list.RemoveItem(clock1);
            //Assert
            Assert.AreEqual(2, list.Count);
        }
        [TestMethod]
        public void TestRemoveItemMiddle() //удаление элемента из середины
        {
            //Arrange
            MyList<Watch> list = new MyList<Watch>();
            //Act
            Watch clock1 = new Watch();
            Watch clock2 = new Watch();
            Watch clock3 = new Watch();
            clock1.RandomInit();
            list.AddToEnd(clock1);
            clock2.RandomInit();
            list.AddToEnd(clock2);
            clock3.RandomInit();
            list.AddToEnd(clock3);
            list.RemoveItem(clock2);
            //Assert
            Assert.AreEqual(2, list.Count);
        }
        [TestMethod]
        public void TestRemoveItemLast() //удаление последнего элемента
        {
            //Arrange
            MyList<Watch> list = new MyList<Watch>();
            //Act
            Watch clock1 = new Watch();
            Watch clock2 = new Watch();
            Watch clock3 = new Watch();
            clock1.RandomInit();
            list.AddToEnd(clock1);
            clock2.RandomInit();
            list.AddToEnd(clock2);
            clock3.RandomInit();
            list.AddToEnd(clock3);
            list.RemoveItem(clock3);
            //Assert
            Assert.AreEqual(2, list.Count);
        }
        [TestMethod]
        public void TestRemoveItemOne() //удаление одного элемента
        {
            //Arrange
            MyList<Watch> list = new MyList<Watch>();
            //Act
            Watch clock1 = new Watch();
            list.AddToBegin(clock1);
            list.RemoveItem(clock1);
            //Assert
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void TestPointNoParam() //запись без параметров
        {
            //Arrange
            Point<Watch> point = new Point<Watch>();
            //Act
            //Assert
            Assert.AreEqual(null, point.Pred);
        }
        [TestMethod]
        public void TestCloneList() //глубокое копирование
        {
            //Arrange
            MyList<Watch> list = new MyList<Watch>(5);
            //Act
            MyList<Watch> list2 = (MyList<Watch>)list.Clone();
            //Assert
            Assert.AreEqual(list2.Count, list.Count);
        }
        [TestMethod]
        public void TestConstructorEx() //тестирование исключения с 0 размером
        {
            Assert.ThrowsException<Exception>(() => new MyList<Watch>(0));
        }
    }
}