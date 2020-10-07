using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingDemo
{
    class MultiThread
    {
        public delegate void ResultThread(int Result);

        private int _Number;
        private ResultThread _ResultThread;

        public MultiThread(int number, ResultThread resultthread)
        {
            _Number = number;
            _ResultThread = resultthread;
        }

        public void CalculateSum()
        {
            int Result = 0;
            for (int i = 0; i < _Number; i++)
            {
                Result = Result + i;
            }

            if (_ResultThread != null)
            {
                _ResultThread(Result);
            }
        }
        public void CalculateProduct()
        {
            int Result = 1;
            for (int i = 1; i < _Number; i++)
            {
                Result = Result * i;
            }

            if (_ResultThread != null)
            {
                _ResultThread(Result);
            }
        }

    }

    class Program
    {
        public static void ResultMethod(int Result)
        {
            Console.WriteLine("The result is "+Result);
        }
        
        static void Main(string[] args)
        {
            int num = 5;
           MultiThread.ResultThread Results = new MultiThread.ResultThread(ResultMethod);
           var ob =new MultiThread(num,Results);
           Thread t1= new Thread(new ThreadStart(ob.CalculateSum));
           Thread t2 = new Thread(new ThreadStart(ob.CalculateProduct));
            t1.Start();
            t2.Start();
            Console.Read();

        }
    }
}
