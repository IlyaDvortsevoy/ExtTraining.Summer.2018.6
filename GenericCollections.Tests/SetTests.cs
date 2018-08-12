using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace GenericCollections.Tests
{
    [TestFixture]
    public class SetTests
    {
        [TestCaseSource(typeof(TestData), "ForConstructor")]
        public Set<T> Constructor_work_properly<T>(IEnumerable<T> enumerable)
            => new Set<T>(enumerable);

        [TestCaseSource(typeof(TestData), "ForAdd")]
        public Set<T> Add_method_works_properly<T>(IEnumerable<T> enumerable)
        {
            var set = new Set<T>();

            foreach (var item in enumerable)
            {
                set.Add(item);
            }

            return set;
        }

        [TestCaseSource(typeof(TestData), "ForClear")]
        public Set<T> Clear_method_works_properly<T>(IEnumerable<T> enumerable)
        {
            var set = new Set<T>();

            foreach (var item in enumerable)
            {
                set.Add(item);
            }

            var collection = enumerable as ICollection<T>;

            Assert.That(collection.Count, Is.EqualTo(set.Count));

            set.Clear();

            return set;
        }

        [TestCaseSource(typeof(TestData), "ForContains")]
        public bool Contains_method_works_properly<T>(
            IEnumerable<T> enumerable, T target)
        {
            var set = new Set<T>(enumerable);

            return set.Contains(target);
        }

        [Test]
        public void CopyTo_method_throws_ArgumentNullException()
        {
            var array = new int[] { 12, 456, -1, 7, -56 };
            var set1 = new Set<int>(array);

            var list = new List<int> { };
            var set2 = new Set<int>(list);

            Assert.That(
                () => set2.CopyTo(null, 0),
                Throws.TypeOf(typeof(ArgumentNullException)));
        }

        [Test]
        public void CopyTo_method_throws_ArgumentOutOfRangeException()
        {
            var array = new double[] { 12.6, 403D, -1D, 308D };
            var set = new Set<double>(array);

            Assert.That(
                () => set.CopyTo(new double[4], -1),
                Throws.TypeOf(typeof(ArgumentOutOfRangeException)));
        }

        [Test]
        public void CopyTo_method_throws_ArgumentException()
        {
            var list = new List<Person>
            {
                new Person()
                {
                    Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                },

                new Person()
                {
                    Age = 32, FirstName = "Dmitry", SecondName = "Petrov"
                }
            };

            var array = new long[] { 301L, -13L, 254L };

            var set1 = new Set<Person>(list);
            var set2 = new Set<long>(array);

            Assert.That(
                () => set1.CopyTo(new Person[2], 3),
                Throws.TypeOf(typeof(ArgumentException)));

            Assert.That(
                () => set2.CopyTo(new long[3], 1),
                Throws.TypeOf(typeof(ArgumentException)));
        }

        [TestCaseSource(typeof(TestData), "ForCopyTo")]
        public void CopyTo_method_works_properly<T>(
            IEnumerable<T> enumerable,
            int arrayIndex)
        {
            var set = new Set<T>(enumerable);

            var array = new T[10];

            set.CopyTo(array, arrayIndex);

            CollectionAssert.IsSubsetOf(set, array);
        }

        [Test]
        public void ValidateEnumerable_method_throws_ArgumentNullException()
        {
            var array = new int[] { 12, 456, -1, 7, -56 };
            var set = new Set<int>(array);

            Assert.That(
                () => set.ExceptWith(null),
                Throws.TypeOf(typeof(ArgumentNullException)));
        }

        [TestCaseSource(typeof(TestData), "ForExceptWith")]
        public Set<T> ExceptWith_method_works_properly<T>(
            IEnumerable<T> enumerable,
            Set<T> other)
        {
            var set = new Set<T>(enumerable);

            set.ExceptWith(other);

            return set;
        }

        [TestCaseSource(typeof(TestData), "ForIntersectWith")]
        public Set<T> IntersectWith_method_works_properly<T>(
            IEnumerable<T> enumerable,
            Set<T> other)
        {
            var set = new Set<T>(enumerable);

            set.IntersectWith(other);

            return set;
        }

        [TestCaseSource(typeof(TestData), "ForIsProperSubsetOf")]
        public bool IsProperSubsetOf_method_works_properly<T>(
            IEnumerable<T> enumerable,
            Set<T> other)
        {
            var set = new Set<T>(enumerable);

            return set.IsProperSubsetOf(other);
        }

        [TestCaseSource(typeof(TestData), "ForIsProperSupersetOf")]
        public bool IsProperSupersetOf_method_works_properly<T>(
            IEnumerable<T> enumerable,
            Set<T> other)
        {
            var set = new Set<T>(enumerable);

            return set.IsProperSupersetOf(other);
        }

        [TestCaseSource(typeof(TestData), "ForIsSubsetOf")]
        public bool IsSubsetOf_method_works_properly<T>(
            IEnumerable<T> enumerable,
            Set<T> other)
        {
            var set = new Set<T>(enumerable);

            return set.IsSubsetOf(other);
        }

        [TestCaseSource(typeof(TestData), "ForIsSupersetOf")]
        public bool IsSupersetOf_method_works_properly<T>(
            IEnumerable<T> enumerable,
            Set<T> other)
        {
            var set = new Set<T>(enumerable);

            return set.IsSupersetOf(other);
        }

        [TestCaseSource(typeof(TestData), "ForOverlaps")]
        public bool Overlaps_method_works_properly<T>(
            IEnumerable<T> enumerable,
            Set<T> other)
        {
            var set = new Set<T>(enumerable);

            return set.Overlaps(other);
        }

        [TestCaseSource(typeof(TestData), "ForRemove")]
        public bool Remove_method_works_properly<T>(
            IEnumerable<T> enumerable,
            T target)
        {
            var set = new Set<T>(enumerable);

            return set.Remove(target);
        }

        [TestCaseSource(typeof(TestData), "ForSetEquals")]
        public bool SetEquals_method_works_properly<T>(
            IEnumerable<T> enumerable,
            Set<T> other)
        {
            var set = new Set<T>(enumerable);

            return set.SetEquals(other);
        }

        [TestCaseSource(typeof(TestData), "ForSymmetricExceptWith")]
        public Set<T> SymmetricExceptWith_method_works_properly<T>(
           IEnumerable<T> enumerable,
           Set<T> other)
        {
            var set = new Set<T>(enumerable);

            set.SymmetricExceptWith(other);

            return set;
        }

        [TestCaseSource(typeof(TestData), "ForUnionWith")]
        public Set<T> UnionWith_method_works_properly<T>(
           IEnumerable<T> enumerable,
           Set<T> other)
        {
            var set = new Set<T>(enumerable);

            set.UnionWith(other);

            return set;
        }

        [TestCaseSource(typeof(TestData), "ForUnion")]
        public Set<T> Union_method_works_properly<T>(
          Set<T> first,
          Set<T> second)
          => Set<T>.Union(first, second);
    }
}
