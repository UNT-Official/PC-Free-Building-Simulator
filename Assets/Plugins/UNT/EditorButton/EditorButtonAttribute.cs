using System;

namespace UNT.Tools
{
	[AttributeUsage(AttributeTargets.Method)]
	public class EditorButtonAttribute : Attribute
	{
		public string name;
        public EditorButtonAttribute(string name)
        {
            this.name = name;
        }
	}
}
