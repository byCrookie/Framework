using System;
using System.Collections.Generic;
using System.Reflection;

namespace Framework.Boot.TypeLoad
{
	internal interface ITypeEvaluator
	{
		IEnumerable<Type> EvaluateTypes(Assembly assembly);
	}
}