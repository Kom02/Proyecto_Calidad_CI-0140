using System;

namespace EmprendeUCR.Domain.Core.CoreEntities
{
	public class Permission
	{
		public int Id { get; set; }
		public int Role_Id { get; set; }
		public string Description { get; set; }

		public  Permission(int id, int roleId, string description)
        {
			Id = id;
			Role_Id = roleId;
			Description = description;
        }

		public Permission() {
			Id = int.MinValue;
			Role_Id = int.MinValue;
		}

	}
}
