namespace SortingData
{
	class EmployeeComparer : IComparer<Employee>
	{
		public int Compare(Employee? e1, Employee? e2)
		{
			// "2017-FI-1343" => "2017", "F1", "1343"

			var e1No = e1.EmployeeNo.Split('-');
			var e2No = e2.EmployeeNo.Split('-');

			int e1Year = Convert.ToInt32(e1No[0]);
			int e2Year = Convert.ToInt32(e2No[0]);

			string e1Dep = e1No[1];
			string e2Dep = e2No[1];

			int e1Id = Convert.ToInt32(e1No[2]);
			int e2Id = Convert.ToInt32(e2No[2]);

			if (e1Dep == e2Dep)
			{
				if (e1Year == e2Year)
				{
					return e1Id.CompareTo(e2Id);
				}
				else
				{
					return e1Year.CompareTo(e2Year);
				}
			}
			else
			{
				return e1Dep.CompareTo(e2Dep);
			}
		}
	}

}
