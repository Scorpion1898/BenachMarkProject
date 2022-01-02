using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BanchMarkProject
{
    public class Program
    {
        ICollection<int> test = new Collection<int>();
        static List<Person> users = new List<Person>();
        private static long counter = 10_00;
        static void Main(string[] args)
        {

            init();
            var result = BenchmarkRunner.Run<Program>();
        }

        public static void init()
        {
            for (int i = 0; i <= counter; i++)
            {
                Person person = new Person();
                person.Id = i;
                person.Name = $"user{i}";
                users.Add(person);

            }
        }

        [Benchmark]
        public void OldNotNull()
        {
            int j = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i] != null)
                {
                    j++;
                }
            };

        }

        [Benchmark]
        public void IsNotNull()
        {
            int j = 0;

            for (int i = 0; i < users.Count; i++)
            {

                if (users[i] is not null)
                {
                    j++;
                }
            };

        }

        [Benchmark]
        public void IsObjectNull()
        {
            int j = 0;

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i] is Person)
                {
                    j++;

                }
            };

        }

        //[Benchmark]
        //public void OrderByDynamicCore()
        //{
        //    var tes = users.AsQueryable().OrderBy("Name asc").ToList();

        //}

        //[Benchmark]
        //public void OrderByDescingDynamicCore()
        //{
        //    var tes = users.AsQueryable().OrderBy("Name DESC").ToList();

        //}

        //[Benchmark]
        //public void ListMethodFirstOrDefault()
        //{
        //    test = new Collection<int>();
        //    for (var i = 0; i < 10000; i++)
        //    {
        //        test.Add(i);
        //    }
        //    test.ToList().ForEach(x => x += 1);
        //    var fist = test.FirstOrDefault();

        //}

        //[Benchmark]
        //public void QurableMethod()
        //{
        //    test = new Collection<int>();

        //    for (var i = 0; i < 10000; i++)
        //    {
        //        test.Add(i);
        //    }
        //    var qurable = test.AsQueryable();
        //}

        //[Benchmark]
        //public void EnurableMeethod()
        //{
        //    test = new Collection<int>();

        //    for (var i = 0; i < 10000; i++)
        //    {
        //        test.Add(i);
        //    }
        //    var Enubrable = test.AsEnumerable();
        //}
    }


    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //public static class QueryableExtensions
    //{
    //    public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string columnName, bool isAscending = true)
    //    {
    //        if (String.IsNullOrEmpty(columnName))
    //        {
    //            return source;
    //        }

    //        ParameterExpression parameter = Expression.Parameter(source.ElementType, "");

    //        MemberExpression property = Expression.Property(parameter, columnName);
    //        LambdaExpression lambda = Expression.Lambda(property, parameter);

    //        string methodName = isAscending ? "OrderBy" : "OrderByDescending";

    //        Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
    //                              new Type[] { source.ElementType, property.Type },
    //                              source.Expression, Expression.Quote(lambda));

    //        return source.Provider.CreateQuery<T>(methodCallExpression);
    //    }

    //    public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string columnName, string orderDirection = "asc")
    //    {
    //        if (String.IsNullOrEmpty(columnName))
    //        {
    //            return source;
    //        }


    //        ParameterExpression parameter = Expression.Parameter(source.ElementType, "");

    //        MemberExpression property = Expression.Property(parameter, columnName);
    //        LambdaExpression lambda = Expression.Lambda(property, parameter);

    //        string methodName = orderDirection.ToLower().Equals("desc") ? "OrderByDescending" : "OrderBy";

    //        Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
    //                              new Type[] { source.ElementType, property.Type },
    //                              source.Expression, Expression.Quote(lambda));

    //        return source.Provider.CreateQuery<T>(methodCallExpression);
    //    }

    //    public static IQueryable<T> OrderBy1<T>(this IQueryable<T> source, string columnName, string orderDirection = "asc")
    //    {
    //        if (String.IsNullOrEmpty(columnName))
    //        {
    //            return source;
    //        }
    //        ParameterExpression parameter = Expression.Parameter(source.ElementType, "");
    //        var parts = columnName.Split('.');
    //        Expression parent = parameter;
    //        foreach (var part in parts)
    //        {
    //            parent = Expression.Property(parent, part);
    //        }
    //        LambdaExpression lambda = Expression.Lambda(parent, parameter);

    //        string methodName = orderDirection.ToLower().Contains("desc") ? "OrderByDescending" : "OrderBy";

    //        Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
    //                              new Type[] { source.ElementType, parent.Type },
    //                              source.Expression, Expression.Quote(lambda));

    //        return source.Provider.CreateQuery<T>(methodCallExpression);

    //    }
    //}
}
