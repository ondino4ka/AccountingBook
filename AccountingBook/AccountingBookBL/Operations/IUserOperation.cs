﻿using AccountingBookCommon.Models;

namespace AccountingBookBL.Operations
{
    public interface IUserOperation
    {
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(int userId);
    }
}
