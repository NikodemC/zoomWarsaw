using System;
using ZooM.Core.Exceptions;

namespace ZooM.Application.Exceptions.Employee
{
    class EmployeeDoesntExistException : DomainException
    {
        public EmployeeDoesntExistException(Guid id)
            : base($"Employee with id: {id} does not exist") { }
    }
}
