using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassLibrary10Lab;
using static System.Net.Mime.MediaTypeNames;

namespace Лабораторная_работа_12._1
{
    public class MyList<T> where T: IInit, ICloneable, new()
    {
        Point<T>? beg = null;
        Point<T>? end = null;
        int count = 0;
        public int Count => count;

        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }

        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null)
            {
                beg.Pred = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddToSelectNumber(T item, int number) //добавление элемента в середину
        {
            if (beg == null) throw new Exception("the emty list"); //проверка на пустоту
            Point<T>? current = beg;
            Point<T>? pos = new Point<T>(item);
            for (int i = 1; i<number-1; i++) //доходим до номера элемента
            {
                current = current.Next;
            }
            //добавлем элемент
            pos.Pred = current; 
            pos.Next = current.Next;
            current.Next = pos;
            pos.Next.Pred = pos;
            count++;
            
        }

        public MyList() { }

        public MyList(int size)
        {
            if (size <= 0) throw new Exception("size less zero");
            beg = MakeRandomData();
            end = beg;
            for (int i = 1; i < size; i++)
            {
                T newItem = MakeRandomItem();
                AddToEnd(newItem);
            }
            count = size;
        }
        public void PrintList()
        {
            if (count == 0 || beg == null) Console.WriteLine("the list empty");
            Point<T>? current = beg;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }
        public Point<T>? FindItem(T item)
        {
            Point<T>? current = beg;
            while(current != null)
            {
                if (current.Data == null) throw new Exception("Data is null");
                if (current.Data.Equals(item)) return current;
                current = current.Next;
            }
            return null;
        }

        public bool RemoveItem(T item)
        {
            if (beg == null) throw new Exception("the emty list");
            Point<T>? pos = FindItem(item);
            if(pos==null) return false;
            count--;
            //one element
            if (beg == end)
            {
                beg = end = null;
                return true;
            }
            //first
            if (pos.Pred == null)
            {
                beg = beg?.Next;
                beg.Pred = null;
                return true;
            }
            //last
            if (pos.Next == null)
            {
                end = end.Pred;
                end.Next = null;
                return true;
            }
            Point<T> next = pos.Next;
            Point<T> pred = pos.Pred;
            pos.Next.Pred = pred;
            pos.Pred.Next = next;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Point<T> current = beg;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public object Clone()
        {
            MyList<T> clone = new MyList<T>();
            foreach (T element in this)
            {
                clone.AddToEnd((T)element.Clone());
            }
            return clone;
        }

        //public Point<T>? DeletePoint(Watch item, string brand)
        //{
        //    if (beg == null) throw new Exception("the emty list");
        //    Point<Watch> pos = new Point<Watch>(item);

        //    if ((Watch)beg.Data.Brand == brand)
        //    {
        //        beg = beg.Next;
        //        beg.Pred = null;
        //    }
        //    while (!(pos.Data.Brand == brand))
        //    {
        //        pos = pos.Next;
        //    }
        //    pos.Pred.Next = pos.Next;
        //    return null;
        //}

    }
}
