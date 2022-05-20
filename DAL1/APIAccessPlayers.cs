using DAL1.QuickType;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL1
{
    public class GenericList<T>:IList<T>
    {
        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T input) { }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    internal class APIAccessPlayers
    {
        public static IList<Tekma> readCountries()
        {
            IList<Tekma> players = new List<Tekma>();
            string m = "https://world-cup-json-2018.herokuapp.com/teams/results";
            string z = "http://worldcup.sfg.io/teams/results";
            string[] l = TextAccess.Split(':');

            if (l[1] == "Muško nogometno")
            {

                players = APIAccessTeams.GetData2(m);

            }
            else
            {
                players = APIAccessTeams.GetData2(z);
            }
            return players;
        }

    }
}
