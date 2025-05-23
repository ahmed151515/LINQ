using System.Linq.Expressions;

namespace ExpressionTrees
{
	internal class Program
	{
		// store the code in a data structure (Tree)
		static void Main(string[] args)
		{
			//ExpressionTrees01();
			//ExpressionTrees02();
			//ExpressionTrees03();


			var customers = Repository.GetCustomers();

			var res = DynamicCustomerFiltering(customers, "age", 19, ExpressionType.LessThan);

			foreach (var c in res)
			{
				Console.WriteLine(c);
			}
			Console.WriteLine("--------------");
			res = DynamicCustomerFiltering(customers, "spendAverage", 2000m, ExpressionType.GreaterThanOrEqual);

			foreach (var c in res)
			{
				Console.WriteLine(c);
			}
			Console.WriteLine("--------------");

			res = DynamicCustomerFiltering(customers, "name", "ahmed", "Contains");

			foreach (var c in res)
			{
				Console.WriteLine(c);
			}
			Console.WriteLine("--------------");

			res = DynamicCustomerFiltering(customers, "name", "m", "StartsWith");

			foreach (var c in res)
			{
				Console.WriteLine(c);
			}




		}

		static void ExpressionTrees01()
		{
			Func<int, bool> isEven = n => n % 2 == 0;

			Console.WriteLine(isEven.Invoke(10));

			Expression<Func<int, bool>> isEvenExpression = n => n % 2 == 0;
			Console.WriteLine(isEvenExpression);
			Console.WriteLine(isEvenExpression.Compile()(10));

		}
		static void ExpressionTrees02()
		{
			Expression<Func<int, bool>> isNegativeExpression
				= n => n < 0;

			ParameterExpression parameter = isNegativeExpression.Parameters[0];
			BinaryExpression operation = (BinaryExpression)isNegativeExpression.Body;

			ParameterExpression left = (ParameterExpression)operation.Left;
			ConstantExpression Right = (ConstantExpression)operation.Right;

			Console.WriteLine(isNegativeExpression);
			Console.WriteLine("Decomposed:");
			Console.WriteLine($"{nameof(parameter)}:{parameter.Name}");
			Console.WriteLine($"{nameof(operation)}:{operation.NodeType}");
			Console.WriteLine($"{nameof(left)}:{left.Name}");
			Console.WriteLine($"{nameof(Right)}:{Right.Value}");
		}
		static void ExpressionTrees03()
		{
			// n => n % 2 == 0

			ParameterExpression numParam = Expression.Parameter(typeof(int), "num");
			ConstantExpression tow = Expression.Constant(2);
			ConstantExpression zero = Expression.Constant(0);

			BinaryExpression modulo = Expression.Modulo(numParam, tow);
			BinaryExpression isEvenBinaryExpression = Expression.Equal(modulo, zero);

			Expression<Func<int, bool>> isEven = Expression.Lambda
				<Func<int, bool>>(isEvenBinaryExpression, new ParameterExpression[] { numParam });

			Console.WriteLine(isEven);
		}
		static IEnumerable<Customer> DynamicCustomerFiltering(IEnumerable<Customer> customers, string propertyName, object value, Object op)
		{
			var param = Expression.Parameter(typeof(Customer));
			var property = Expression.Property(param, propertyName);
			var constant = Expression.Constant(value);
			Expression body = null;
			if (op is ExpressionType opExp)
			{
				body = Expression.MakeBinary(opExp, property, constant);

			}
			else if (op is string opCall)
			{
				var method = typeof(string).GetMethod(opCall, new[] { typeof(string) });

				body = Expression.Call(property, method, constant);
			}
			else
			{
				throw new NotSupportedException($"Invalid Op {op}");
			}


			var filter = Expression.Lambda<Func<Customer, bool>>(body, param).Compile();

			return customers.Where(filter);


		}

	}
}
