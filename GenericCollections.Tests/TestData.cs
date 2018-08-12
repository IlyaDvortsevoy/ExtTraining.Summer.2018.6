using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace GenericCollections.Tests
{
    public class TestData
    {
        public static IEnumerable<TestCaseData> ForConstructor
        {
            get
            {
                yield return new TestCaseData(new int[0]).Returns(
                    new Set<int>());

                yield return new TestCaseData(new int[] { 12, -3, 88, 106 }).Returns(
                    new Set<int>() { 12, -3, 88, 106 });

                yield return new TestCaseData(new List<double> { 44.12, -303d, 132.76 }).Returns(
                    new Set<double>() { 44.12, -303d, 132.76 });

                yield return new TestCaseData(new HashSet<Person>()).Returns(
                    new Set<Person>() { });
                
                yield return new TestCaseData(new HashSet<Person>()
                {
                    new Person()
                    {
                        Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                    },

                    new Person()
                    {
                        Age = 32, FirstName = "Dmitry", SecondName = "Petrov"
                    }
                }).Returns(
                    new Set<Person>()
                    {
                        new Person()
                        {
                            Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                        },

                        new Person()
                        {
                            Age = 32, FirstName = "Dmitry", SecondName = "Petrov"
                        }
                    });

                yield return new TestCaseData(new long[] { 115L, -300L, 231L }).Returns(
                    new Set<long>() { 115L, -300L, 231L });
            }
        }

        public static IEnumerable<TestCaseData> ForAdd
        {
            get
            {
                yield return new TestCaseData(new int[0]).Returns(
                    new Set<int>());

                yield return new TestCaseData(new int[] { 12, -3, 88, 106 }).Returns(
                    new Set<int>() { 12, -3, 88, 106 });

                yield return new TestCaseData(new List<double> { 44.12, -303d, 132.76 }).Returns(
                    new Set<double>() { 44.12, -303d, 132.76 });

                yield return new TestCaseData(new HashSet<Person>()
                {
                    new Person()
                    {
                        Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                    },

                    new Person()
                    {
                        Age = 32, FirstName = "Dmitry", SecondName = "Petrov"
                    }
                }).Returns(
                    new Set<Person>()
                    {
                        new Person()
                        {
                            Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                        },

                        new Person()
                        {
                            Age = 32, FirstName = "Dmitry", SecondName = "Petrov"
                        }
                    });

                yield return new TestCaseData(new long[] { 115L, -300L, 231L }).Returns(
                    new Set<long>() { 115L, -300L, 231L });
            }
        }

        public static IEnumerable<TestCaseData> ForClear
        {
            get
            {
                yield return new TestCaseData(new int[0]).Returns(
                    new Set<int>());

                yield return new TestCaseData(new int[] { 12, -3, 88, 106 }).Returns(
                    new Set<int>() { });

                yield return new TestCaseData(new List<double> { 44.12, -303d, 132.76 }).Returns(
                    new Set<double>() { });

                yield return new TestCaseData(new HashSet<Person>()
                {
                    new Person()
                    {
                        Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                    },

                    new Person()
                    {
                        Age = 32, FirstName = "Dmitry", SecondName = "Petrov"
                    }
                }).Returns(new Set<Person>() { });

                yield return new TestCaseData(new long[] { 115L, -300L, 231L }).Returns(
                    new Set<long>() { });
            }
        }

        public static IEnumerable<TestCaseData> ForContains
        {
            get
            {
                yield return new TestCaseData(new int[0], 15).Returns(
                    false);

                yield return new TestCaseData(new int[] { 12, -3, 88, 106 }, 88).Returns(
                    true);

                yield return new TestCaseData(new List<double> { 44.12, -303d, 132.76 }, -400D).Returns(
                    false);

                yield return new TestCaseData(
                    new HashSet<Person>()
                    {
                        new Person()
                        {
                            Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                        },

                        new Person()
                        {
                            Age = 32, FirstName = "Dmitry", SecondName = "Petrov"
                        }
                    },
                    new Person() { Age = 26, FirstName = "Ivan", SecondName = "Ivanov" }).Returns(true);

                yield return new TestCaseData(new long[] { 115L, -300L, 231L }, -300L).Returns(
                    true);
            }
        }        

        public static IEnumerable<TestCaseData> ForCopyTo
        {
            get
            {
                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    2);

                yield return new TestCaseData(
                    new double[] { -13.76, 16D, 401D, 12.66 },
                    0);

                yield return new TestCaseData(
                    new HashSet<Person>()
                    {
                        new Person()
                        {
                            Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                        },

                        new Person()
                        {
                            Age = 32, FirstName = "Dmitry", SecondName = "Petrov"
                        }
                    },
                    3);
            }
        }

        public static IEnumerable<TestCaseData> ForExceptWith
        {
            get
            {
                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { 3, 16, 55 }).Returns(
                    new Set<int>() { 123 });

                yield return new TestCaseData(
                    new double[] { -13.76, 16D, 401D, 12.66 },
                    new Set<double> { -13.76, 8D, 37D }).Returns(
                    new Set<double>() { 16D, 401D, 12.66 });

                yield return new TestCaseData(
                    new HashSet<Person>()
                    {
                        new Person()
                        {
                            Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                        },

                        new Person()
                        {
                            Age = 32, FirstName = "Dmitry", SecondName = "Petrov"
                        }
                    },
                    new Set<Person>
                    {
                        new Person()
                        {
                            Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                        }
                    }).Returns(
                    new Set<Person>
                    {
                        new Person()
                        {
                            Age = 32, FirstName = "Dmitry", SecondName = "Petrov"
                        }
                    });
            }
        }

        public static IEnumerable<TestCaseData> ForIntersectWith
        {
            get
            {
                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { 3, 16, 55 }).Returns(
                    new Set<int>() { 16, 55 });

                yield return new TestCaseData(
                    new double[] { -13.76, 16D, 401D, 12.66 },
                    new Set<double> { -13.76, 8D, 37D }).Returns(
                    new Set<double>() { -13.76 });

                yield return new TestCaseData(
                    new HashSet<Person>()
                    {
                        new Person()
                        {
                            Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                        },

                        new Person()
                        {
                            Age = 32, FirstName = "Dmitry", SecondName = "Petrov"
                        }
                    },
                    new Set<Person>
                    {
                        new Person()
                        {
                            Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                        }
                    }).Returns(
                    new Set<Person>
                    {
                        new Person()
                        {
                            Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                        }
                    });
            }
        }

        public static IEnumerable<TestCaseData> ForIsProperSubsetOf
        {
            get
            {
                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { 123, 16, 55 }).Returns(
                    false);

                yield return new TestCaseData(
                    new List<int> { 14, 123, 16, 55 },
                    new Set<int> { 123, 16, 55 }).Returns(
                    false);

                yield return new TestCaseData(
                    new double[] { 401D, 12.66 },
                    new Set<double> { -13.76, 8D, 37D }).Returns(
                    false);

                yield return new TestCaseData(
                    new double[] { -13.76, 8D },
                    new Set<double> { -13.76, 8D, 37D }).Returns(
                    true);

                yield return new TestCaseData(
                    new HashSet<Person>()
                    {
                        new Person()
                        {
                            Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                        }
                    },
                    new Set<Person>
                    {
                        new Person()
                        {
                            Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                        },

                        new Person()
                        {
                            Age = 32, FirstName = "Dmitry", SecondName = "Petrov"
                        }
                    }).Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ForIsProperSupersetOf
        {
            get
            {
                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { 123, 16, 55 }).Returns(
                    false);

                yield return new TestCaseData(
                    new List<int> { },
                    new Set<int> { }).Returns(
                    false);

                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { }).Returns(
                    true);

                yield return new TestCaseData(
                    new double[] { -13.76, 8D, 37D },
                    new Set<double> { -13.76, 8D, 37D }).Returns(
                    false);

                yield return new TestCaseData(
                    new double[] { 8D, 37D },
                    new Set<double> { -13.76, 8D, 37D }).Returns(
                    false);

                yield return new TestCaseData(
                    new HashSet<Person>()
                    {
                        new Person()
                        {
                            Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                        },

                        new Person()
                        {
                            Age = 32, FirstName = "Dmitry", SecondName = "Petrov"
                        }
                    },
                    new Set<Person>
                    {
                        new Person()
                        {
                            Age = 26, FirstName = "Ivan", SecondName = "Ivanov"
                        },
                    }).Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ForIsSubsetOf
        {
            get
            {
                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { 123, 16, 55 }).Returns(
                    true);

                yield return new TestCaseData(
                    new List<int> { },
                    new Set<int> { }).Returns(
                    true);

                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { }).Returns(
                    false);

                yield return new TestCaseData(
                    new double[] { -13.76, 8D, 37D },
                    new Set<double> { -13.76, 8D, 37D, 67.53 }).Returns(
                    true);
            }
        }

        public static IEnumerable<TestCaseData> ForIsSupersetOf
        {
            get
            {
                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { }).Returns(
                    true);

                yield return new TestCaseData(
                    new List<int> { },
                    new Set<int> { }).Returns(
                    true);

                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { 123, 16, 55, 7 }).Returns(
                    false);

                yield return new TestCaseData(
                    new double[] { -13.76, 8D, 37D },
                    new Set<double> { -13.76, 8D, 37D, 67.53 }).Returns(
                    false);
            }
        }

        public static IEnumerable<TestCaseData> ForOverlaps
        {
            get
            {
                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { }).Returns(
                    false);

                yield return new TestCaseData(
                    new List<int> { },
                    new Set<int> { }).Returns(
                    false);

                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { 123, 16, 55, 7 }).Returns(
                    true);

                yield return new TestCaseData(
                    new double[] { -13.76, 8D, 37D },
                    new Set<double> { -13.76, 8D, 37D, 67.53 }).Returns(
                    true);
            }
        }

        public static IEnumerable<TestCaseData> ForRemove
        {
            get
            {
                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    5).Returns(false);

                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    16).Returns(true);

                yield return new TestCaseData(
                    new double[] { -13.76, 8D, 37D },
                    37D).Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ForSetEquals
        {
            get
            {
                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { 55, 123, 16 }).Returns(
                    true);

                yield return new TestCaseData(
                    new List<int> { },
                    new Set<int> { }).Returns(
                    true);

                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { 123, 16, 55, 123 }).Returns(
                    true);

                yield return new TestCaseData(
                    new double[] { -13.76, 8D, 37D },
                    new Set<double> { -13.76, 8D, 37D, 67.53 }).Returns(
                    false);
            }
        }

        public static IEnumerable<TestCaseData> ForSymmetricExceptWith
        {
            get
            {
                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { 55, 16 }).Returns(
                    new Set<int> { 123 });

                yield return new TestCaseData(
                    new List<int> { },
                    new Set<int> { }).Returns(
                    new Set<int> { });

                yield return new TestCaseData(
                    new double[] { -13.76, 8D, 37D },
                    new Set<double> { -13.76, 8D, 37D, 67.53 }).Returns(
                    new Set<double> { 67.53 });
            }
        }

        public static IEnumerable<TestCaseData> ForUnionWith
        {
            get
            {
                yield return new TestCaseData(
                    new List<int> { 123, 16, 55 },
                    new Set<int> { 55, 34 }).Returns(
                    new Set<int> { 123, 16, 55, 34 });

                yield return new TestCaseData(
                    new List<int> { },
                    new Set<int> { }).Returns(
                    new Set<int> { });

                yield return new TestCaseData(
                    new double[] { -13.76, 8D, 37D },
                    new Set<double> { 55D }).Returns(
                    new Set<double> { -13.76, 8D, 37D, 55D });
            }
        }

        public static IEnumerable<TestCaseData> ForUnion
        {
            get
            {
                yield return new TestCaseData(
                    new Set<int> { 12, 3 },
                    new Set<int> { 55, 34 }).Returns(
                    new Set<int> { 12, 3, 55, 34 });

                yield return new TestCaseData(
                    new Set<int> { },
                    new Set<int> { }).Returns(
                    new Set<int> { });

                yield return new TestCaseData(
                    new Set<double> { -13.76, 8D, 37D },
                    new Set<double> { 55D }).Returns(
                    new Set<double> { -13.76, 8D, 37D, 55D });
            }
        }
    }
}