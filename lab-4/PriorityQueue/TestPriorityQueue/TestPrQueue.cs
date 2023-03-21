using System.Numerics;
using PriorityQueue;

namespace TestPriorityQueue
{
    [TestClass]
    public class TestPrQueue
    {
        [TestMethod]
        public void TestAdd()
        {
        }

        [TestMethod]
        public void TestRemMax()
        {
            ///maxindex and remMax
            PrQueue Q = new PrQueue();
            try
            {
                Q.GetMax();
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is PrQueue.PrQueueEmpty);
            }
            try
            {
                Q.RemMax();
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is PrQueue.PrQueueEmpty);
            }

            ///Items for testing
            Item e = new Item(); ;
            Item e1 = new Item(1, "a");
            Item e2 = new Item(2, "b");
            Item e3 = new Item(3, "c");
            Item e5 = new Item(5, "a");

            Q.Add(e1);
            e = Q.GetMax();
            Assert.IsTrue(e == e1);
            e = Q.RemMax();
            Assert.IsTrue(Q.IsEmpty());
            Assert.IsTrue(e == e1);

            Q.Add(e5); Q.Add(e2); Q.Add(e3);
            e = Q.GetMax();
            Assert.IsTrue(e == e5);
            e = Q.RemMax();
            Assert.IsTrue(2 == Q.GetLength());
            Assert.IsTrue(e == e5);

        }

        [TestMethod]
        public void TestMaxIndex()
        {
        }
    }
}