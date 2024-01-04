using BanchMarkProject.Data;
using BanchMarkProject.Data.Models;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BanchMarkProject
{
    [MemoryDiagnoser]
    public class Program
    {


        static List<Users> userList = new List<Users>();
        static async Task Main(string[] args)
        {

            var result = BenchmarkRunner.Run<Program>();


        }


        //[GlobalSetup]
        //public async Task Setup()
        //{
        //    var context = new DataContext();
        //    userList = await context.Users.ToListAsync();
        //}


        [Benchmark]
        public async Task NormalList()
        {
            var context = new DataContext();
            var users = await context.Users.ToListAsync();
            var adress = await context.Addresses.ToListAsync();
        }

        [Benchmark]
        public async Task WhenAll()
        {
            var context = new DataContext();
            var users = context.Users.ToListAsync();

            var context2 = new DataContext(); //New DbContext because Multiple threads are attempting to use the same DbContext instance concurrently, which isn't allowed in EF Core.
            var address = context2.Addresses.ToListAsync();

            await Task.WhenAll(users, address);
            var userList = users.Result;
            var addressList = address.Result;
        }

        [Benchmark]
        public void WaitAll()
        {
            var context = new DataContext();
            var users = context.Users.ToListAsync();

            var context2 = new DataContext(); //New DbContext because Multiple threads are attempting to use the same DbContext instance concurrently, which isn't allowed in EF Core.
            var address = context2.Addresses.ToListAsync();

            Task.WaitAll(users, address);
            var userList = users.Result;
            var addressList = address.Result;
        }


        //[Benchmark]
        //public void StandardComparison()
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        string str1 = $"Hello world {i}"; string str2 = $"hello world {i}";
        //        bool result = (str1.ToLower() == str2.ToLower()); // true ;
        //    }
        //}

        //[Benchmark]
        //public void StringEquals()
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        string str1 = $"Hello world {i}"; string str2 = $"hello world {i}";
        //        bool result = str1.Equals(str2, StringComparison.OrdinalIgnoreCase);// true
        //    }
        //}






        //[Benchmark]
        //public async Task RegulerUpdate()
        //{
        //    var context = new DataContext();
        //    var userList = await context.Users.Where(x => x.Id > 1000).ToListAsync();
        //    foreach (var user in userList)
        //    {
        //        user.Category = "Customer";
        //        context.Update(user);
        //    }
        //    context.SaveChanges();
        //}

        //[Benchmark]
        //public async Task BlukUpdate()
        //{
        //    var context = new DataContext();
        //    await context.Users
        //                 .Where(x => x.Id > 1000)
        //                 .ExecuteUpdateAsync(x => x.SetProperty(x => x.Category, x => "Customer"));
        //}





        //[Benchmark]
        //public async Task SystemTextJson() //Version=7.0.0.0
        //{
        //    var context = new DataContext();

        //    var users = await context.Users.ToListAsync();
        //    foreach (var user in users)
        //    {
        //        string json = System.Text.Json.JsonSerializer.Serialize(user);
        //        var userModel = System.Text.Json.JsonSerializer.Deserialize<Users>(json);
        //        if (userModel is not null)
        //        {
        //            var name = userModel.Name;
        //        }
        //    }

        //}
        //[Benchmark]
        //public async Task NewtonsoftJson() //Version=13.0.3
        //{
        //    var context = new DataContext();

        //    var users = await context.Users.ToListAsync();
        //    foreach (var user in users)
        //    {
        //        string json = JsonConvert.SerializeObject(user);
        //        var userModel = JsonConvert.DeserializeObject<Users>(json);
        //        if (userModel is not null)
        //        {
        //            var name = userModel.Name;
        //        }
        //    }
        //}

        //[Benchmark]
        //public async Task Jil() //Version=2.17.0
        //{
        //    var context = new DataContext();

        //    var users = await context.Users.ToListAsync();
        //    foreach (var user in users)
        //    {
        //        string json = JSON.Serialize(user);
        //        var userModel = JSON.Deserialize<Users>(json);
        //        if (userModel is not null)
        //        {
        //            var name = userModel.Name;
        //        }
        //    }
        //}


        //[Benchmark]
        //public async Task UtfJson() //Version=1.3.7
        //{
        //    var context = new DataContext();

        //    var users = await context.Users.ToListAsync();
        //    foreach (var user in users)
        //    {
        //        string json = Utf8Json.JsonSerializer.ToJsonString(user);
        //        var userModel = Utf8Json.JsonSerializer.Deserialize<Users>(json);
        //        if (userModel is not null)
        //        {
        //            var name = userModel.Name;
        //        }
        //    }
        //}


        //[Benchmark]
        //public async Task FirstOrDefaultAsync()
        //{
        //    var context = new DataContext();

        //    var user = await context.Users.Where(x => x.Name.Equals("Caukill")).FirstOrDefaultAsync();
        //    if (user is not null)
        //    {
        //        string name = user.Name;
        //    }
        //}

        //[Benchmark]
        //public async Task SingleOrDefaultAsync()
        //{
        //    var context = new DataContext();

        //    var user = await context.Users.Where(x => x.Name.Equals("Caukill")).SingleOrDefaultAsync();
        //    if (user is not null)
        //    {
        //        string name = user.Name;
        //    }
        //}

        //[Benchmark]
        //public void PlusOperator()
        //{
        //    string names = string.Empty;
        //    foreach (var user in userList)
        //    {
        //        names = names + "," + user.Name;
        //    }
        //}

        //[Benchmark]
        //public void Interpolation()
        //{
        //    string names = string.Empty;
        //    foreach (var user in userList)
        //    {
        //        names = $"{names} {user.Name}";
        //    }
        //}

        //[Benchmark]
        //public void Concat()
        //{
        //    string names = string.Empty;
        //    foreach (var user in userList)
        //    {
        //        names = string.Concat(names, " ", user.Name);
        //    }
        //}

        //[Benchmark]
        //public void Join()
        //{
        //    string names = string.Empty;
        //    foreach (var user in userList)
        //    {
        //        names = string.Join(" ", names, user.Name);
        //    }
        //}

        //[Benchmark]
        //public void Format()
        //{
        //    string names = string.Empty;
        //    foreach (var user in userList)
        //    {
        //        names = string.Format("{0} {1}", names, user.Name);
        //    }
        //}


        //[Benchmark]
        //public void StringBuilder()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    string names = string.Empty;
        //    foreach (var user in userList)
        //    {
        //        sb.Append(user.Name);
        //        sb.Append(" ");
        //    }
        //    names = sb.ToString();
        //}

        //[Benchmark]
        //public void ToList()
        //{
        //    using (var context = new DataContext())
        //    {
        //        var users = context.Users.ToList();
        //        foreach (var user in users)
        //        {
        //            string name = user.Name;
        //        }
        //    }
        //}
        //[Benchmark]
        //public void ToAsNoTrackingList()
        //{
        //    using (var context = new DataContext())
        //    {
        //        var users = context.Users.AsNoTracking().ToList();
        //        foreach (var user in users)
        //        {
        //            string name = user.Name;
        //        }
        //    }
        //}
        //[Benchmark]
        //public void DapperList()
        //{
        //    using (var context = new DataContext())
        //    {
        //        var sql = @"SELECT Id,Name,Category,Created FROM [Users]";
        //        using (IDbConnection conn = new SqlConnection(context.Database.GetConnectionString()))
        //        {
        //            var users = conn.Query<Users>(sql).ToList();
        //            foreach (var user in users)
        //            {
        //                string name = user.Name;
        //            }
        //        }
        //    }
        //}


        //[Benchmark]
        //public void FirstOrDefault()
        //{
        //    using (var context = new DataContext())
        //    {
        //        var user = context.Users.Where(x => x.Id == 1500).AsNoTracking().FirstOrDefault();
        //        if (user is not null)
        //        {
        //            string name = user.Name;
        //        }
        //    }
        //}
        //[Benchmark]
        //public void DapperFirstOrDefault()
        //{
        //    using (var context = new DataContext())
        //    {
        //        var sql = $@"SELECT * FROM [Users] WHERE Id={1500}";
        //        using (IDbConnection conn = new SqlConnection(context.Database.GetConnectionString()))
        //        {
        //            var user = conn.QueryFirstOrDefault<Users>(sql);
        //            if (user is not null)
        //            {
        //                string name = user.Name;
        //            }
        //        }
        //    }
        //}



        //[Benchmark]
        //public void First()
        //{
        //    using var context = new DataContext();
        //    var user = context.Users.Where(x => x.Id == 1500).First();

        //    if (user is not null)
        //    {
        //        string name = user.Name;
        //    }
        //}


        //[Benchmark]
        //public void Single()
        //{
        //    using var context = new DataContext();
        //    var user = context.Users.Where(x => x.Id == 1500).Single();
        //    if (user is not null)
        //    {
        //        string name = user.Name;
        //    }
        //}
        //[Benchmark]
        //public void FirstOrDefault()
        //{
        //    using var context = new DataContext();
        //    var user = context.Users.Where(x => x.Id == 1500).FirstOrDefault();

        //    if (user is not null)
        //    {
        //        string name = user.Name;
        //    }
        //}


        //[Benchmark]
        //public void SingleOrDefault()
        //{
        //    using var context = new DataContext();
        //    var user = context.Users.Where(x => x.Id == 1500).SingleOrDefault();
        //    if (user is not null)
        //    {
        //        string name = user.Name;
        //    }
        //}



        //[Benchmark]
        //public async Task LinqMethod()
        //{
        //    using var context = new DataContext();
        //    var users = await (from u in context.Users
        //                       select u).ToListAsync();

        //}

        //[Benchmark]
        //public async Task LamdaMethod()
        //{
        //    using var context = new DataContext();


        //}


        //[Benchmark]
        //public async Task LinqFirstOrDefaultMethod()
        //{
        //    using var context = new DataContext();
        //    var user = await (from u in context.Users
        //                      where u.Id == 1500
        //                      select u).FirstOrDefaultAsync();

        //}

        //[Benchmark]
        //public async Task LamdaFirstOrDefaultMethod()
        //{
        //    using var context = new DataContext();
        //    var user = await context.Users.Where(x => x.Id == 1500).FirstOrDefaultAsync();

        //}







        //[Benchmark]
        //public async Task SimpleList()
        //{
        //    using var context = new DataContext();

        //    var userList = await context.Users.ToListAsync();

        //}

        //[Benchmark]
        //public async Task AsNoTrackingList()
        //{
        //    using var context = new DataContext();
        //    var userList = await context.Users.AsNoTracking().ToListAsync();
        //}

        //[Benchmark]
        //public void OldNotNull()
        //{
        //    var user = userList.Where(x => x.Id == 5).FirstOrDefault();
        //    string name = string.Empty;
        //    if (user != null)
        //    {
        //        name = user.Name;
        //    }
        //}

        //[Benchmark]
        //public void NotNull()
        //{
        //    var user = userList.Where(x => x.Id == 5).FirstOrDefault();
        //    string name = string.Empty;
        //    if (user is not null)
        //    {
        //        name = user.Name;
        //    }
        //}

        //[Benchmark]
        //public void ObjectNotNull()
        //{
        //    var user = userList.Where(x => x.Id == 5).FirstOrDefault();
        //    string name = string.Empty;
        //    if (user is Users)
        //    {
        //        name = user.Name;
        //    }

        //}
        //[Benchmark]
        //public void ReferenceNotNull()
        //{
        //    var user = userList.Where(x => x.Id == 5).FirstOrDefault();
        //    string name = string.Empty;
        //    if (!object.ReferenceEquals(null, user))
        //    {
        //        name = user.Name;
        //    }
        //}

        //[Benchmark]
        //public void NullConditional()
        //{
        //    var user = userList.Where(x => x.Id == 5).FirstOrDefault();
        //    string name = user?.Name ?? string.Empty;
        //}


        //[Benchmark]
        //public void OperatorNotNull()
        //{
        //    foreach (var user in userList)
        //    {

        //        string name = string.Empty;
        //        name = user.Name ?? "";
        //    };

        //}


        //[Benchmark]
        //public void NewSwitchWith2Case()
        //{
        //    foreach (var item in userList)
        //    {
        //        string result = string.Empty;
        //        result = item.Name switch
        //        {
        //            "Caukill" => "test",
        //            "Temprell" => "test",
        //            _ => "No case available"
        //        }; ;
        //    }

        //}


        //[Benchmark]
        //public void OldSwitchWith2Case()
        //{
        //    foreach (var item in userList)
        //    {
        //        string result = string.Empty;
        //        switch (item.Name)
        //        {
        //            case "Caukill":
        //                result = "test";
        //                break;
        //            case "Temprell":
        //                result = "test";
        //                break;
        //            default:
        //                result = "No case available";
        //                break;
        //        }
        //    }

        //}
        //[Benchmark]
        //public void NewSwitchWith5Case()
        //{
        //    foreach (var item in userList)
        //    {
        //        string result = string.Empty;
        //        result = item.Name switch
        //        {
        //            "Caukill" => "test",
        //            "Temprell" => "test",
        //            "Alexsandrowicz" => "test",
        //            "Bearcroft" => "test",
        //            "O' Connell" => "test",
        //            _ => "No case available"
        //        }; ;
        //    }

        //}


        //[Benchmark]
        //public void OldSwitchWith5Case()
        //{
        //    foreach (var item in userList)
        //    {
        //        string result = string.Empty;
        //        switch (item.Name)
        //        {
        //            case "Caukill":
        //                result = "test";
        //                break;
        //            case "Temprell":
        //                result = "test";
        //                break;
        //            case "Alexsandrowicz":
        //                result = "test";
        //                break;
        //            case "Bearcroft":
        //                result = "test";
        //                break;
        //            case "O' Connell":
        //                result = "test";
        //                break;
        //            default:
        //                result = "No case available";
        //                break;
        //        }
        //    }

        //}






        //[Benchmark]
        //public void NormalLoop()
        //{
        //    for (int i = 0; i < userList.Count; i++)
        //    {
        //        if (userList[i] != null)
        //        {
        //        }
        //    };

        //}

        //[Benchmark]
        //public void ForeachLoop()
        //{

        //    foreach (var person in userList)
        //    {
        //        if (person != null)
        //        {
        //        }

        //    }

        //}

        //[Benchmark]
        //public void SkipTakeWithoutDelegation()
        //{
        //    int j = 0;
        //    for (int i = 0; i < users.Count; i++)
        //    {
        //        var user = users.AsQueryable().Skip(1).Take(6);
        //    }

        //}

        //[Benchmark]
        //public void SkipTakeWithDelegation()
        //{
        //    int j = 0;
        //    for (int i = 0; i < users.Count; i++)
        //    {
        //        var user = users.AsQueryable().Skip(() => 1).Take(() => 6);
        //    }
        //}



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