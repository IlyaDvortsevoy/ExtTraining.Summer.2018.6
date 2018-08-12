using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericCollections
{
    public class Set<T> : ISet<T>
    {
        #region Fields
        private readonly HashTable _table;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Set<T> class optionally using given collection and capacity
        /// </summary>
        /// <param name="enumerable"> The given collection </param>
        /// <param name="capacity"> Initial capacity </param>
        public Set(IEnumerable<T> enumerable = null, int capacity = 10)
        {
            _table = new HashTable(enumerable, capacity);
        }
        #endregion

        #region Properties
        public int Count => _table.Size;

        public bool IsReadOnly => false;
        #endregion

        #region Public API
        /// <summary>
        /// Creates new Set<T> object containing all elements that are present in the two given Set<T> objects
        /// </summary>
        /// <param name="first"> The first Set<T> object to unite </param>
        /// <param name="second"> The second Set<T> object to unite </param>
        /// <returns></returns>
        public static Set<T> Union(Set<T> first, Set<T> second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException(
                    "Argumnet can't be null");
            }

            var temp = new Set<T>(first);

            foreach (var value in second)
            {
                if (!temp.Contains(value))
                {
                    temp.Add(value);
                }
            }

            return temp;
        }

        /// <summary>
        /// Adds the specified element to a set
        /// </summary>
        /// <param name="item"> Element to add </param>
        /// <returns> True if element had been added successfully, or false otherwise </returns>
        public bool Add(T item) => _table.Add(item);

        /// <summary>
        /// Removes all elements from a Set<T> object
        /// </summary>
        public void Clear() => _table.Clear();

        /// <summary>
        /// Determines whether a Set<T> object contains the specified element
        /// </summary>
        /// <param name="item"> The element to locate in the Set<T> object </param>
        /// <returns> True if the Set<T> object contains the specified element; otherwise, false </returns>
        public bool Contains(T item) => _table.Contains(item);

        /// <summary>
        /// Copies the elements of a Set<T> object to an array, starting at the specified array index
        /// </summary>
        /// <param name="array"> The one-dimensional array that is the destination of the elements copied from the Set<T> object. The array must have zero-based indexing. </param>
        /// <param name="arrayIndex"> The zero-based index in array at which copying begins </param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(
                    "Argument can't be null",
                    nameof(array));
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Argument can't be negative",
                    nameof(arrayIndex));
            }

            if (arrayIndex > array.Length - 1 ||
                array.Length - arrayIndex < Count)
            {
                throw new ArgumentException(
                    "Not enough space to copy");
            }           

            int i = 0;

            foreach (var value in this)
            {
                array[i] = value;
                i++;
            }
        }

        /// <summary>
        /// Removes all elements in the specified collection from the current Set<T> object
        /// </summary>
        /// <param name="other"> The collection of items to remove from the Set<T> object </param>
        public void ExceptWith(IEnumerable<T> other)
        {
            ValidateEnumerable(other);

            if (Count == 0)
            {
                return;
            }

            if (other == this)
            {
                this.Clear();
            }
            else
            {
                foreach (T value in other)
                {
                    this.Remove(value);
                }
            }
        }

        /// <summary>
        /// Returns a generic enumerator that iterates through a Set<T> object
        /// </summary>
        /// <returns> A Set<T>.Enumerator object for the Set<T> object </returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _table)
            {
                if (item != null)
                {
                    foreach (var value in item)
                    {
                        yield return value;
                    }
                }
            }
        }

        /// <summary>
        /// Modifies the current Set<T> object to contain only elements that are present in that object and in the specified collection
        /// </summary>
        /// <param name="other"> The collection to compare to the current Set<T> object </param>
        public void IntersectWith(IEnumerable<T> other)
        {
            ValidateEnumerable(other);

            if (Count == 0)
            {
                return;
            }

            if (other is ICollection<T> collection)
            {
                if (collection.Count == 0)
                {
                    this.Clear();
                    return;
                }
            }

            var result = new Set<T>();

            foreach (var value in other)
            {
                if (this.Contains(value))
                {
                    result.Add(value);
                }
            }

            this.Clear();

            foreach (var value in result)
            {
                this.Add(value);
            }
        }

        /// <summary>
        /// Determines whether a Set<T> object is a proper subset of the specified collection.
        /// </summary>
        /// <param name="other"> The collection to compare to the current Set<T> object. </param>
        /// <returns> True if the Set<T> object is a proper subset of other; otherwise, false </returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            ValidateEnumerable(other);

            if (other is ICollection<T> collection)
            { 
                if (collection != null &&
                    collection.Count > this.Count)
                {
                    if (this.Count == 0)
                    {
                        return true;
                    }

                    foreach (var item in this)
                    {
                        if (!collection.Contains(item))
                        {
                            return false;
                        }
                    }

                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Determines whether a Set<T> object is a proper superset of the specified collection
        /// </summary>
        /// <param name="other"> The collection to compare to the current Set<T> object </param>
        /// <returns> True if the Set<T> object is a proper superset of other; otherwise, false </returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            ValidateEnumerable(other);

            if (this.Count == 0)
            {
                return false;
            }

            if (other is ICollection<T> collection)
            {
                if (collection != null &&
                    this.Count > collection.Count)
                {
                    if (collection.Count == 0)
                    {
                        return true;
                    }

                    foreach (var item in collection)
                    {
                        if (!this.Contains(item))
                        {
                            return false;
                        }
                    }

                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Determines whether a Set<T> object is a subset of the specified collection
        /// </summary>
        /// <param name="other"> The collection to compare to the current Set<T> object </param>
        /// <returns> True if the Set<T> object is a subset of other; otherwise, false </returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            ValidateEnumerable(other);

            if (other is ICollection<T> collection)
            {
                if (collection != null &&
                    collection.Count >= this.Count)
                {
                    if (this.Count == 0)
                    {
                        return true;
                    }

                    foreach (var item in this)
                    {
                        if (!collection.Contains(item))
                        {
                            return false;
                        }
                    }

                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Determines whether a Set<T> object is a superset of the specified collection
        /// </summary>
        /// <param name="other"> The collection to compare to the current Set<T> object </param>
        /// <returns> True if the Set<T> object is a superset of other; otherwise, false </returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            ValidateEnumerable(other);

            if (other is ICollection<T> collection)
            {
                if (collection != null &&
                    this.Count >= collection.Count)
                {
                    if (collection.Count == 0)
                    {
                        return true;
                    }

                    foreach (var item in collection)
                    {
                        if (!this.Contains(item))
                        {
                            return false;
                        }
                    }

                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the current Set<T> object and a specified collection share common elements
        /// </summary>
        /// <param name="other"> The collection to compare to the current Set<T> object </param>
        /// <returns> True if the Set<T> object and other share at least one common element; otherwise, false </returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            ValidateEnumerable(other);

            if (this.Count == 0)
            {
                return false;
            }

            foreach (var item in other)
            {
                if (this.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes the specified element from a Set<T> object
        /// </summary>
        /// <param name="item"> The element to remove </param>
        /// <returns> True if the element is successfully found and removed; otherwise, false. This method returns false if item is not found in the Set<T> object </returns>
        public bool Remove(T item) => _table.Remove(item);

        /// <summary>
        /// Determines whether a Set<T> object and the specified collection contain the same elements
        /// </summary>
        /// <param name="other"> The collection to compare to the current Set<T> object </param>
        /// <returns> True if the Set<T> object is equal to other; otherwise, false </returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            ValidateEnumerable(other);

            if (other is ICollection<T> collection)
            {
                if (this.Count == collection.Count)
                {
                    if (collection.Count == 0)
                    {
                        return true;
                    }

                    foreach (var item in collection)
                    {
                        if (!this.Contains(item))
                        {
                            return false;
                        }
                    }

                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Modifies the current Set<T> object to contain only elements that are present either in that object or in the specified collection, but not both
        /// </summary>
        /// <param name="other"> The collection to compare to the current Set<T> object </param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            ValidateEnumerable(other);

            if (this.Count == 0)
            {
                this.UnionWith(other);
            }

            foreach (var item in other)
            {
                if (!this.Contains(item))
                {
                    this.Add(item);
                }
                else
                {
                    this.Remove(item);
                }
            }
        }

        /// <summary>
        /// Modifies the current Set<T> object to contain all elements that are present in itself, the specified collection, or both
        /// </summary>
        /// <param name="other"> The collection to compare to the current Set<T> object </param>
        public void UnionWith(IEnumerable<T> other)
        {
            ValidateEnumerable(other);

            foreach (var value in other)
            {
                if (!this.Contains(value))
                {
                    _table.Add(value);
                }
            }
        }

        /// <summary>
        /// Returns a non-generic enumerator that iterates through a Set<T> object
        /// </summary>
        /// <returns> An enumerator object for the Set<T> object </returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion

        #region Private Methods
        void ICollection<T>.Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(
                    "Argument can't be null",
                    nameof(item));
            }

            if (this.IsReadOnly)
            {
                throw new NotSupportedException(
                    "The current collection is read-only");
            }

            this.Add(item);
        }        

        private void ValidateEnumerable(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(
                    "Argument can't be null",
                    nameof(other));
            }
        }
        #endregion

        #region Nested Types
        internal class HashTable : IEnumerable<LinkedList<T>>
        {
            private const double LOADFACTOR = 0.75;
            private LinkedList<T>[] _array;
            private int _capacity;

            public HashTable(IEnumerable<T> enumerable = null, int capacity = 10)
            {
                _capacity = capacity;
                _array = new LinkedList<T>[_capacity];

                if (enumerable != null)
                {
                    foreach (var value in enumerable)
                    {
                        this.Add(value);
                    }
                }
            }

            public int Size { get; private set; }

            public bool Add(T value)
            {
                if (this.Contains(value))
                {
                    return false;
                }

                if (GetLoadFactor() >= LOADFACTOR)
                {
                    this.Resize();
                }

                int index = GetHash(value);

                if (_array[index] == null)
                {
                    _array[index] = new LinkedList<T>();
                }

                _array[index].AddFirst(new LinkedListNode<T>(value));

                Size++;

                return true;
            }

            public bool Remove(T value)
            {
                int index = GetHash(value);

                if (_array[index] != null)
                {
                    foreach (var item in _array[index])
                    {
                        if (item.Equals(value))
                        {
                            _array[index].Remove(item);
                            return true;
                        }
                    }
                }
                
                return false;
            }

            public bool Contains(T value)
            {
                int index = GetHash(value);

                if (_array[index] != null)
                {
                    foreach (var item in _array[index])
                    {
                        if (item.Equals(value))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            public void Clear()
            {
                Size = 0;
                _array = new LinkedList<T>[_capacity];
            }

            public IEnumerator<LinkedList<T>> GetEnumerator()
            {
                foreach (var item in _array)
                {
                    yield return item;
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            private int GetHash(T value)
                => Math.Abs(value.GetHashCode()) % _capacity;

            private double GetLoadFactor() => Size / _capacity;

            private void Resize()
            {
                _capacity = _capacity * 2;
                var previousArray = _array;
                Size = 0;
                _array = new LinkedList<T>[_capacity];

                foreach (var item in previousArray)
                {
                    if (item != null)
                    {
                        foreach (var value in item)
                        {
                            this.Add(value);
                        }
                    }
                }
            }
        }
        #endregion
    }
}