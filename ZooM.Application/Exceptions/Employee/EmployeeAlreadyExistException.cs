using System;
using ZooM.Core.Exceptions;

namespace ZooM.Application.Exceptions.Employee
{
    internal class EmployeeAlreadyExistException : DomainException
    {
        public EmployeeAlreadyExistException(Guid id)
            : base($"Employee with id: {id} already exists") { }
    }
}
